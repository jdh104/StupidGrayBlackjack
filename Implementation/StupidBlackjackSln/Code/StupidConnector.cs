//ClassMaster: Jonah

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace StupidBlackjackSln.Code
{
    /// <summary>
    /// A wrapper for client-side socket implementation
    /// for StupidBlackjack
    /// </summary>
    class StupidConnector
    {
        private static String ip = StupidServer.DEFAULT_DOMAIN;
        private static int port = StupidServer.DEFAULT_PORT;

        private TcpClient client;
        private int key = new Random().Next(Int32.MaxValue);
        private NetworkStream netstream;
        private String serverDomain;
        private int serverPort;


        /// <summary>
        /// Create a new connection to the default matchmaking server.
        /// </summary>
        public StupidConnector()
        {
            this.serverDomain = ip;
            this.serverPort = port;
            this.client = new TcpClient(serverDomain, serverPort);
            this.netstream = client.GetStream();
        }

        /// <summary>
        /// Create a new connection to a custom matchmaking server.
        /// </summary>
        /// <param name="domain">The domain name (or ip) of the server</param>
        /// <param name="port">The port to connect to</param>
        public StupidConnector(String domain, int port)
        {
            this.serverDomain = domain;
            this.serverPort = port;
            this.client = new TcpClient(serverDomain, serverPort);
            this.netstream = client.GetStream();
        }

        /// <summary>
        /// Close the connection. Use before terminating application
        /// </summary>
        public void Close() {
            netstream.Close();
            client.Close();
        }

        /// <summary>
        /// Alias for Encoding.ASCII.GetString() to make code more readable.
        /// </summary>
        /// <param name="b">Byte array to convert</param>
        /// <returns>The string represented by the given byte array</return>
        private String GetStringFromBytes(byte[] b) {
            return Encoding.ASCII.GetString(b, 0, b.Length);
        }

        /// <summary>
        /// Fetch a list of the games currently being hosted on the matchmaking server.
        /// </summary>
        /// <returns>An array of strings containing game names and id's</returns>
        public String[] FetchListOfGames()
        {
            this.SendString(StupidServer.FETCH_COMMAND);
            return RecieveString().Split(';');
        }

        /// <summary>
        /// Get the "security" key associated with this connector object.
        /// </summary>
        /// <returns>key... u should be able to figure this out.</returns>
        public int GetKey()
        {
            return key;
        }

        /// <summary>
        /// Create a new game session on the matchmaking server.
        /// </summary>
        /// <param name="serverName">Display name for the game session.</param>
        /// <returns>The generated id number for the game, or 0 if failed.</returns>
        public int HostNewGame(String serverName)
        {
            this.SendString(StupidServer.HOST_NEW_GAME_COMMAND + " " + serverName + " " + key.ToString());
            return Int32.Parse(RecieveString());
        }

        /// <summary>
        /// Join a game using its identification number.
        /// </summary>
        /// <param name="id">id of game to join</param>
        /// <returns>True if join succeeded</returns>
        public bool JoinGameByID(int id)
        {
            this.SendString(StupidServer.JOIN_GAME_BY_ID_COMMAND + " " + id);
            String response = RecieveString();
            return response.Equals(StupidServer.JOIN_SUCCESS);
        }

        /// <summary>
        /// Read an incoming string from the NetworkStream connection.
        /// </summary>
        /// <returns>The recieved String</returns>
        private String RecieveString() {
            //Protocol for recieving the correct size string.
            int buffer_size = 40;
            byte[] buffer = new byte[buffer_size];
            netstream.Read(buffer, 0, buffer_size);
            buffer_size = Int32.Parse(GetStringFromBytes(buffer));
            buffer = new byte[buffer_size];

            //Actually read in the string
            netstream.Read(buffer, 0, buffer_size);
            return GetStringFromBytes(buffer);
        }

        /// <summary>
        /// Remove a previously hosted game from the matchmaking server.
        /// </summary>
        /// <param name="id">The id of the game to remove</param>
        public void RemoveHostedGame(int id)
        {
            this.SendString(StupidServer.REMOVE_GAME_BY_ID_COMMAND + " " + id);
        }

        /// <summary>
        /// Send a string to the server to be interpreted as a command.
        /// </summary>
        /// <param name="s">String to send</param>
        private void SendString(String s)
        {
            byte[] data = Encoding.ASCII.GetBytes(s);
            byte[] data_size = Encoding.ASCII.GetBytes(s.Length.ToString());
            netstream.Write(data_size, 0, data_size.Length);
            netstream.Write(data, 0, data.Length);
        }

        /// <summary>
        /// Set IP address of server.
        /// </summary>
        /// <param name="ip"></param>
        public static void SetIP(String ip)
        {
            StupidConnector.ip = ip;
        }

        /// <summary>
        /// Set port of server.
        /// </summary>
        /// <param name="port"></param>
        public static void SetPort(int port)
        {
            StupidConnector.port = port;
        }
    }
}
