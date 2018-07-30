using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SearchFight.Tests
{
    [TestClass]
    public class Configuration
    {
        [TestMethod]
        public void Configuration_IsNotEmpty()
        {
            String key = Shared.Configuration.ReadSetting("GoogleAPI");
            Assert.IsTrue(!String.IsNullOrEmpty(key));
        }
    }
}
