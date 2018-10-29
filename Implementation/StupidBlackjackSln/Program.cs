using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using StupidBlackjackSln.Code;

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
    /// <returns> The singleton instance of StupidServer, null if not started</returns>
    public static StupidServer GetServer() {
      return server;
    }

    /// <summary>
    /// Start a singleton StupidServer if not already started.
    /// </summary>
    /// <returns>Started instance of StupidServer, or null if a server has already been started</returns>
    public static StupidServer StartNewServer() {
      if (server == null) {
        server = new StupidServer();
        server.Start();
        return server;
      } else {
        return null;
      }
    }
  }
}
