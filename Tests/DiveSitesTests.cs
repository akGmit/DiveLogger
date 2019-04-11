using NUnit.Framework;
using DiveLogger;

namespace DiveSitesTests
{
    public class DiveSitesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetSitesTest()
        {
            //DiveLogger.Utils.DiveSitesUtil test = new DiveLogger.Utils.DiveSitesUtil();

            var expected = 8;
            var actual = DiveLogger.Utils.DiveSitesUtil.GetDiveSitesAsync(40, 25, 93).Result.Count;

            Assert.AreEqual(expected, actual, "Failed");
        }

    }
}