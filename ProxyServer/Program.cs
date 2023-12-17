namespace ProxyServerBrightData
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await ProxyServerApp.StartProxyServer(); 
        }
    }
}
