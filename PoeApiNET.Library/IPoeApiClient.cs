using PoeApiNET.Library.Models;

namespace PoeApiNET.Library
{
    public interface IPoeApiClient
    {
        string GetLatestChangeId();
        StashResponse GetLatestPublicStashTabs();
        void GetLatestPublicStashTabsAndHandle(PoeApiClient.DelegateHandler callback);
        StashResponse GetPublicStashTabs(string latestChangeId);
        void StartWatch(PoeApiClient.DelegateHandler callback);
    }
}