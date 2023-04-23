using IridiumCipher.IridiumCipherLogic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IridiumCipher;
using IridiumCipher.Implementations;

namespace IridiumCipherTests
{
    [TestFixture]
    internal class IridiumCipherLogicTests
    {
        private ITestsAdapter _adapter;

        [SetUp]
        public void Setup()
        {
            _adapter = new IridiumTestsAdapterImpl();
        }

        /// <summary>
        /// Тест создания заголовка файла с пустым размером.
        /// </summary>
        /// <param name="length"></param>
        [Test, Order(1)]
        [TestCase(0)]
        public void CreateTitleTestZeroLen(long length)
        {
            var result = _adapter.CreateTitle(length, "");
            Assert.IsFalse(result, _adapter.LastError);
        }

        /// <summary>
        /// Тест создания заголовка файла.Результат также сохраняется в файл.
        /// </summary>
        /// <param name="length"></param>
        [Test, Order(2)]
        [TestCase(10243583, "titleTest.data")]
        public void CreateTitleTest(long length, string fileName)
        {
            var result = _adapter.CreateTitle(length, fileName);
            Assert.IsTrue(result, _adapter.LastError);
        }
        
    }
}
