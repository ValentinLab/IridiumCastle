using IridiumCipher.IridiumCipherLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IridiumCipher.Implementations
{
    /// <summary>
    /// Набор методов существующего крипто алгоритма доступного для внешнего тестирования.
    /// </summary>
    public class IridiumTestsAdapterImpl : ITestsAdapter
    {
        public string LastError { get; private set; }
        private CipherLogic _logic;

        public IridiumTestsAdapterImpl()
        {
            _logic = new CipherLogic();
        }

        /// <summary>
        /// Создание заголовка файла.
        /// </summary>
        /// <param name="length"></param>
        public bool CreateTitle(long length, string fileName)
        {
            var result = _logic.CreateTitle(length);
            LastError = _logic.LastError;

            if(result.isSuccess) File.WriteAllBytes(fileName, result.data);
            return result.isSuccess;
        }
    }
}
