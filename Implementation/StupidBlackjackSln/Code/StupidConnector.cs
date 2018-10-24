using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace StupidBlackjackSln.Code
{
    class StupidConnector
    {
        private TcpClient client;
        private NetworkStream netstream;
        private String serverDomain = "";
        private int serverPort = 0;

        /// <summary>
        /// Create a new connection to the default matchmaking server.
        /// </summary>
        public Connector()
        {
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
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        private TcpClient GenerateTcpClient(String domain, int port)
        {
            IPAddress serverIp = Dns.GetHostEntry(domain).AddressList[0];
            //TODO
        }

        /// <summary>
        /// Fetch a list of the games currently being hosted on the matchmaking server.
        /// </summary>
        /// <returns>An array of strings containing game names and id's</returns>
        public String[] FetchListOfGames()
        {
            return null;
        }

        /// <summary>
        /// Create a new game session on the matchmaking server.
        /// </summary>
        /// <param name="serverName">Display name for the game session.</param>
        /// <returns>The generated id number for the game.</returns>
        public int HostNewGame(String serverName)
        {
            return 0;
        }

        /// <summary>
        /// Join a game using its identification number.
        /// </summary>
        /// <param name="id">id of game to join</param>
        public void JoinGameByID(int id)
        {

        }

        /// <summary>
        /// Remove a previously hosted game from the matchmaking server.
        /// </summary>
        /// <param name="id">The id of the game to remove</param>
        public void RemoveHostedGame(int id)
        {

        }

        private void sendString(String s) {

        }
    }
}
