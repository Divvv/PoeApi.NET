using System;
using System.Linq;
using PoeApiNET.Library;
using PoeApiNET.Library.Models;

namespace PoeApiNET.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();

            PoeApiClient.DelegateHandler handler = worker.DelegateMethod;

            var client = new PoeApiClient();
            // var stuff = client.GetLatestPublicStashTabs().Result;

            // client.GetLatestPublicStashTabsAndHandle(handler);
            client.StartWatch(callback: handler);
        }
    }

    public class Worker
    {
        public void DelegateMethod(StashResponse stashResponse)
        {
            Console.WriteLine("Fetched " + stashResponse.stashes.Count + " stashes.");
            FindBobo(stashResponse);

        }

        private void FindBobo(StashResponse stashResponse)
        {
            var allAccounts = stashResponse.stashes.SelectMany(s => s.accountName).ToList();
            var boboExists = allAccounts.Any(s => s.Equals("ldbob"));
            if (boboExists)
            {
                Console.WriteLine("Found bobo!");
            }
            else
            {
                Console.WriteLine("No bobo ...");
            }
        }
    }
}
