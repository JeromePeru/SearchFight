using SearchFight.Contract;
using SearchFight.Shared;
using System;
using System.ComponentModel.Composition;
using System.Net;

namespace SearchFight.SearchEngine.Google
{
    [Export(typeof(ISearchEngine))]
    public class GoogleSearchEngine : ISearchEngine
    {
        public string Name
        {
            get { return "Google Custom Search"; }
        }


        /// <summary>
        /// Warning : This solution is limited to 100 quieries per day 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public long GetQueryResult(string query)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    string uriQuery = Configuration.ReadSetting("GoogleURL")
                        .Replace("{QUERY}", Uri.EscapeDataString(query))
                        .Replace("{GoogleAPI}", Configuration.ReadSetting("GoogleAPI"))
                        .Replace("{GoogleCSE}", Configuration.ReadSetting("GoogleCSE"));

                    string jsonResult = client.DownloadString(uriQuery);
                    GoogleResult googleResult = Tools.Deserialize<GoogleResult>(jsonResult);

                    return long.Parse(googleResult.searchInformation.totalResults);
                }

                catch(Exception ex)
                {
                    throw new SearchEngineException(Name, ex);
                }
                
            }
        }
    }
}
