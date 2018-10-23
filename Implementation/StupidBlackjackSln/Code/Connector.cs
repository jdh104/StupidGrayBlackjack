using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidBlackjackSln.Code
{
    class Connector
    {
        private String hostDomain = "";
        private int hostPort = 0;

        /// <summary>
        /// Create a new connection to the default matchmaking server.
        /// </summary>
        public Connector()
        {
            
        }

        /// <summary>
        /// Create a new connection to a custom matchmaking server.
        /// </summary>
        /// <param name="domain">The domain name (or ip) of the server</param>
        /// <param name="port">The port to connect to</param>
        public Connector(String domain, int port)
        {
            this.hostDomain = domain;
            this.hostPort = port;
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
    }
}
