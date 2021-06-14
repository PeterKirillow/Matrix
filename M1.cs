using System;
using System.Configuration;

namespace Matrix
{
    public class M1
    {

        /* mode
         * 1 - сложение
         * 2 - вычитание
         */
        public M1(int input, int mode, string sm1, string sm2)
        {
            // в зависимости от выбранного способа ввода испольуется значение из конфигурационного файла или считывается с консоли
            _matrix A;
            _matrix B;
            if (input == 0 )
            {
                string console;
                Console.WriteLine("Введите матрицу A в JSON формате:");
                console = Console.ReadLine();
                A = new _matrix(console);
                Console.WriteLine("Введите матрицу B в JSON формате:");
                console = Console.ReadLine();
                B = new _matrix(console);
            } else
            {
                A = new _matrix(ConfigurationManager.AppSettings.Get($"M.{sm1}"));
                B = new _matrix(ConfigurationManager.AppSettings.Get($"M.{sm2}"));
            }

            if (A.columns != B.columns || A.rows != B.rows)
            {
                Console.WriteLine("Для операций сложения и вычитания размерность матриц должна быть одинаковой");
            } else
            {
                int rows = A.rows;
                int columns = A.columns;
                double[,] m = new double[rows,columns];
                for ( int r=0; r<= rows -1; r++)
                {
                    for ( int c=0; c<= columns - 1; c++)
                    {
                        if (mode == 1)
                        {
                            m[r, c] = A.M[r, c] + B.M[r, c];

                        }
                        else if (mode == 2)
                        {
                            m[r, c] = A.M[r, c] - B.M[r, c];
                        }
                    }
                }
                _matrix C = new _matrix(m);

                Console.WriteLine("Матрица A:");
                A.print_matrix();

                Console.WriteLine("Матрица B:");
                B.print_matrix();

                Console.WriteLine("Результат:");
                C.print_matrix();
            }

        }
    }
}
