using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IridiumCipher.IridiumCipherLogic
{
    /// <summary>
    /// Режим работы блочного шифра
    /// Набор методов для реализации режимов работы блочного шифра согласно ГОСТ 34.13-2015 
    /// </summary>
    internal class Gamma3413
    {
        /// <summary>
        /// Размер блока.
        /// </summary>
        private const short BlockSize = 16; 

        /// <summary>
        /// Итерация гаммирования.
        /// P-открытый текст,MSB-значением n разрядов регистра сдвига с большими номерами,C-результирующий шифртекст
        /// </summary>
        /// <param name="Cipher"></param>
        /// <param name="P"></param>
        /// <param name="MSB"></param>
        /// <param name="C"></param>
        public static void СryptIterationCBC(Action<byte[]> encryptBlock, byte[] p, byte[] msb, byte[] c)
        {
            XorBlocks(p, msb, c); //Складываю  блоки
            encryptBlock(c);//Шифрую блок
        }

        /// <summary>
        /// Складывает блоки длиной 16 байт по модулю 2
        /// </summary>
        /// <param name="block1"></param>
        /// <param name="block2"></param>
        /// <param name="result"></param>
        private static void XorBlocks(byte[] block1, byte[] block2, byte[] result)
        {
            for (short i = 0; i < BlockSize; i++)
            {
                result[i] = (byte)(block1[i] ^ block2[i]);
            }
        }
    }
}
