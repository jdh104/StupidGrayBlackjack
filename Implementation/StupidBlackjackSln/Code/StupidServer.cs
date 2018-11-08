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
        
        public static readonly int DEFAULT_PORT = 61537;
        public static readonly String DEFAULT_DOMAIN = "173.217.233.48";
        public static readonly String COMMAND_SUCCEEDED = "CMD_S";
        public static readonly String COMMAND_UNRECOGNIZED = "CMD_U";
        public static readonly String COMMAND_SYNTAX_ERROR = "CMD_E";
        public static readonly String COMMAND_FAILED = "CMD_F";
        public static readonly String FETCH_COMMAND = "FETCH";
        public static readonly String GET_GAME_NAME_BY_ID_COMMAND = "GNAME";
        public static readonly String GET_GAME_POP_BY_ID_COMMAND = "GPOP";
        public static readonly String HOST_NEW_GAME_COMMAND = "HOST";
        public static readonly String JOIN_GAME_BY_ID_COMMAND = "JOIN";
        public static readonly String NOTIFY_CARD_DRAW = "N_DRAW";
        public static readonly String NOTIFY_STAND = "N_STAND";
        public static readonly String REMOVE_GAME_BY_ID_COMMAND = "RGAME";
        public static readonly String REMOVE_PLAYER_FROM_GAME_COMMAND = "RPLAYER";
        public static readonly String START_GAME_BY_ID_COMMAND = "START";
        public static readonly String UPDATE_DEALER_DRAW = "U_D_DRAW";
        public static readonly String UPDATE_DEALER_STAND = "U_D_STAND";
        public static readonly String UPDATE_DEALER_TURN = "U_D_TURN";
        public static readonly String UPDATE_GAME_CONNECTION_BROKEN = "U_BREAK";
        public static readonly String UPDATE_GAME_HAS_STARTED = "U_START";
        public static readonly String UPDATE_PLAYER_CONNECTION_BROKEN = "U_P_BREAK";
        public static readonly String UPDATE_PLAYER_JOINED = "U_JOINED";
        public static readonly String UPDATE_PLAYER_DRAW = "U_P_DRAW";
        public static readonly String UPDATE_PLAYER_STAND = "U_P_STAND";
        public static readonly String UPDATE_YOUR_TURN = "U_TURN";
        public static readonly byte NEWLINE = Encoding.ASCII.GetBytes("\n")[0];

        private System.Windows.Forms.TextBox outputbox;
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
            if (outputbox != null)
            {
                lock (outputbox)
                {
                    OutputToForm("Server successfully created");
                }
            }
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
            if (outputbox != null)
            {
                lock (outputbox)
                {
                    OutputToForm("Server successfully created");
                }
            }
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
            lock (clients) {
                lock (outputbox)
                {
                    OutputToForm("Broadcasting:");
                    OutputToForm(s);
                }
                foreach (TcpClient client in clients)
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
                this.OutputToForm(sender.Client.RemoteEndPoint.ToString() + "\r\n$ " + cmd);

                String[] args = cmd.Trim().Split(' ');
                String op = args[0];
                if (op.Equals(FETCH_COMMAND))
                {
                    this.PurgeDeadGames();
                    if (games.Count == 0)
                    {
                        this.OutputToForm("Responded with COMMAND_FAILED");
                        return COMMAND_FAILED;
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
                    this.OutputToForm("COMMAND_SUCCEEDED " + ToSend);
                    return COMMAND_SUCCEEDED + " " + ToSend;
                }
                else if (op.Equals(GET_GAME_NAME_BY_ID_COMMAND))
                {
                    int id;
                    try
                    {
                        id = Int32.Parse(args[1]);
                    }
                    catch (Exception)
                    {
                        OutputToForm("Syntax error: cannot parse game id");
                        return COMMAND_SYNTAX_ERROR;
                    }
                    lock (games)
                    {
                        OutputToForm("Locked resources: Searching for game: " + id.ToString());
                        foreach (GameRep game in games)
                        {
                            if (game.id == id)
                            {
                                OutputToForm("Found game: " + game.name);
                                return COMMAND_SUCCEEDED + " " + game.name;
                            }
                        }
                        OutputToForm("Failed to find game: " + id.ToString());
                        return COMMAND_FAILED;
                    }
                }
                else if (op.Equals(GET_GAME_POP_BY_ID_COMMAND))
                {
                    int id;
                    try
                    {
                        id = Int32.Parse(args[1]);
                    }
                    catch (Exception)
                    {
                        OutputToForm("Syntax error: cannot parse game id");
                        return COMMAND_SYNTAX_ERROR;
                    }
                    lock (games)
                    {
                        OutputToForm("Locked resources: Searching for population of game: " + id.ToString());
                        foreach (GameRep game in games)
                        {
                            if (game.id == id)
                            {
                                OutputToForm("Found game: " + game.name + ", pop: " + game.population.ToString());
                                return COMMAND_SUCCEEDED + " " + game.population.ToString();
                            }
                        }
                        OutputToForm("Failed to find game: " + id.ToString());
                        return COMMAND_FAILED;
                    }
                }
                else if (op.Equals(HOST_NEW_GAME_COMMAND))
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
                        return COMMAND_SYNTAX_ERROR;
                    }
                    lock (games)
                    {
                        OutputToForm("Resources Locked: Checking for game: " + new_game_name);
                        foreach (GameRep game in games)
                        {
                            if (game.name.Equals(new_game_name) || game.name.Trim().Equals(""))
                            {
                                OutputToForm("Found duplicate game, Responding with COMMAND_FAILED");
                                return COMMAND_FAILED;
                            }
                        }
                        OutputToForm("Constructing New Game: " + new_game_name + " with key: " + key.ToString());
                        GameRep newGame = new GameRep(new_game_name, key);
                        newGame.SetHost(sender);
                        games.Add(newGame);
                        return COMMAND_SUCCEEDED + " " + newGame.id.ToString();
                    }
                }
                else if (op.Equals(JOIN_GAME_BY_ID_COMMAND))
                {
                    int id, key;
                    try
                    {
                        id = Int32.Parse(args[1]);
                        key = Int32.Parse(args[2]);
                    }
                    catch (Exception)
                    {
                        OutputToForm("Syntax Error: Failed to parse id");
                        return COMMAND_SYNTAX_ERROR;
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
                                return COMMAND_SUCCEEDED + " " + game.population.ToString();
                            }
                        }
                    }
                    OutputToForm("Could not find requested game, responding with COMMAND_FAILED");
                    return COMMAND_FAILED;
                }
                else if (op.Equals(REMOVE_GAME_BY_ID_COMMAND))
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
                        return COMMAND_SYNTAX_ERROR;
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
                                foreach (TcpClient cli in game.GetClientList())
                                {
                                    OutputToForm("\tNotifying client: " + GetIPAddressOf(cli));
                                    this.WriteLine(cli, UPDATE_GAME_CONNECTION_BROKEN);
                                }
                                return COMMAND_SUCCEEDED;
                            }
                        }
                    }
                    OutputToForm("Failed to remove game: Game " + id.ToString() + " doesn't exist or key does not match");
                    return COMMAND_FAILED;
                }
                else if (op.Equals(REMOVE_PLAYER_FROM_GAME_COMMAND))
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
                        return COMMAND_SYNTAX_ERROR;
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
                                    foreach (TcpClient cli in game.GetClientList())
                                    {
                                        this.WriteLine(cli, UPDATE_PLAYER_CONNECTION_BROKEN + " " + index);
                                    }
                                    return COMMAND_SUCCEEDED;
                                }
                                else
                                {
                                    OutputToForm("Client" + key + " not found in game dict");
                                    return COMMAND_FAILED;
                                }
                            }
                        }
                        OutputToForm("Failed to find game, responded with COMMAND_FAILED");
                        return COMMAND_FAILED;
                    }
                }
                else if (op.Equals(START_GAME_BY_ID_COMMAND))
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
                        return COMMAND_SYNTAX_ERROR;
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
                                foreach (TcpClient cli in game.GetClientList())
                                {
                                    this.WriteLine(cli, UPDATE_GAME_HAS_STARTED);
                                }
                                break;
                            }
                        }
                        if (gameToStart == null)
                        {
                            return COMMAND_FAILED;
                        }
                        else
                        {
                            return COMMAND_SUCCEEDED;
                        }
                    }
                }
                else
                {
                    OutputToForm("Unrecognized command, responding with COMMAND_UNRECOGNIZED");
                    return COMMAND_UNRECOGNIZED;
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
                            foreach (TcpClient cli in game.GetClientList())
                            {
                                this.WriteLine(cli, UPDATE_PLAYER_CONNECTION_BROKEN + " " + index.ToString());
                            }
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
                byte[] data = Encoding.ASCII.GetBytes(toWrite.Trim());
                client.GetStream().Write(data, 0, data.Length);
                client.GetStream().Write(new byte[] { NEWLINE }, 0, 1);
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
            public int key;
            public int id;
            public String name;
            public int population = 1;

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
                return client_dict.Values.ToArray<TcpClient>();
            }

            public TcpClient GetHost()
            {
                return client_dict[-1];
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
