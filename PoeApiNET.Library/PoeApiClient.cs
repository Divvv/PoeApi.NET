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

        private string ApiUrl;
        private string PoeWatchIdApiUrl;

        public PoeApiClient()
        {
            ApiUrl = "http://www.pathofexile.com/api/public-stash-tabs?id=";
            PoeWatchIdApiUrl = "https://api.poe.watch/id";
        }

        public PoeApiClient(string apiUrl, string poeWatchApiUrl)
        {
            ApiUrl = apiUrl;
            PoeWatchIdApiUrl = poeWatchApiUrl;
        }

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
            var firstResponse = GetLatestPublicStashTabs();
            callback(firstResponse);
            var followingChanegeId = firstResponse.next_change_id;
            for (; ; )
            {
                var followingResponse = GetPublicStashTabs(followingChanegeId);
                followingChanegeId = followingResponse.next_change_id;
                callback(followingResponse);
            }
        }
    }
}
