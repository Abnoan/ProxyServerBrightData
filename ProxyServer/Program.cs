﻿namespace ProxyServerBrightData
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await ProxyServerApp.StartProxyServer(); 
        }
    }
}