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
    class StupidServer {

        public static const int ID_SIZE_IN_BYTES = 0;
        public static const int DEFAULT_PORT = 0;
        public static const String DEFAULT_DOMAIN = "";
        public static const String JOIN_SUCCESS = "1";
        public static const String FETCH_COMMAND = "f";
        public static const String HOST_NEW_GAME_COMMAND = "h";
        public static const String JOIN_GAME_BY_ID_COMMAND = "j";
        public static const String REMOVE_GAME_BY_ID_COMMAND = "r";

        private bool started;
        private int port = DEFAULT_PORT;
        private ArrayList clients;
        private TcpListener server;

        public StupidServer() {
            clients = new ArrayList();
            server = new TcpListener(this.port);
        }

        public StupidServer(int port) {
            this.port = port;
            clients = new ArrayList();
            server = new TcpListener(this.port);
        }

        private void LoopAccept() {
            while (true) {
                TcpClient c = server.AcceptTcpClient();
                clients.Add(c);
                new Thread(LoopListen).Start(c);
            }
        }

        private void LoopListen(TcpClient c) {
            NetworkStream s = c.GetStream();
        }

        public void Start() {
            try {
                server.Start();
                this.started = true;
                //TODO add some status message
            } catch (Exception e) {
                //TODO
            }

            new Thread(LoopAccept).Start();
        }

        public void Stop() {
            //this.started = false;
        }
    }
}