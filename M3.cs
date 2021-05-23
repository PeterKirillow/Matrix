using System;
using System.Configuration;

namespace Matrix
{
    public class M3
    {
        /*
         * нахождение обратной матрицы
         */
        public M3(string sm)
        {
            _matrix A = new _matrix(ConfigurationManager.AppSettings.Get($"M.{sm}"));

            int rows = A.rows;
            int columns = A.columns;

            if ( rows != columns)
            {
                Console.WriteLine("Понятие обратной матрицы существует только для квадратных матриц");
            }
            else
            {
                // находим определитель матрицы
            }
            /*
            double[,] m = new double[rows, columns];
            for (int r = 0; r <= rows - 1; r++)
            {
                for (int c = 0; c <= columns - 1; c++)
                {

                    m[r, c] = A.M[r, c] * val;

                }
            }
            _matrix C = new _matrix(m);

            Console.WriteLine("A:");
            A.print_matrix();

            Console.WriteLine("Result:");
            C.print_matrix();
            */
        }
       
    }
}
