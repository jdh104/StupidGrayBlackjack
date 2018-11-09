//ClassMaster: Jonah

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StupidBlackjackSln.Code
{
    /// <summary>
    /// Wrapper class for TcpListener that does threaded client 
    /// accepting and listening for StupidBlackjack
    /// </summary>
    class StupidServer
    {
        private delegate void StringDelegateReturningVoid(String s);

        public static readonly byte NEWLINE = Encoding.ASCII.GetBytes("\n")[0];
        public static readonly int DEFAULT_PORT = 61537;
        public static readonly String DEFAULT_DOMAIN = "173.217.233.48";
        
        public static readonly String CMD_FETCH = "FETCH";
        public static readonly String CMD_GET_GAME_NAME_BY_ID = "GNAME";
        public static readonly String CMD_GET_GAME_POP_BY_ID = "GPOP";
        public static readonly String CMD_HOST_NEW_GAME = "HOST";
        public static readonly String CMD_JOIN_GAME_BY_ID = "JOIN";
        public static readonly String CMD_REMOVE_GAME_BY_ID = "RGAME";
        public static readonly String CMD_REMOVE_PLAYER_FROM_GAME = "RPLAYER";
        public static readonly String CMD_START_GAME_BY_ID = "START";

        public static readonly String RESPONSE_SUCCESS = "RES_S";
        public static readonly String RESPONSE_UNRECOGNIZED_CMD = "RES_U";
        public static readonly String RESPONSE_SYNTAX_ERROR = "RES_E";
        public static readonly String RESPONSE_FAIL = "RES_F";

        public static readonly String NOTIFY_CARD_DRAW = "N_DRAW";
        public static readonly String NOTIFY_DEALER_DRAW = "N_D_DRAW";
        public static readonly String NOTIFY_DEALER_SETUP_FINISH = "N_D_SFIN";
        public static readonly String NOTIFY_DEALER_STAND = "N_D_STAND";
        public static readonly String NOTIFY_INIT = "N_INIT";
        public static readonly String NOTIFY_SETUP_FINISH = "N_SFIN";
        public static readonly String NOTIFY_STAND = "N_STAND";

        /// <summary>args[1] -> String representation of a Card object (defined by Card.ToString)</summary>
        public static readonly String UPDATE_DEALER_DRAW = "U_D_DRAW";

        /// <summary>
        /// no args
        /// </summary>
        public static readonly String UPDATE_DEALER_SETUP = "U_D_SETUP";

        /// <summary>no args, means that the dealer's turn has ended</summary>
        public static readonly String UPDATE_DEALER_STAND = "U_D_STAND";
        
        /// <summary>no args, means that the dealer's turn has started</summary>
        public static readonly String UPDATE_DEALER_TURN = "U_D_TURN";

        /// <summary>args[1] -> the player index of the client</summary>
        public static readonly String UPDATE_GAME_CONNECTION_BROKEN = "U_G_BREAK";

        /// <summary>args[1] -> the local player's index</summary>
        public static readonly String UPDATE_GAME_HAS_STARTED = "U_G_START";

        /// <summary>args[1] -> the index of the player that has disconnected</summary>
        public static readonly String UPDATE_PLAYER_CONNECTION_BROKEN = "U_P_BREAK";

        /// <summary>no args, means that a player has decided to join the game. Can only be recieved before game has started</summary>
        public static readonly String UPDATE_PLAYER_JOINED = "U_P_JOINED";

        /// <summary>args[1] -> the index of the player that has drawn // 
        /// args[2] -> String representation of the card drawn (defined by Card.ToString)</summary>
        public static readonly String UPDATE_PLAYER_DRAW = "U_P_DRAW";

        /// <summary>args[1] -> the index of the player that has standed/stood/stund/whatever</summary>
        public static readonly String UPDATE_PLAYER_STAND = "U_P_STAND";

        /// <summary>no args, means that your setup turn has begun. Draw 2 cards and notify.</summary>
        public static readonly String UPDATE_YOUR_SETUP = "U_SETUP";

        /// <summary>no args, means that your turn has begun</summary>
        public static readonly String UPDATE_YOUR_TURN = "U_TURN";

        private System.Windows.Forms.TextBox outputbox = null;
        private bool started = false;
        private int port = DEFAULT_PORT;
        private ArrayList clients = new ArrayList();
        private ArrayList games = new ArrayList();
        private ArrayList streams = new ArrayList();
        private TcpListener server;
        private ArrayList threads = new ArrayList();
        private IPAddress ip;

        /// <summary>
        /// Default constructor, sets up server with default settings.
        /// </summary>
        public StupidServer()
        {
            ip = IPAddress.Parse(GetLocalIPAddress());
            IPEndPoint ipLocalEndPoint = new IPEndPoint(ip, DEFAULT_PORT);
            server = new TcpListener(ipLocalEndPoint);
            GameRep.nextID = 1;
        }

        /// <summary>
        /// Constructor with port specification, use to specify port to listen on.
        /// </summary>
        /// <param name="port">Port to listen on</param>
        public StupidServer(int port)
        {
            this.port = port;
            ip = IPAddress.Parse(GetLocalIPAddress());
            IPEndPoint ipLocalEndPoint = new IPEndPoint(ip, port);
            server = new TcpListener(ipLocalEndPoint);
            GameRep.nextID = 1;
        }

        /// <summary>
        /// Make the StupidServer output debugging info to a Winforms Textbox.
        /// </summary>
        /// <param name="tbox">The textbox to assign</param>
        /// <returns>this, for chaining purposes</returns>
        public StupidServer BindOutputToMultiLineTextBox(System.Windows.Forms.TextBox tbox)
        {
            this.outputbox = tbox;
            return this;
        }

        /// <summary>
        /// Send a message to all connected clients
        /// </summary>
        /// <param name="s">String to broadcast</param>
        private void Broadcast(String s)
        {
            lock (clients)
            {
                lock (outputbox)
                {
                    OutputToForm("\tBroadcasting:\r\n\t");
                    OutputToForm(s);
                }
                foreach (TcpClient client in clients)
                {
                    this.WriteLine(client, s);
                }
            }
        }

        /// <summary>
        /// Send a message to all clients connected to a particular game.
        /// </summary>
        /// <param name="game">GameRep to pull clients from</param>
        /// <param name="s">String to broadcast</param>
        private void BroadcastToGame(GameRep game, String s)
        {
            lock (clients)
            {
                lock (outputbox)
                {
                    OutputToForm("\tBroadcasting to game " + game.id.ToString() + ":\r\n\t");
                    OutputToForm(s);
                }
                foreach (TcpClient client in game.GetClientList())
                {
                    this.WriteLine(client, s);
                }
            }
        }

        /// <summary>
        /// Close all connections. Call this before terminating.
        /// </summary>
        public void Close()
        {
            OutputToForm("Recieved shutdown signal...");
            if (started)
            {
                lock (threads)
                {
                    OutputToForm("Aborting all connection threads...");
                    foreach (Thread t in threads)
                    {
                        t.Abort();
                    }
                }

                OutputToForm("Closing Client connections...");
                foreach (TcpClient c in clients)
                {
                    c.Close();
                }

                OutputToForm("Closing Client network streams...");
                foreach (NetworkStream n in streams)
                {
                    n.Close();
                }

                OutputToForm("Shutting down server...");
                server.Server.Close();
                started = false;
                OutputToForm("Server killed");
            }
        }

        /// <summary>
        /// Grab the remote address of a TcpClient.
        /// </summary>
        /// <param name="client">TcpClient to ask</param>
        /// <returns>String representation of the remote address</returns>
        private static String GetIPAddressOf(TcpClient client)
        {
            return client.Client.RemoteEndPoint.ToString();
        }

        /// <summary>
        /// Grab the machine's usable network address.
        /// </summary>
        /// <returns>The machine's local address as a string representation.</returns>
        private static String GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        /// <summary>
        /// Disambiguate a recieved command and perform desired operation.
        /// </summary>
        /// <param name="cmd">The command string to process</param>
        /// <returns>The response to be sent back to the client</returns>
        private String InterpretCommand(String cmd, TcpClient sender)
        {
            lock (outputbox)
            {
                this.OutputToForm(GetIPAddressOf(sender) + "\r\n$ " + cmd);

                String[] args = cmd.Trim().Split(' ');
                String op = args[0];
                if (op.Equals(CMD_FETCH))
                {
                    this.PurgeDeadGames();
                    int active_count = 0;
                    foreach (GameRep game in games)
                    {
                        active_count += game.started ? 0 : 1;
                    }
                    if (active_count == 0)
                    {
                        this.OutputToForm("Responded with RESPONSE_FAIL");
                        return RESPONSE_FAIL;
                    }
                    String ToSend = "";
                    foreach (GameRep game in games)
                    {
                        if (!game.started)
                        {
                            ToSend += (game.ToString() + ";");
                        }
                    }
                    this.OutputToForm("Responded with:");
                    this.OutputToForm("RESPONSE_SUCCESS " + ToSend);
                    return RESPONSE_SUCCESS + " " + ToSend;
                }
                else if (op.Equals(CMD_GET_GAME_NAME_BY_ID))
                {
                    int id;
                    try
                    {
                        id = Int32.Parse(args[1]);
                    }
                    catch (Exception)
                    {
                        OutputToForm("Syntax error: cannot parse game id");
                        return RESPONSE_SYNTAX_ERROR;
                    }
                    lock (games)
                    {
                        OutputToForm("Locked resources: Searching for game: " + id.ToString());
                        foreach (GameRep game in games)
                        {
                            if (game.id == id)
                            {
                                OutputToForm("Found game: " + game.name);
                                return RESPONSE_SUCCESS + " " + game.name;
                            }
                        }
                        OutputToForm("Failed to find game: " + id.ToString());
                        return RESPONSE_FAIL;
                    }
                }
                else if (op.Equals(CMD_GET_GAME_POP_BY_ID))
                {
                    int id;
                    try
                    {
                        id = Int32.Parse(args[1]);
                    }
                    catch (Exception)
                    {
                        OutputToForm("Syntax error: cannot parse game id");
                        return RESPONSE_SYNTAX_ERROR;
                    }
                    lock (games)
                    {
                        OutputToForm("Locked resources: Searching for population of game: " + id.ToString());
                        foreach (GameRep game in games)
                        {
                            if (game.id == id)
                            {
                                OutputToForm("Found game: " + game.name + ", pop: " + game.population.ToString());
                                return RESPONSE_SUCCESS + " " + game.population.ToString();
                            }
                        }
                        OutputToForm("Failed to find game: " + id.ToString());
                        return RESPONSE_FAIL;
                    }
                }
                else if (op.Equals(CMD_HOST_NEW_GAME))
                {
                    String new_game_name;
                    int key;
                    try
                    {
                        new_game_name = args[1];
                        key = Int32.Parse(args[2]);
                    }
                    catch (Exception)
                    {
                        OutputToForm("Syntax Error: Failed to parse name and key");
                        return RESPONSE_SYNTAX_ERROR;
                    }
                    lock (games)
                    {
                        OutputToForm("Resources Locked: Checking for game: " + new_game_name);
                        foreach (GameRep game in games)
                        {
                            if (game.name.Equals(new_game_name) || game.name.Trim().Equals(""))
                            {
                                OutputToForm("Found duplicate game, Responding with RESPONSE_FAIL");
                                return RESPONSE_FAIL;
                            }
                        }
                        OutputToForm("Constructing New Game: " + new_game_name + " with key: " + key.ToString());
                        GameRep newGame = new GameRep(new_game_name, key);
                        newGame.SetHost(sender);
                        games.Add(newGame);
                        return RESPONSE_SUCCESS + " " + newGame.id.ToString();
                    }
                }
                else if (op.Equals(CMD_JOIN_GAME_BY_ID))
                {
                    int id, key;
                    try
                    {
                        id = Int32.Parse(args[1]);
                        key = Int32.Parse(args[2]);
                    }
                    catch
                    {
                        OutputToForm("Syntax Error: Failed to parse id");
                        return RESPONSE_SYNTAX_ERROR;
                    }
                    lock (games)
                    {
                        OutputToForm("Resources Locked: Searching for game: " + id.ToString());
                        foreach (GameRep game in games)
                        {
                            if (game.id == id && !game.started)
                            {
                                OutputToForm("Found requested game, linking");
                                game.AddClient(key, sender);
                                this.WriteLine(game.GetHost(), UPDATE_PLAYER_JOINED);
                                return RESPONSE_SUCCESS + " " + game.population.ToString();
                            }
                        }
                    }
                    OutputToForm("Could not find requested game, responding with RESPONSE_FAIL");
                    return RESPONSE_FAIL;
                }
                else if (op.Equals(NOTIFY_CARD_DRAW))
                {
                    int id, key;
                    String cardrep;
                    try
                    {
                        id = Int32.Parse(args[1]);
                        key = Int32.Parse(args[2]);
                        cardrep = args[3];
                    }
                    catch
                    {
                        OutputToForm("Syntax Error: Failed to parse command");
                        return RESPONSE_SYNTAX_ERROR;
                    }
                    foreach (GameRep game in games)
                    {
                        if (game.id == id)
                        {
                            int? player_index = game.GetIndexOfClient(sender);
                            if (player_index == null)
                            {
                                OutputToForm("Failed to find player " + key.ToString());
                                return RESPONSE_FAIL;
                            }
                            else
                            {
                                BroadcastToGame(game, UPDATE_PLAYER_DRAW + " " + player_index.ToString() + " " + cardrep);
                                return RESPONSE_SUCCESS;
                            }
                        }
                    }
                    OutputToForm("Failed to find game " + id.ToString());
                    return RESPONSE_FAIL;
                }
                else if (op.Equals(NOTIFY_DEALER_DRAW))
                {
                    int id;
                    String cardString;
                    try
                    {
                        id = Int32.Parse(args[1]);
                        cardString = args[2];
                    }
                    catch
                    {
                        OutputToForm("Syntax Error: Failed to parse command");
                        return RESPONSE_SYNTAX_ERROR;
                    }
                    foreach (GameRep game in games)
                    {
                        if (game.id == id)
                        {
                            BroadcastToGame(game, UPDATE_DEALER_DRAW + " " + cardString);
                            return RESPONSE_SUCCESS;
                        }
                    }
                    return RESPONSE_FAIL;
                }
                else if (op.Equals(NOTIFY_DEALER_SETUP_FINISH))
                {
                    int id;
                    try
                    {
                        id = Int32.Parse(args[1]);
                    }
                    catch
                    {
                        OutputToForm("Syntax Error: Failed to parse command");
                        return RESPONSE_SYNTAX_ERROR;
                    }
                    foreach (GameRep game in games)
                    {
                        if (game.id == id)
                        {
                            game.turn_index = 0;
                            this.WriteLine(game.GetClientList()[game.turn_index], UPDATE_YOUR_TURN);
                            return RESPONSE_SUCCESS;
                        }
                    }
                    return RESPONSE_FAIL;
                }
                else if (op.Equals(NOTIFY_DEALER_STAND))
                {
                    int id;
                    try
                    {
                        id = Int32.Parse(args[1]);
                    }
                    catch
                    {
                        OutputToForm("Syntax Error: Failed to parse command");
                        return RESPONSE_SYNTAX_ERROR;
                    }
                    foreach (GameRep game in games)
                    {
                        if (game.id == id)
                        {
                            this.BroadcastToGame(game, UPDATE_DEALER_STAND);
                            return RESPONSE_SUCCESS;
                        }
                    }
                    return RESPONSE_FAIL;
                }
                else if (op.Equals(NOTIFY_INIT))
                {
                    int id;
                    try
                    {
                        id = Int32.Parse(args[1]);
                    }
                    catch
                    {
                        OutputToForm("Syntax Error: Failed to parse command");
                        return RESPONSE_SYNTAX_ERROR;
                    }
                    foreach (GameRep game in games)
                    {
                        if (game.id == id)
                        {
                            game.waiting--;
                            if (game.waiting == 0)
                            {
                                this.WriteLine(game.GetClientList()[0], UPDATE_YOUR_SETUP);
                            }
                            return RESPONSE_SUCCESS;
                        }
                    }
                    return RESPONSE_FAIL;
                }
                else if (op.Equals(NOTIFY_SETUP_FINISH))
                {
                    int id;
                    try
                    {
                        id = Int32.Parse(args[1]);
                    }
                    catch
                    {
                        OutputToForm("Syntax Error: Failed to parse command");
                        return RESPONSE_SYNTAX_ERROR;
                    }
                    foreach (GameRep game in games)
                    {
                        if (game.id == id)
                        {
                            int? player_index = game.GetIndexOfClient(sender);
                            if (player_index == null)
                            {
                                OutputToForm("Failed to find player at " + sender.Client.RemoteEndPoint.ToString());
                                return RESPONSE_FAIL;
                            }
                            else
                            {
                                game.turn_index++;
                                OutputToForm("Passing setup turn to player index: " + game.turn_index.ToString());
                                try
                                {
                                    this.WriteLine(game.GetClientList()[game.turn_index], UPDATE_YOUR_SETUP);
                                }
                                catch
                                {
                                    this.WriteLine(game.GetClientList()[0], UPDATE_DEALER_SETUP);
                                }
                                return RESPONSE_SUCCESS;
                            }
                        }
                    }
                    OutputToForm("Failed to find game: " + id.ToString());
                    return RESPONSE_FAIL;
                }
                else if (op.Equals(NOTIFY_STAND))
                {
                    int id, key;
                    try
                    {
                        id = Int32.Parse(args[1]);
                        key = Int32.Parse(args[2]);
                    }
                    catch
                    {
                        OutputToForm("Syntax Error: Failed to parse command");
                        return RESPONSE_SYNTAX_ERROR;
                    }
                    foreach (GameRep game in games)
                    {
                        if (game.id == id)
                        {
                            OutputToForm("Found game: " + id + ": checking turn");
                            int? player_index = game.GetIndexOfClient(sender);
                            if (player_index == null)
                            {
                                OutputToForm("Failed to find player " + key.ToString());
                                return RESPONSE_FAIL;
                            }
                            else
                            {
                                BroadcastToGame(game, UPDATE_PLAYER_STAND + " " + player_index.ToString());
                                game.turn_index++;
                                try
                                {
                                    this.WriteLine(game.GetClientList()[game.turn_index], UPDATE_YOUR_TURN);
                                    OutputToForm("Passing turn to player: " + game.turn_index);
                                }
                                catch
                                {
                                    OutputToForm("Passing turn to dealer");
                                    this.WriteLine(sender, UPDATE_DEALER_TURN);
                                }
                                return RESPONSE_SUCCESS;
                            }
                        }
                    }
                    OutputToForm("Failed to find game " + id.ToString());
                    return RESPONSE_FAIL;
                }
                else if (op.Equals(CMD_REMOVE_GAME_BY_ID))
                {
                    int id, key;
                    try
                    {
                        id = Int32.Parse(args[1]);
                        key = Int32.Parse(args[2]);
                    }
                    catch (Exception)
                    {
                        OutputToForm("Syntax Error: Failed to parse id and key");
                        return RESPONSE_SYNTAX_ERROR;
                    }
                    lock (games)
                    {
                        OutputToForm("Locked Resources: Searching for game: " + id.ToString());
                        for (int i = 0; i < games.Count; i++)
                        {
                            GameRep game = (GameRep)games[i];
                            if (game.id == id && game.key == key)
                            {
                                OutputToForm("Found game: " + id.ToString() + ", removing...");
                                games.RemoveAt(i);
                                this.BroadcastToGame(game, UPDATE_GAME_CONNECTION_BROKEN);
                                return RESPONSE_SUCCESS;
                            }
                        }
                    }
                    OutputToForm("Failed to remove game: Game " + id.ToString() + " doesn't exist or key does not match");
                    return RESPONSE_FAIL;
                }
                else if (op.Equals(CMD_REMOVE_PLAYER_FROM_GAME))
                {
                    int id, key;
                    try
                    {
                        id = Int32.Parse(args[1]);
                        key = Int32.Parse(args[2]);
                    }
                    catch (Exception)
                    {
                        OutputToForm("Syntax Error: Failed to parse id and key");
                        return RESPONSE_SYNTAX_ERROR;
                    }
                    lock (games)
                    {
                        OutputToForm("Locked Resources: Searching for game: " + id);
                        foreach (GameRep game in games)
                        {
                            if (game.id == id)
                            {
                                OutputToForm("Found game " + id);
                                if (game.ContainsClientByKey(key))
                                {
                                    OutputToForm("Removing client with key: " + key);
                                    int? index = game.RemoveClient(game.client_dict[key]);
                                    this.BroadcastToGame(game, UPDATE_PLAYER_CONNECTION_BROKEN + " " + index.ToString());
                                    return RESPONSE_SUCCESS;
                                }
                                else
                                {
                                    OutputToForm("Client" + key + " not found in game dict");
                                    return RESPONSE_FAIL;
                                }
                            }
                        }
                        OutputToForm("Failed to find game, responded with RESPONSE_FAIL");
                        return RESPONSE_FAIL;
                    }
                }
                else if (op.Equals(CMD_START_GAME_BY_ID))
                {
                    int id, key;
                    try
                    {
                        id = Int32.Parse(args[1]);
                        key = Int32.Parse(args[2]);
                    }
                    catch (Exception)
                    {
                        OutputToForm("Syntax Error: Failed to parse id and key");
                        return RESPONSE_SYNTAX_ERROR;
                    }
                    lock (games)
                    {
                        OutputToForm("Resource Locked: Searching for game: " + id.ToString());
                        GameRep gameToStart = null;
                        foreach (GameRep game in games)
                        {
                            if (game.id.Equals(id))
                            {
                                game.started = true;
                                game.waiting = game.population;
                                OutputToForm("Updating clients with player index");
                                foreach (TcpClient cli in game.GetClientList())
                                {
                                    if (cli != sender)
                                    {
                                        this.WriteLine(cli, UPDATE_GAME_HAS_STARTED + " " + game.GetIndexOfClient(cli));
                                    }
                                }
                                return UPDATE_GAME_HAS_STARTED + " " + game.GetIndexOfClient(sender).ToString();
                            }
                        }
                        return RESPONSE_FAIL;
                    }
                }
                else
                {
                    OutputToForm("Unrecognized command, responding with RESPONSE_UNRECOGNIZED_CMD");
                    return RESPONSE_UNRECOGNIZED_CMD;
                }
            }
        }

        /// <summary>
        /// Infinite loop for accepting incoming clients. Called only by Start().
        /// </summary>
        private void LoopAccept()
        {
            while (true)
            {
                while (!server.Pending())
                {
                    Thread.Sleep(100);
                }

                lock (outputbox)
                {
                    OutputToForm("Pending new client...");
                }

                TcpClient c =  server.AcceptTcpClient();
                
                lock (clients)
                {
                    clients.Add(c);
                }
                
                // TODO understand what this means
                Thread t = new Thread(() => LoopListen(c));
                
                lock (threads)
                {
                    threads.Add(t);
                }

                lock (outputbox)
                {
                    OutputToForm("Accepted new client: " + GetIPAddressOf(c));
                    OutputToForm("Starting new listener thread: " + t.GetHashCode().ToString());
                }

                t.Start();
            }
        }

        /// <summary>
        /// Infinite loop for recieving and interpreting client commands.
        /// </summary>
        /// <param name="c">TcpClient to listen on</param>
        private void LoopListen(TcpClient c)
        {
            NetworkStream ns = c.GetStream();

            lock (streams)
            {
                streams.Add(ns);
            }

            lock (outputbox)
            {
                OutputToForm("Listener Active for client: " + GetIPAddressOf(c));
            }

            bool not_killed = true;
            while (not_killed)
            {
                try
                {
                    String command = this.ReadLine(c);
                    this.WriteLine(c, this.InterpretCommand(command, c));
                }
                catch (System.IO.IOException)
                {
                    // When player disconnects, remove it from all games
                    not_killed = false;
                    foreach (GameRep game in games)
                    {
                        int? index = game.RemoveClient(c);
                        if (index != null)
                        {
                            this.BroadcastToGame(game, UPDATE_PLAYER_CONNECTION_BROKEN + " " + index.ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Output debug info to a bound winforms textbox.
        /// </summary>
        /// <param name="s">The string to append</param>
        private void OutputToForm(String s)
        {
            if (outputbox != null)
            {
                if (this.outputbox.InvokeRequired)
                {
                    StringDelegateReturningVoid d = new StringDelegateReturningVoid(OutputToForm);
                    outputbox.Parent.Invoke(d, new object[] { s });
                }
                else
                {
                    this.outputbox.AppendText(s + "\r\n");
                }
            }
        }

        /// <summary>
        /// Remove all games hosted by a dead connection
        /// </summary>
        private void PurgeDeadGames()
        {
            lock (games)
            {
                foreach (GameRep game in games)
                {
                    if (!game.GetHost().Connected)
                    {
                        games.Remove(game);
                    }
                }
            }
        }

        /// <summary>
        /// Read in a line from a client's netstream.
        /// </summary>
        /// <param name="client">The TcpClient to read from</param>
        /// <returns>The String read</returns>
        private String ReadLine(TcpClient client)
        {
            byte[] buffer = new byte[1];
            String reading = "";
            client.GetStream().Read(buffer, 0, 1); //Read 1 byte at a time
            while (!buffer[0].Equals(NEWLINE))
            {
                reading += Encoding.ASCII.GetString(buffer);
                client.GetStream().Read(buffer, 0, 1);
            }
            return reading;
        }

        /// <summary>
        /// Bind to the server's port and start accepting and listening to clients.
        /// </summary>
        /// <returns>this (for chaining purposes)</returns>
        public StupidServer Start()
        {
            OutputToForm("Attempting to bind server to: " + ip.ToString() + ":" + port.ToString());

            try
            {
                server.Start();
                started = true;
                //TODO add some status message
            }
            catch (Exception e)
            {
                OutputToForm("Server failed to start:\n" + e.ToString());
                //TODO
            }

            OutputToForm("Server successfully started!");
            Thread t = new Thread(LoopAccept);
            threads.Add(t);
            t.Start();
            return this;
        }

        /// <summary>
        /// Write a string to a client's netstream followed by the newline character.
        /// </summary>
        /// <param name="client">The TcpClient object to send to</param>
        /// <param name="toWrite">The String to be written</param>
        private void WriteLine(TcpClient client, String toWrite)
        {
            if (toWrite != null)
            {
                try
                {
                    byte[] data = Encoding.ASCII.GetBytes(toWrite.Trim());
                    client.GetStream().Write(data, 0, data.Length);
                    client.GetStream().Write(new byte[] { NEWLINE }, 0, 1);
                }
                catch
                {
                    // disconnect the player
                    foreach (GameRep game in games)
                    {
                        if (game.GetClientList().Contains(client))
                        {
                            BroadcastToGame(game, UPDATE_PLAYER_CONNECTION_BROKEN + game.GetIndexOfClient(client));
                            game.RemoveClient(client);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Class for representing potential games on the server, to be used internally by StupidServer.
        /// </summary>
        private class GameRep
        {
            public static int nextID;
            public Dictionary<int, TcpClient> client_dict = new Dictionary<int, TcpClient>(); // <TcpClient>
            public bool started = false;
            public int key, id, turn_index = 0;
            public String name;
            public int population = 1;
            public int waiting;
            public TcpClient[] client_list;

            public GameRep(String _name, int _key)
            {
                name = _name;
                id = nextID++;
                key = _key;
            }

            public void AddClient(int key, TcpClient NewClient)
            {
                client_dict.Add(key, NewClient);
                population++;
            }

            public bool ContainsClientByKey(int key)
            {
                return client_dict.ContainsKey(key);
            }

            public TcpClient[] GetClientList()
            {
                if (started)
                {
                    return client_list ?? (client_list = client_dict.Values.ToArray<TcpClient>());
                }
                else
                {
                    return client_dict.Values.ToArray<TcpClient>();
                }
            }

            public TcpClient GetHost()
            {
                return client_dict[-1];
            }

            public int? GetIndexOfClient(TcpClient cli)
            {
                int index = 0;
                foreach (KeyValuePair<int, TcpClient> kvp in client_dict)
                {
                    if (kvp.Value == cli)
                    {
                        return index;
                    }
                    index++;
                }
                return null;
            }

            /*public void RemoveClientByKey(int key)
            {
                client_dict.Remove(key);
            }*/

            public int? RemoveClient(TcpClient cli)
            {
                int keytoremove = -2; // guaranteed not to be in client_dict
                int client_index = 0;
                foreach (KeyValuePair<int, TcpClient> kvp in client_dict)
                {
                    if (kvp.Value == cli)
                    {
                        keytoremove = kvp.Key;
                        break; // need to get out of loop to remove
                    }
                    client_index++;
                }
                if (keytoremove != -2)
                {
                    client_dict.Remove(keytoremove);
                    return client_index;
                }
                return null;
            }

            public void SetHost(TcpClient host)
            {
                client_dict.Add(-1, host);
            }

            public override string ToString()
            {
                return id.ToString() + ":" + name;
            }
        }
    }
}
