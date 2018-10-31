using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StupidBlackjackSln.Code {
    /// <summary>
    /// Wrapper class for TcpListener that does threaded client 
    /// accepting and listening for StupidBlackjack
    /// </summary>
    class StupidServer {

        public const int ID_SIZE_IN_BYTES = 32;
        public const int DEFAULT_PORT = 61537;
        public const String DEFAULT_DOMAIN = "173.217.233.48";
        public const int MAX_COMMAND_LENGTH = 64;
        public const String JOIN_SUCCESS = "1";
        public const String FETCH_COMMAND = "f";
        public const String HOST_NEW_GAME_COMMAND = "h";
        public const String JOIN_GAME_BY_ID_COMMAND = "j";
        public const String REMOVE_GAME_BY_ID_COMMAND = "r";

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
        public StupidServer() {
            IPAddress ipAddress = IPAddress.Parse(GetLocalIPAddress());
            IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, DEFAULT_PORT);
            clients = new ArrayList();
            server = new TcpListener(ipLocalEndPoint);
        }

        /// <summary>
        /// Constructor with port specification, use to specify port to listen on.
        /// </summary>
        /// <param name="port">Port to listen on</param>
        public StupidServer(int port) {
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
        private void Broadcast(String s) {
            byte[] buffer = Encoding.ASCII.GetBytes(s);
            lock (streams) {
                foreach (NetworkStream ns in streams) {
                    ns.Write(buffer, 0, buffer.Length);
                }
            }
        }

        /// <summary>
        /// Close all connections. Call this before terminating.
        /// </summary>
        public void Close() {
            if (started) {
                
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

        public static string GetLocalIPAddress()
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
        private bool InterpretCommand(String cmd) {
            return false;
            //TODO
        }

        /// <summary>
        /// Infinite loop for accepting incoming clients. Called only by Start().
        /// </summary>
        private void LoopAccept() {
            while (true) {
                while (!server.Pending())
                {
                    Thread.Sleep(100);
                }
                TcpClient c =  server.AcceptTcpClient();
                
                lock (clients) {
                    clients.Add(c);
                }
                
                // TODO understand what this means
                Thread t = new Thread(() => LoopListen(c));
                
                lock (threads) {
                    threads.Add(t);
                }

                t.Start();
            }
        }

        /// <summary>
        /// Infinite loop for recieving and interpreting client commands.
        /// </summary>
        /// <param name="c">TcpClient to listen on</param>
        private void LoopListen(TcpClient c) {
            NetworkStream ns = c.GetStream();

            lock (streams) {
                streams.Add(ns);
            }

            byte[] buffer = new byte[MAX_COMMAND_LENGTH];
            while (true) {
                ns.Read(buffer, 0, MAX_COMMAND_LENGTH);
                this.InterpretCommand(Encoding.ASCII.GetString(buffer, 0, MAX_COMMAND_LENGTH));
            }
        }

        /// <summary>
        /// Bind to port and begin accepting clients.
        /// </summary>
        public void Start() {
            try {
                server.Start();
                started = true;
                //TODO add some status message
            } catch (Exception e) {
                //TODO
            }

            Thread t = new Thread(LoopAccept);
            threads.Add(t);
            t.Start();
        }

        /// <summary>
        /// Class for representing potential games on the server.
        /// </summary>
        private class GameRep
        {

            private ArrayList clients = new ArrayList(); // <TcpClient>
            public int key;
            public int id;
            public String name;
            public int population = 0;

            public GameRep(String _name, int _id, int _key)
            {
                name = _name;
                id = _id;
                key = _key;
            }

            public void AddClient(TcpClient NewClient)
            {
                clients.Add(NewClient);
            }
        }
    }
}
