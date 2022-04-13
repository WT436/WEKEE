using NUnit.Framework;
using Product.Domain.CoreDomain;
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
        private readonly TagProductCoreDomain _tagProductCoreDomain = new TagProductCoreDomain();

        [SetUp]
        public void SetUp()
        {
        }

        [TestCase("dienthoai2", "Điện thoại")]
        [TestCase("maytinhbang", "Máy tính bảng")]
        public void TestProductTag(string value, string value2)
        {
            var rest = _tagProductCoreDomain.ProcessTag(value2);
            Assert.IsTrue(rest == value, $"Data : {value2};\n" +
                                         $"result: {rest};\n" +
                                         $"expectation: {value};\n" +
                                         $"Status : {rest == value}");
        }
    }
}
