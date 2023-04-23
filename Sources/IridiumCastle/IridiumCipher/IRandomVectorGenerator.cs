using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IridiumCipher
{
    /// <summary>
    /// Генератор начального вектора-случайного числа.
    /// </summary>
    public interface IRandomVectorGenerator
    {
        /// <summary>
        /// Генерирует случайное число заданной длины.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        /// <summary>
        /// Генерирует случайное число заданной длины.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        byte[] GenerateIV(int size);
    }
}
