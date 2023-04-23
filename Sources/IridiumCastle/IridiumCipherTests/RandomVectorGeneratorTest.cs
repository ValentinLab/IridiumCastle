using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IridiumCipher;
using IridiumCipher.Implementations;

namespace IridiumCipherTests
{
    [TestFixture]
    internal class RandomVectorGeneratorTest
    {
        private IRandomVectorGenerator _generator;

        [SetUp]
        public void Setup()
        {
            _generator = new RandomVectorLocalImpl();
        }

        [Test]
        [TestCase( 256)]
        public void GenerateRandomVector(int len)
        {
           var array=_generator.GenerateIV(256);

           TestContext.WriteLine($"random={BitConverter.ToString(array)}");
           Assert.IsTrue(array.Length == len);
        }
    }
}
