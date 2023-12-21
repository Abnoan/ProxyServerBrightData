using System.Net;

namespace ProxyServerBrightData
{
    public class ProxyServerApp
    {
        public static async Task StartProxyServer()
        {
            HttpListener listener = new();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            Console.WriteLine("Proxy server is running on http://localhost:8080/");

            await ProcessIncomingRequests(listener);
        }

        private static async Task ProcessIncomingRequests(HttpListener listener)
        {
            while (true)
            {
                try
                {
                    HttpListenerContext context = await listener.GetContextAsync();
                    await RequestProcessor.ProcessRequestAsync(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
