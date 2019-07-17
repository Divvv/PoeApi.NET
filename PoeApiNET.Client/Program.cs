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
            FindHeadhunter(stashResponse);

        }

        private void FindBobo(StashResponse stashResponse)
        {
            var allAccounts = stashResponse.stashes.Where(s => s.accountName != null).Select(s => s.accountName).ToList();
            var boboExists = allAccounts.Any(s => s.Equals("ldbob"));
            if (boboExists)
            {
                Console.WriteLine("Found bobo!");
            }
        }

        private void FindHeadhunter(StashResponse stashResponse)
        {
            var a = 
                stashResponse.stashes
                    .Where(s => s.items.Where(i => i.name.Equals("Headhunter")).Any())
                    .ToList();
            
            foreach (var stash in a)
            {
                Console.WriteLine("Headhunter sold by " + stash.lastCharacterName);
            }
        }
    }
}
