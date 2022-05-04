using Account.Infrastructure.EDMQuery;
using NUnit.Framework;

namespace Account.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        private readonly UserIpEDM _userIpEDM = new UserIpEDM();
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}