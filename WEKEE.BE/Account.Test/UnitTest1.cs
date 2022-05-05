using Account.Infrastructure.EDMQuery;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System.Threading.Tasks;
using Utils.Auth;
using Utils.Auth.Dtos;

namespace Account.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [TestCase(1)]
        public async Task TestProductTag(int value)
        {
            //Assert.IsTrue();
            //$"result: {rest};\n" +
            //$"expectation: {value};\n" +
            //$"Status : {rest == value}");
        }
    }
}