using System;
using System.Configuration;

namespace Matrix
{
    public class M2
    {
        /*
         * умножение матрицы на число
         */
        public M2(string sm)
        {
            _matrix A = new _matrix(ConfigurationManager.AppSettings.Get($"M.{sm}"));
            double factor = Convert.ToDouble(ConfigurationManager.AppSettings.Get("M.Factor"));

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

            Console.WriteLine("Matrix:");
            A.print_matrix();

            Console.WriteLine($"Factor: {factor}");

            Console.WriteLine("Result:");
            C.print_matrix();
        }
       
    }
}
