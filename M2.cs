using System;
using System.Configuration;

namespace Matrix
{
    public class M2
    {
        /*
         * умножение матрицы на число
         */
        public M2(int input, string sm)
        {
            // в зависимости от выбранного способа ввода испольуется значение из конфигурационного файла или считывается с консоли
            // мнижеитель всегда запрашивается с консоли
            _matrix A;
            if (input == 0)
            {
                string console;
                Console.WriteLine("Введите матрицу в JSON формате:");
                console = Console.ReadLine();
                A = new _matrix(console);
            } else
            {
                A = new _matrix(ConfigurationManager.AppSettings.Get($"M.{sm}"));
            }
            Console.Write("Введите множитель: ");
            double factor = Convert.ToDouble(Console.ReadLine());

            int rows = A.rows;
            int columns = A.columns;
            double[,] m = new double[rows, columns];
            for (int r = 0; r <= rows - 1; r++)
            {
                for (int c = 0; c <= columns - 1; c++)
                {

                    m[r, c] = A.M[r, c] * factor;

                }
            }
            _matrix C = new _matrix(m);

            Console.WriteLine("Матрица:");
            A.print_matrix();

            Console.WriteLine($"Множитель: {factor}");

            Console.WriteLine("Результат:");
            C.print_matrix();
        }
       
    }
}
