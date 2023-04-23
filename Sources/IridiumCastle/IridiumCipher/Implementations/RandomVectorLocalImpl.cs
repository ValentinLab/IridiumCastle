using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IridiumCipher.Implementations
{
    /// <summary>
    /// Реализация генератора случайных чисел с использованием стандартных средств языка.
    /// </summary>
    public struct RandomVectorLocalImpl : IRandomVectorGenerator
    {
        /// <summary>
        /// Генерирует случайное число заданной длины.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public byte[] GenerateIV(int size)
        {
            using (var generator = RandomNumberGenerator.Create())
            {
                var IV = new byte[size];
                generator.GetBytes(IV);
                return IV;
            }
        }
    }
}
