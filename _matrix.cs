using System;
using System.Linq;

namespace Matrix
{
    public class _matrix
    {
        public int rows;
        public int columns;
        public double[,] M;

        // инициализация класса строкой
        public _matrix(string m)
        {
            /* https://stackoverflow.com/questions/33102733/how-to-make-matrix-from-string-in-c-sharp */
            // делим всю строку на подстроки, разделители - {},  используем Linq
            var cleanedRows = System.Text.RegularExpressions.Regex.Split(m, @"}\s*,\s*{")
                        .Select(r => r.Replace("{", "").Replace("}", "").Trim())
                        .ToList();
            /**/

            // по первой строке определим количество колонок в массиве
            // обработку на несоответствия количества колонок во всех строках не делаем
            var first_string = cleanedRows.ElementAt(0).Split(',').Select(c => double.Parse(c.Trim())).ToArray();

            // rows count
            rows = cleanedRows.Count;
            // columns count
            columns = first_string.Length;
            // create matrix from string rows
            var matrix = new double[rows, columns];
            for (var r = 0; r <= rows - 1; r++)
            {
                var data_row = cleanedRows.ElementAt(r).Split(',').Select(x => double.Parse(x.Trim())).ToArray();
                for (var c = 0; c <= columns - 1; c++)
                {
                    matrix[r, c] = data_row[c];
                }
            }
            M = matrix;
        }

        // инициализация класса массивом
        public _matrix(double[,] m)
        {
            M = m;
            rows = M.GetLength(0);
            columns = M.GetLength(1);
        }

        // вывод матрицы на консоль
        public void print_matrix()
        {
            for (var r = 0; r <= rows - 1; r++)
            {
                for (var c = 0; c <= columns - 1; c++)
                {
                    Console.Write($"[{M[r,c]}],");
                }
                Console.WriteLine("");
            }
        }

    }
}
