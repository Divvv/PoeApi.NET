using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PoeApiNET.Library.Helpers;
using PoeApiNET.Library.Models;

namespace PoeApiNET.Library
{
    public class PoeApiClient : IPoeApiClient
    {
        public delegate void DelegateHandler(StashResponse stashResponse);

        private const string ApiUrl = "http://www.pathofexile.com/api/public-stash-tabs?id=";
        private const string PoeWatchIdApiUrl = "https://api.poe.watch/id";

        public string GetLatestChangeId()
        {
            var response = HttpHelper.Get(PoeWatchIdApiUrl);
            var deserializedResponse = JsonConvert.DeserializeObject<PoeWatchResponse>(response);

            return deserializedResponse.Id;
        }

        public StashResponse GetLatestPublicStashTabs()
        {
            var latestChangeId = GetLatestChangeId();
            var response = HttpHelper.Get(ApiUrl + latestChangeId);
            var deserializedResponse = JsonConvert.DeserializeObject<StashResponse>(response);

            return deserializedResponse;
        }

        public StashResponse GetPublicStashTabs(string latestChangeId)
        {
            var response = HttpHelper.Get(ApiUrl + latestChangeId);
            var deserializedResponse = JsonConvert.DeserializeObject<StashResponse>(response);

            return deserializedResponse;
        }

        public void GetLatestPublicStashTabsAndHandle(DelegateHandler callback)
        {
            var i = GetLatestPublicStashTabs();
            callback(i);
        }

        public void StartWatch(DelegateHandler callback)
        {
            var a = GetLatestPublicStashTabs();
            callback(a);
            var next = a.next_change_id;
            for (; ; )
            {
                var b = GetPublicStashTabs(next);
                next = b.next_change_id;
                callback(b);
            }
        }
    }
}
