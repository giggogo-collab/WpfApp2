
using System.Windows;

namespace Lib_2
{
    public class Proizv
    {
        /// <summary>
        /// Произведение чисел массива
        /// </summary>
        /// <param name="mas">Вводимый массив</param>
        /// <returns>Произведение всех чисел массива или -1 в случае, если размер 0, он пуст или в нем есть 0</returns>
        public static int Vozvrat(int[] mas)
        {
            int proiz = -1;
            if (mas is not null && mas.Length != 0)
            {
                try
                {
                    proiz = 1;
                    for (int i = 0; i < mas.Length; i++)
                    {
                        proiz *= mas[i];
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка выполнения");
                }
            }
            if (proiz == 0)
                return -1;
            else
                return proiz;
        }
    }

}
