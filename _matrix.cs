using System;
using System.Linq;
using Newtonsoft.Json;

namespace Matrix
{
    public class _matrix
    {
        public int rows;
        public int columns;
        public double[,] M;

        /*----------------------------------------------------------*/
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
            // обработку на несоответствия количества колонок во всех строках НЕ делаем.
            var first_string = cleanedRows.ElementAt(0).Split(',').Select(c => double.Parse(c.Trim())).ToArray();

            // rows/columns count
            this.rows = cleanedRows.Count;
            this.columns = first_string.Length;

            // create matrix from string rows
            var matrix = new double[this.rows, this.columns];
            for (var r = 0; r <= this.rows - 1; r++)
            {
                var data_row = cleanedRows.ElementAt(r).Split(',').Select(x => double.Parse(x.Trim())).ToArray();
                for (var c = 0; c <= this.columns - 1; c++)
                {
                    matrix[r, c] = data_row[c];
                }
            }
            this.M = matrix;
        }

        /*----------------------------------------------------------*/
        // инициализация класса массивом
        public _matrix(double[,] m)
        {
            this.M = m;
            this.rows = M.GetLength(0);
            this.columns = M.GetLength(1);
        }

        /*----------------------------------------------------------*/
        // инициализация класса сгенерированным массивом
        public _matrix(int r, int c, int max)
        {
            double minValue = 0;
            double maxValue = max;
            Random random = new Random();
            this.M = new double[r, c];
            for (var rr = 0; rr <= r - 1; rr++)
            {
                for (var cc = 0; cc <= c - 1; cc++)
                {
                    this.M[rr,cc] = Math.Round(minValue + (random.NextDouble() * (maxValue - minValue)), 0);
                }
            }
            this.rows = r;
            this.columns = c;
        }

        /*----------------------------------------------------------*/
        // вывод матрицы на консоль
        public void print_matrix()
        {
            for (var r = 0; r <= this.rows - 1; r++)
            {
                for (var c = 0; c <= this.columns - 1; c++)
                {                    
                    Console.Write($"[{M[r,c]}]\t");
                    if (c == this.columns - 1) { Console.WriteLine(); }
                }
            }
        }

        /*----------------------------------------------------------*/
        // удаление строки из матрицы
        public void delete_row(int dr)
        {
            int row;
            var m = new double[this.rows - 1, this.columns];
            for ( int c = 0; c < this.columns; c++)
            {
                row = -1;
                for ( int r = 0; r < this.rows; r++)
                {
                    if ( dr != r )
                    {
                        row++;
                        m[row,c] = M[r, c];
                    }
                }
            }
            this.M = m;
            this.rows = this.rows - 1;
        }

        /*----------------------------------------------------------*/
        // удаление колонки из матрицы
        public void delete_column(int dc)
        {
            int column;
            var m = new double[this.rows, this.columns - 1];
            for (int r = 0; r < rows; r++)
            {
                column = -1;
                for (int c = 0; c < this.columns; c++)
                {
                    if (dc != c)
                    {
                        column++;
                        m[r, column] = M[r, c];
                    }
                }
            }
            this.M = m;
            this.columns = this.columns - 1;
        }

        /*----------------------------------------------------------*/
        // удаление строки и колонки из матрицы
        public void delete_rowcol(int dr, int dc)
        {
            int row = 0, col = 0;
            var m = new double[this.rows - 1, this.columns - 1];
            for (int c = 0; c < this.columns; c++)
            {
                col = c >= dc ? -1 : 0;
                for (int r = 0; r < this.rows; r++)
                {
                    row = r >= dr ? -1 : 0;
                    if ( r != dr && c != dc)
                    {
                        m[r + row, c + col] = M[r, c];
                    }
                }
            }
            this.M = m;
            this.rows = this.rows - 1;
            this.columns = this.columns - 1;
        }

        /*----------------------------------------------------------*/
        // транспонирование матрицы
        // строки - в колонки
        public void transposition()
        {
            var m = new double[this.columns, this.rows];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < this.columns; c++)
                {
                    m[c, r] = this.M[r, c];
                }
            }
            this.M = m;
            this.rows = this.columns;
            this.columns = this.rows;
        }

    }
}
