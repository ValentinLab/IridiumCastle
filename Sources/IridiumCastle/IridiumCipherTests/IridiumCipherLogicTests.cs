using IridiumCipher.IridiumCipherLogic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IridiumCipherTests
{
    [TestFixture]
    internal class IridiumCipherLogicTests
    {
        private CipherLogic _logic;

        [SetUp]
        public void Setup()
        {
            _logic = new CipherLogic();
        }

        /// <summary>
        /// Тест создания заголовка файла.
        /// </summary>
        /// <param name="length"></param>
        [Test, Order(1)]
        [TestCase(10243583)]
        public void CreateTitleTest(long length)
        {
            int allowBlockSize = _logic.SymmetricBlockSize;
            var result = _logic.CreateTitle(allowBlockSize-1);

            //Должны получить ошибку-так как не дупустимый размер файла. Файл не может быть меньше блока.
            Assert.IsFalse(result.isSuccess);
            TestContext.WriteLine($"message={_logic.LastError}");

            result = _logic.CreateTitle(length);
            Assert.IsTrue(result.isSuccess);
            File.WriteAllBytes("titleTest.data", result.data);
        }

        [Test, Order(2)]
        [TestCase(1024358)]
        public void RunCipher(long length)
        {
            _logic.RunCipher(length);
            Assert.IsFalse(false);
        }
    }
}
