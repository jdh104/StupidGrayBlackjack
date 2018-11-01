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

        public static readonly int ID_SIZE_IN_BYTES = 32;
        public static readonly int DEFAULT_PORT = 61537;
        public static readonly String DEFAULT_DOMAIN = "173.217.233.48";
        public static readonly int MAX_COMMAND_LENGTH = 64;
        public static readonly String COMMAND_SUCCEEDED = "0";
        public static readonly String COMMAND_UNRECOGNIZED = "1";
        public static readonly String COMMAND_SYNTAX_ERROR = "2";
        public static readonly String COMMAND_FAILED = "3";
        public static readonly String FETCH_COMMAND = "f";
        public static readonly String GET_GAME_NAME_BY_ID_COMMAND = "n";
        public static readonly String GET_GAME_POP_BY_ID_COMMAND = "p";
        public static readonly String HOST_NEW_GAME_COMMAND = "h";
        public static readonly String JOIN_GAME_BY_ID_COMMAND = "j";
        public static readonly String REMOVE_GAME_BY_ID_COMMAND = "r";
        public static readonly String START_GAME_BY_ID_COMMAND = "s";
        public static readonly byte NEWLINE = Encoding.ASCII.GetBytes("\n")[0];

        private System.Windows.Forms.TextBox outputbox;
        private bool started = false;
        private int port = DEFAULT_PORT;
        private ArrayList clients;
        private ArrayList games = new ArrayList();
        private ArrayList streams = new ArrayList();
        private TcpListener server;
        private ArrayList threads = new ArrayList();

        /// <summary>
        /// Default constructor, sets up server with default settings.
        /// </summary>
        public StupidServer()
        {
            IPAddress ipAddress = IPAddress.Parse(GetLocalIPAddress());
            IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, DEFAULT_PORT);
            clients = new ArrayList();
            server = new TcpListener(ipLocalEndPoint);
        }

        /// <summary>
        /// Constructor with port specification, use to specify port to listen on.
        /// </summary>
        /// <param name="port">Port to listen on</param>
        public StupidServer(int port)
        {
            this.port = port;
            IPAddress ipAddress = IPAddress.Parse(GetLocalIPAddress());
            IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, port);
            clients = new ArrayList();
            server = new TcpListener(ipLocalEndPoint);
        }

        /// <summary>
        /// Make the StupidServer output debugging info to a Winforms Textbox.
        /// </summary>
        /// <param name="tbox">The textbox to assign</param>
        public void BindOutputToMultiLineTextBox(System.Windows.Forms.TextBox tbox)
        {
            this.outputbox = tbox;
        }

        /// <summary>
        /// Send a message to all connected clients
        /// </summary>
        /// <param name="s">String to broadcast</param>
        private void Broadcast(String s)
        {
            lock (clients) {
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
            if (started)
            {
                lock (threads)
                {
                    foreach (Thread t in threads)
                    {
                        t.Abort();
                    }
                }

                foreach (TcpClient c in clients)
                {
                    c.Close();
                }

                foreach (NetworkStream n in streams)
                {
                    n.Close();
                }
                
                server.Server.Close();
                started = false;
            }
        }

        /// <summary>
        /// Grab the machine's usable network address.
        /// </summary>
        /// <returns>The machine's local address as a string representation.</returns>
        private static string GetLocalIPAddress()
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
            String[] args = cmd.Trim().Split(' ');
            String c = args[0];
            if (c.Equals(FETCH_COMMAND))
            {
                if (games.Count == 0)
                {
                    return COMMAND_FAILED;
                }
                String ToSend = "";
                foreach (GameRep game in games)
                {
                    ToSend += (game.ToString() + ";");
                }
                return COMMAND_SUCCEEDED + " " + ToSend;
            }
            else if (c.Equals(HOST_NEW_GAME_COMMAND))
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
                    return COMMAND_SYNTAX_ERROR;
                }
                lock (games)
                {
                    foreach (GameRep game in games)
                    {
                        if (game.name.Equals(new_game_name) || game.name.Trim().Equals(""))
                        {
                            return COMMAND_FAILED;
                        }
                    }
                    GameRep newGame = new GameRep(new_game_name, key);
                    games.Add(newGame);
                    return COMMAND_SUCCEEDED + " " + newGame.id.ToString();
                }
            }
            else if (c.Equals(JOIN_GAME_BY_ID_COMMAND))
            {
                // TODO
                int id;
                try
                {
                    id = Int32.Parse(args[1]);
                }
                catch (Exception)
                {
                    return COMMAND_SYNTAX_ERROR;
                }
                lock (games)
                {
                    foreach (GameRep game in games)
                    {
                        if (game.id == id && !game.started)
                        {
                            game.AddClient(sender);
                            return COMMAND_SUCCEEDED + " " + game.population.ToString();
                        }
                    }
                }
                return COMMAND_FAILED;
            }
            else if (c.Equals(REMOVE_GAME_BY_ID_COMMAND))
            {
                int id, key;
                try
                {
                    id = Int32.Parse(args[1]);
                    key = Int32.Parse(args[2]);
                }
                catch (Exception)
                {
                    return COMMAND_SYNTAX_ERROR;
                }
                lock (games)
                {
                    for (int i=0; i<games.Count; i++)
                    {
                        GameRep game = (GameRep)games[i];
                        if (game.id == id && game.key == key)
                        {
                            games.RemoveAt(i);
                            return COMMAND_SUCCEEDED;
                        }
                    }
                }
                return COMMAND_FAILED;
            }
            else if (c.Equals(START_GAME_BY_ID_COMMAND))
            {
                // TODO
                return COMMAND_UNRECOGNIZED;
            }
            else
            {
                return COMMAND_UNRECOGNIZED;
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

            lock (streams) {
                streams.Add(ns);
            }
            
            while (true)
            {
                String command = this.ReadLine(c);
                this.WriteLine(c, this.InterpretCommand(command, c));
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
                outputbox.Text += "\n" + s;
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
            try
            {
                server.Start();
                started = true;
                //TODO add some status message
            }
            catch (Exception)
            {
                //TODO
            }

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
            byte[] data = Encoding.ASCII.GetBytes(toWrite.Trim());
            client.GetStream().Write(data, 0, data.Length);
            client.GetStream().Write(new byte[] {NEWLINE}, 0, 1);
        }

        /// <summary>
        /// Class for representing potential games on the server.
        /// </summary>
        private class GameRep
        {
            private static int nextID = 1;
            private ArrayList clients = new ArrayList(); // <TcpClient>
            public bool started = false;
            public int key;
            public int id;
            public String name;
            public int population = 0;

            public GameRep(String _name, int _key)
            {
                name = _name;
                id = nextID++;
                key = _key;
            }

            public void AddClient(TcpClient NewClient)
            {
                clients.Add(NewClient);
                population++;
            }

            public override string ToString()
            {
                return id.ToString() + ":" + name;
            }
        }
    }
}
