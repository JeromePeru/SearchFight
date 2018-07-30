using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchFight.Tests
{
    [TestClass]
    public class Bing
    {
        [TestMethod]
        public void Bing_Query_Expected_Positive()
        {
            SearchEngine.Bing.BingSearchEngine bingSearchEngine = new SearchEngine.Bing.BingSearchEngine();
            long result = bingSearchEngine.GetQueryResult("test");

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Bing_QuotationMarks_Expected_Positive()
        {
            SearchEngine.Bing.BingSearchEngine bingSearchEngine = new SearchEngine.Bing.BingSearchEngine();
            long result = bingSearchEngine.GetQueryResult("\"java script\"");

            Assert.IsTrue(result > 0);
        }
    }
}
