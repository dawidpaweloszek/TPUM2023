﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace PresentationServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Server started");
            await WebSocketServer.Server(8081, ConnectionHandler);
        }

        static void ConnectionHandler(WebSocketConnection webSocketConnection)
        {

            webSocketConnection.OnMessage = ParseMessage;
            webSocketConnection.OnClose = () => { Console.WriteLine("[Server]: Connection closed"); };
            webSocketConnection.OnError = () => { Console.WriteLine("[Server]: Connection error encountered"); };
        }

        static async void ParseMessage(string message)
        {
            Console.WriteLine($"[Client]: {message}");
        }
    }
}