using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StupidBlackjackSln {
  static class Program {

    private static StupidServer server = null;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new frmTitle());
    }

    /// <summary>
    /// Close the singleton StupidServer if it exists.
    /// </summary>
    public static void CloseStupidServer() {
        if (server != null) {
          server.Close();
          server = null;
        }
    }

    /// <summary>
    /// Get singleton instance of StupidServer.
    /// </summary>
    /// <returns> The singleton instance of StupidServer</returns>
    public static StupidServer GetServer() {
      return server;
    }

    /// <summary>
    /// Start a singleton StupidServer
    /// </summary>
    public static void StartStupidServer() {
      server = new StupidServer();
      server.Start();
    }
  }
}
