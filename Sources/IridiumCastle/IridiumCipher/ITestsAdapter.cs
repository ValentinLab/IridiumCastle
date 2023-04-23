using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IridiumCipher
{
    /// <summary>
    /// Внешний интерфейс для тестирования библиотеки.
    /// </summary>
    public interface ITestsAdapter
    {
        string LastError { get; }

        /// <summary>
        /// Создание заголовка файла.
        /// </summary>
        /// <param name="length"></param>
        public bool CreateTitle(long length, string fileName);
    }
}
