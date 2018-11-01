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

        public const int ID_SIZE_IN_BYTES = 32;
        public const int DEFAULT_PORT = 61537;
        public const String DEFAULT_DOMAIN = "173.217.233.48";
        public const int MAX_COMMAND_LENGTH = 64;
        public const String JOIN_SUCCESS = "1";
        public const String FETCH_COMMAND = "f";
        public const String HOST_NEW_GAME_COMMAND = "h";
        public const String JOIN_GAME_BY_ID_COMMAND = "j";
        public const String REMOVE_GAME_BY_ID_COMMAND = "r";
        public const byte NEWLINE = Encoding.ASCII.GetBytes("\n")[0];

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
        /// <returns>True if command was recognized, else false</returns>
        private bool InterpretCommand(String cmd, TcpClient sender)
        {
            String[] args = cmd.Trim().Split(' ');
            if (args[0] == FETCH_COMMAND)
            {
                String ToSend = "";
                foreach (GameRep game in games)
                {
                    ToSend += (game.ToString() + ";");
                }
                this.WriteLine(sender, ToSend);
                return true;
            }
            else if (args[0] == HOST_NEW_GAME_COMMAND)
            {
                String new_game_name = args[1];
                int key;
                try
                {
                    key = Int32.Parse(args[2]);
                }
                catch (Exception e)
                {
                    return false;
                }
                GameRep newGame = new GameRep(new_game_name, key);
                games.Add(newGame);
                this.WriteLine(sender, newGame.id.ToString());
                return true;
            }
            else if (args[0] == JOIN_GAME_BY_ID_COMMAND)
            {
                // TODO
                int id;
                try
                {
                    id = Int32.Parse(args[1]);
                }
                catch (Exception e)
                {
                    return false;
                }

                return true;
            }
            else if (args[0] == REMOVE_GAME_BY_ID_COMMAND)
            {
                // TODO
                return true;
            }
            else
            {
                return false; //Command unrecognized
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
                this.InterpretCommand(command, c);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
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

        /*/// <summary>
        /// Read an incoming string from the NetworkStream connection.
        /// </summary>
        /// <returns>The recieved String</returns>
        private String RecieveString(TcpClient client)
        {
            //Protocol for recieving the correct size string.
            int buffer_size = 40;
            byte[] buffer = new byte[buffer_size];
            client.GetStream().Read(buffer, 0, buffer_size);
            buffer_size = Int32.Parse(Encoding.ASCII.GetString(buffer, 0, buffer.Length));
            Int32.Parse(this.ReadLine(client));
            buffer = new byte[buffer_size];

            //Actually read in the string
            client.GetStream().Read(buffer, 0, buffer_size);
            return Encoding.ASCII.GetString(buffer, 0, buffer.Length);
        }*/

        /// <summary>
        /// Bind to port and begin accepting clients.
        /// </summary>
        /// <returns>itself (for chaining)</returns>
        public StupidServer Start()
        {
            try
            {
                server.Start();
                started = true;
                //TODO add some status message
            }
            catch (Exception e)
            {
                //TODO
            }

            Thread t = new Thread(LoopAccept);
            threads.Add(t);
            t.Start();
            return this;
        }

        /*/// <summary>
        /// Send a string to a client.
        /// </summary>
        /// <param name="client">TcpClient object to send to</param>
        /// <param name="s">String to send</param>
        private void SendString(TcpClient client, String s)
        {
            byte[] data = Encoding.ASCII.GetBytes(s);
            byte[] data_size = Encoding.ASCII.GetBytes(s.Length.ToString());
            client.GetStream().Write(data_size, 0, data_size.Length);
            Thread.Sleep(1000);
            client.GetStream().Write(data, 0, data.Length);
        }*/

        ///
        ///
        ///
        ///
        ///
        private void WriteLine(TcpClient client, String toWrite)
        {
            byte[] data = Encoding.ASCII.GetBytes(s);
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
            }

            public override string ToString()
            {
                return id.ToString() + " " + name;
            }
        }
    }
}
