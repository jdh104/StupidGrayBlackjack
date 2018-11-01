//ClassMaster: Jonah

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using StupidBlackjackSln.Code;

namespace StupidBlackjackSln
{
    static class Program
    {

        private static StupidServer server = null;
        private static StupidConnector connector = null;
        private static AchievementMonitor achievements = new AchievementMonitor();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmTitle());
        }

        /// <summary>
        /// Close the singleton StupidConnector if it exists.
        /// </summary>
        public static void CloseStupidConnector()
        {
            if (connector != null)
            {
                connector.Close();
                connector = null;
            }
        }

        /// <summary>
        /// Close the singleton StupidServer if it exists.
        /// </summary>
        public static void CloseStupidServer()
        {
            if (server != null)
            {
                server.Close();
                server = null;
            }
        }

        public static StupidConnector GetConnector()
        {
            return connector;
        }

        /// <summary>
        /// Get singleton instance of StupidServer.
        /// </summary>
        /// <returns> The singleton instance of StupidServer, null if not started</returns>
        public static StupidServer GetServer()
        {
            return server;
        }

        /// <summary>
        /// Start a quasi-singleton StupidConnector if one does not already exist.
        /// </summary>
        /// <returns>The started StupidConnector object</returns>
        public static StupidConnector StartNewConnector()
        {
            return connector ?? (connector = new StupidConnector());
        }

        /// <summary>
        /// Start a quasi-singleton StupidServer if not already started.
        /// </summary>
        /// <returns>Started instance of StupidServer, or null if a server has already been started</returns>
        public static StupidServer StartNewServer()
        {
            return server ?? (server = new StupidServer().Start());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputbox"></param>
        /// <returns></returns>
        public static StupidServer StartNewServer(System.Windows.Forms.TextBox outputbox)
        {
            return server ?? (server = new StupidServer().BindOutputToMultiLineTextBox(outputbox).Start());
        }
    }
}
