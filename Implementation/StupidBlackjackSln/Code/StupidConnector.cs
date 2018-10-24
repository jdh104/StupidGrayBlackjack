using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using StupidBlackjackSln.Code.StupidServer;

namespace StupidBlackjackSln.Code
{
    class StupidConnector
    {
        private TcpClient client;
        private NetworkStream netstream;
        private String serverDomain;
        private int serverPort;

        /// <summary>
        /// Create a new connection to the default matchmaking server.
        /// </summary>
        public Connector()
        {
            this.serverDomain = StupidServer.DEFAULT_DOMAIN;
            this.serverPort = StupidServer.DEFAULT_PORT;
            this.client = GenerateTcpClient(serverDomain, serverPort);
            this.netstream = client.GetStream();
        }

        /// <summary>
        /// Create a new connection to a custom matchmaking server.
        /// </summary>
        /// <param name="domain">The domain name (or ip) of the server</param>
        /// <param name="port">The port to connect to</param>
        public Connector(String domain, int port)
        {
            this.serverDomain = domain;
            this.serverPort = port;
            this.client = GenerateTcpClient(serverDomain, serverPort);
            this.netstream = client.GetStream();
        }

        public void Close() {
            netstream.Close();
            client.Close();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        private TcpClient GenerateTcpClient(String domain, int port)
        {
            //IPAddress serverIp = Dns.GetHostEntry(domain).AddressList[0];
            return new TcpClient(domain, port);
        }

        /// <summary>
        /// Alias for Encoding.ASCII.GetString() to make code more readable.
        /// </summary>
        /// <param name="b">Byte array to convert</param>
        /// <returns>The string represented by the given byte array</return>
        private String GetStringFromBytes(byte[] b) {
            return Encoding.ASCII.GetString(b, 0, b.Length());
        }

        /// <summary>
        /// Fetch a list of the games currently being hosted on the matchmaking server.
        /// </summary>
        /// <returns>An array of strings containing game names and id's</returns>
        public String FetchListOfGames()
        {
            this.sendString("list");

            byte[] buffer = new byte[40];
            netstream.Read(buffer, 0, buffer.Length());
            buffer = new byte[Int32.Parse(GetStringFromBytes(buffer))];
            netstream.Read(buffer, 0, buffer.Length());
            return GetStringFromBytes(buffer);
        }

        /// <summary>
        /// Create a new game session on the matchmaking server.
        /// </summary>
        /// <param name="serverName">Display name for the game session.</param>
        /// <returns>The generated id number for the game.</returns>
        public int HostNewGame(String serverName)
        {
            byte[] buffer = new byte[StupidServer.ID_SIZE_IN_BYTES];
            this.sendString("new");
            netstream.Read(buffer, 0, buffer.Length());
            return Int32.Parse(GetStringFromBytes(buffer));
        }

        /// <summary>
        /// Join a game using its identification number.
        /// </summary>
        /// <param name="id">id of game to join</param>
        public void JoinGameByID(int id)
        {
            this.sendString("join " + id);
        }

        /// <summary>
        /// Remove a previously hosted game from the matchmaking server.
        /// </summary>
        /// <param name="id">The id of the game to remove</param>
        public void RemoveHostedGame(int id)
        {
            this.sendString("rm " + id);
        }

        private void sendString(String s)
        {
            byte[] data = Encoding.ASCII.GetBytes(s);
            netstream.Write(data, 0, data.Length());
        }
    }
}
