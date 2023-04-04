using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Globalization;
using System.Threading.Tasks;
using DataServer;
using LogicServer;

namespace PresentationServer
{
    internal class Program
    {
        static IShop shop;
        private static ILogicLayer logicLayer;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Server started");
            logicLayer = ILogicLayer.Create();
            shop = logicLayer.Shop;
            await WebSocketServer.Server(8081, ConnectionHandler);
        }

        static void ConnectionHandler(WebSocketConnection webSocketConnection)
        {
            Console.WriteLine("[Server]: Client connected");
            WebSocketServer.CurrentConnection = webSocketConnection;
            webSocketConnection.OnMessage = ParseMessage;
            webSocketConnection.OnClose = () => { Console.WriteLine("[Server]: Connection closed"); };
            webSocketConnection.OnError = () => { Console.WriteLine("[Server]: Connection error encountered"); };
        }

        static async void ParseMessage(string message)
        {
            Console.WriteLine($"[Client]: {message}");
            if (message == "main page button click")
            {
                await SendMessageAsync("main page button click response");
            }

            if (message == "RequestAll")
            {
                await SendCurrentWarehouseState();
            }
            
        }

        static async Task SendCurrentWarehouseState()
        {
            var weapons = shop.GetWeapons();
            var json = Serializer.WarehouseToJSON(weapons);
            var message = "UpdateAll" + json;

            await SendMessageAsync(message);
        }

        static async Task SendMessageAsync(string message)
        {
            Console.WriteLine("[Server]: " + message);
            await WebSocketServer.CurrentConnection.SendAsync(message);
        }
    }
}
