using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchFight.SearchSessionLib;

namespace SearchFight.Tests
{
    [TestClass]
    public class SearchResult
    {
        [TestMethod]
        public void SearchResult_Max()
        {
            SearchFight.SearchSession.SearchResults searchResults = new SearchFight.SearchSession.SearchResults();

            searchResults.Add(new QueryResult()
            {
                Query = "java",
                SearchEngineName = "ENGINE1",
                ResultCount = 100
            });

            searchResults.Add(new QueryResult()
            {
                Query = "java",
                SearchEngineName = "ENGINE2",
                ResultCount = 200
            });

            Assert.IsTrue(searchResults.Max.ResultCount == 200);
        }
    }
}
