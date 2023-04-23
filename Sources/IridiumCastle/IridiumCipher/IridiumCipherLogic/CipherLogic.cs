using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IridiumCipher.IridiumCipherLogic
{
    /// <summary>
    ///  Логика данной версии IridiumCipher.
    /// </summary>
    public class CipherLogic
    {
        private string _lastError;

        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public string LastError
        {
            get => _lastError;
        }

        //Первые 7 байт содержащих версию.
        private static byte[] _fileTitle = new byte[]{ 0xf9, 0xc5, 0xa8, 0xd3, 0x47, 0xb6, 0x3a };
        
        //Текст идущий после версии 46 символов.
        private const string PgmTitle = "Local protect subsystem for data vesion v 5.04";

        /// <summary>
        /// Размер вектора IV.
        /// </summary>
        private const int IVsize = 32;
        
        /// <summary>
        /// Размер блока симметричного шифра.
        /// </summary>
        private const int СipherBlockSize = 16;

        /// <summary>
        /// Длина блока содержащего размер файла в байтах.
        /// </summary>
        private const int DataLengthBlockSize = 16;

        /// <summary>
        /// Размер блока симметричного шифра.
        /// </summary>
        public int SymmetricBlockSize
        {
            get => СipherBlockSize;
        }
        
        /// <summary>
        /// Формирует заголовок файла 126 байт.
        /// </summary>
        /// <param name="fileSize"></param>
        /// <returns></returns>
        public (byte[] data, bool isSuccess) CreateTitle(long fileSize)
        {
            if (fileSize < СipherBlockSize)
            {
                _lastError = $"Размер данных менее {СipherBlockSize} байт. Шифрование невозможно.";
                return (new byte[1], false);
            }

            byte[] title = new byte[126];

            _fileTitle.CopyTo(title, 0);
            byte []info = Encoding.ASCII.GetBytes(PgmTitle);

            info.CopyTo(title, _fileTitle.Length);

            //Преобразовывает длину блока данных в массив из 8 байт
            //Определение размера. Если размер файла кратен 16: 16байт длина, 32 iv
            long blockCount = fileSize % СipherBlockSize;

            if (blockCount == 0) fileSize = fileSize + СipherBlockSize + IVsize;
            else
            {
                fileSize -= blockCount;

                //Сообщение дополняется блоком СipherBlockSize байт  если его длина не кратна СipherBlockSize
                fileSize += СipherBlockSize + СipherBlockSize + IVsize;
            }
            
            int pos = _fileTitle.Length + info.Length;
            byte[] sizeData = BitConverter.GetBytes(fileSize);
            sizeData.CopyTo(title, pos);

            return (title, true);
        }

        /// <summary>
        /// Прототип метода, ведется перенос кода!
        /// </summary>
        public void RunCipher(long fileSize)
        {
            //Для многопоточности нужно  byte[] iv = new byte[32]; Начальный вектор содержащийся в регистре и скопировать его в Reg.
            //16-размер гаммы-вынести в класс гаммирования.
            byte[] Reg = new byte[32]; //Регистр сдвига для гаммирования.
            byte[] MSB = new byte[16]; //значением n разрядов регистра сдвига с большими номерами
            byte[] Flen = new byte[DataLengthBlockSize]; //Заголовок-размер файла(информационного блока) в виде 16 байт

            byte[] C_block = new byte[16];
            //uint8_t C_block[16]; //результирующий шифротекст

            var fSize = BitConverter.GetBytes(fileSize);
            fSize.CopyTo(Flen, 0);

            //Итерация гаммирования.
            Gamma3413.СryptIterationCBC(Cipher3412.EncryptBlock, Flen, MSB, C_block );

        }
    }
}
