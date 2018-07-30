using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchFight.Tests
{
    [TestClass]
    public class Google
    {
        [TestMethod]
        public void Google_Query_Expected_Positive()
        {
            SearchEngine.Google.GoogleSearchEngine googleSearchEngine = new SearchEngine.Google.GoogleSearchEngine();
            long result = googleSearchEngine.GetQueryResult("test");

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Google_QuotationMarks_Expected_Positive()
        {
            SearchEngine.Google.GoogleSearchEngine googleSearchEngine = new SearchEngine.Google.GoogleSearchEngine();
            long result = googleSearchEngine.GetQueryResult("\"java script\"");

            Assert.IsTrue(result > 0);
        }
    }
}
