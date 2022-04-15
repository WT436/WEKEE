using Newtonsoft.Json;
using NUnit.Framework;
using Product.Application.Application;
using Product.Domain.CoreDomain;
using Product.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Test
{
    [TestFixture]
    public class ProductTests
    {
        private readonly ProductService _tagProductCoreDomain = new ProductService();

        [SetUp]
        public void SetUp()
        {
        }

        [TestCase(1)]
        public async Task TestProductTag(int value)
        {
            var rest = await _tagProductCoreDomain.ProductCartRead(value);
            Assert.IsTrue(rest == null, $"Data : {JsonConvert.SerializeObject(rest)};\n");
            //$"result: {rest};\n" +
            //$"expectation: {value};\n" +
            //$"Status : {rest == value}");
        }
    }
}
