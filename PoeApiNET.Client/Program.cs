using System;
using PoeApiNET.Library;
using PoeApiNET.Library.Models;
using static PoeApiNET.Library.PoeApiClient;

namespace PoeApiNET.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Del handler = DelegateMethod;

            var client = new PoeApiClient();
            // var stuff = client.GetLatestPublicStashTabs().Result;

            // client.GetLatestPublicStashTabsAndHandle(handler);
            client.StartWatch(handler);
        }
        
        public static void DelegateMethod(StashResponse stashResponse)
        {
            Console.WriteLine("test: " + stashResponse.stashes[0].accountName);
        }
    }
}
