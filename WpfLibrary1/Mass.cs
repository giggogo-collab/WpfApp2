using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace LibMas
{
    public class Mass
    {
        /// <summary>
        /// Заполнение массива случайными цифрами от -200 до 200, кроме 0
        /// </summary>
        /// <param name="Count">Размер массива</param>
        /// <returns>Заполненный массив</returns>
        public static int[] Fill(int Count)
        {
            int[] mas = new int[Count];
            try
            {
                Random Rand = new Random();
                for (int i = 0; i < Count; i++)
                {
                    mas[i] = Rand.Next(-200, 201);
                    if (mas[i] == 0)
                    {
                        mas[i] -= 1;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка выполнения");
            }
            return mas;
        }
        /// <summary>
        /// Превращает массив в пустой
        /// </summary>
        /// <param name="mas">Вводимый массив</param>
        /// <returns>Возвращает пустой массив </returns>
        public static int[] Clear(int[] mas)
        {
            mas = null;
            return mas;
        }
        /// <summary>
        /// Сохраняет массив  файлом в текстовом формате
        /// </summary>
        /// <param name="mas">Сохраняемый массив</param>
        public static void Save(int[] mas)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.DefaultExt = ".txt";
                save.Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt";
                save.FilterIndex = 2;
                save.Title = "Сохранение одномерного массива";

                if (save.ShowDialog() == true)
                {
                    StreamWriter file = new StreamWriter(save.FileName);
                    file.WriteLine(mas.Length); //null
                    for (int i = 0; i < mas.Length; i++)
                    {
                        file.WriteLine(mas[i]);
                    }
                    file.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка выполнения");
            }
        }
        /// <summary>
        /// Открытие сохраненного массива из файлы в текстовом формате
        /// </summary>
        /// <param name="mas">Вводимый массив</param>
        /// <returns>Открытый массив</returns>

        public static int[] Open(int[] mas)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.DefaultExt = ".txt";
                open.Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt";
                open.FilterIndex = 2;
                open.Title = "Открытие одномерного массива";

                if (open.ShowDialog() == true)
                {
                    StreamReader file = new StreamReader(open.FileName);
                    int len = Convert.ToInt32(file.ReadLine());
                    mas = new Int32[len];
                    for (int i = 0; i < mas.Length; i++)
                    {
                        mas[i] = Convert.ToInt32(file.ReadLine());
                    }
                    file.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка выполнения");
            }
            return mas;
        }
    }
}