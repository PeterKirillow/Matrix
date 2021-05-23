using System;
using System.Configuration;

namespace Matrix
{
    public class M1
    {
        /*
         * 1 - сложение
         * 2 - вычитание
         */
        public M1(int mode)
        {
            _matrix A = new _matrix(ConfigurationManager.AppSettings.Get("M.A"));
            _matrix B = new _matrix(ConfigurationManager.AppSettings.Get("M.B"));

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

                Console.WriteLine("A:");
                A.print_matrix();

                Console.WriteLine("B:");
                B.print_matrix();

                Console.WriteLine("Result:");
                C.print_matrix();
            }

        }
    }
}
