using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using PresentationServer;

namespace IntegrationTest
{
    [TestClass]
    public class ClientServerTest
    {
        [TestMethod]
        public async Task WebSocketUsageTestMethod()
        {
            PresentationServer.WebSocketConnection wserver = null;
            Data.WebSocketConnection wclient = null;
            const int delay = 10;

            // Create server
            Uri uri = new Uri("ws://localhost:6969");
            List<string> logOutput = new List<string>();
            Task server = Task.Run(async () => await WebSocketServer.Server(uri.Port,
                ws =>
                {
                    wserver = ws;
                    wserver.OnMessage = (data) =>
                    {
                        logOutput.Add($"Received message from client: {data}");
                    };
                }));
            await Task.Delay(delay);

            // Connect client
            wclient = await WebSocketClient.Connect(uri, message => logOutput.Add(message));

            Assert.IsNotNull(wserver);
            Assert.IsNotNull(wclient);

            // Send testing data from client to server
            Task clientSendTask = wclient.SendAsync("test");
            Assert.IsTrue(clientSendTask.Wait(new TimeSpan(0, 0, 1)));

            await Task.Delay(delay);
            Assert.AreEqual($"Received message from client: test", logOutput[0]);

            // Server response
            wclient.OnMessage = (data) =>
            {
                logOutput.Add($"Received message from server: {data}");
            };
            Task serverSendTask = wserver.SendAsync("test 2");
            Assert.IsTrue(serverSendTask.Wait(new TimeSpan (0, 0, 1)));
            
            await Task.Delay(delay);
            Assert.AreEqual($"Received message from server: test 2", logOutput[1]);

            await wclient?.DisconnectAsync();
            await wserver?.DisconnectAsync();
        }
    }
}