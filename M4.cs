using System;
using System.Configuration;

namespace Matrix
{
    public class M4
    {
        /*
         * перемножение матриц - AB
         */
        public M4(int input, string sm1, String sm2)
        {
            _matrix A;
            _matrix B;

            if (input == 0)
            {
                string console;
                Console.WriteLine("Введите матрицу A в JSON формате:");
                console = Console.ReadLine();
                A = new _matrix(console);
                Console.WriteLine("Введите матрицу B в JSON формате:");
                console = Console.ReadLine();
                B = new _matrix(console);
            }
            else
            {
                A = new _matrix(ConfigurationManager.AppSettings.Get($"M.{sm1}"));
                B = new _matrix(ConfigurationManager.AppSettings.Get($"M.{sm2}"));
            }

            if ( A.columns != B.rows)
            {
                Console.WriteLine("Для перемножения матриц нужно,чтобы число столбцов матрицы A было равно числу строк матрицы B");
            }
            else
            {
                // нам известна размерность итоговой матрицы, создаем ее
                double[,] m = new double[A.rows, B.columns];

                // B columns
                // для каждой колонки в матрице B нам нужно будет повторить одно и тоже с матрицой A
                // а именно : проходим по каждой строке из матрицы и складываем все значения из каждой колонки, умноженные на значения из колонки матрицы B.
                // номер колонки в А умножается с таким же номером строки в B. Поэтому у нас и проверяется условие, что
                // "нужно,чтобы число столбцов матрицы A было равно числу строк матрицы B"
                for (int bc = 0; bc <= B.columns - 1; bc++)
                {
                    // A rows. Тут проходим по строкам из A
                    for (int ar = 0; ar <= A.rows - 1; ar++)
                    {
                            // A columns = B rows. А тут по всем колонкам из A, а в B по строкам.
                            for (int br = 0; br <= B.rows - 1; br++)
                            {
                                //Console.WriteLine($"{A.M[ar, br]}*{B.M[br, bc]}");
                                m[ar, bc] = m[ar, bc] + (A.M[ar, br] * B.M[br, bc]);
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
