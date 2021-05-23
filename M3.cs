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
                double d = determinant(A);
                Console.WriteLine("A:");
                A.print_matrix();
                Console.WriteLine($"Determinant:\n{d}");
                if ( d == 0 )
                {
                    Console.WriteLine("Определитель равен нулю. Обратной матрицы не существует.");
                } else
                {
                   
                }

            }

        }

        // нахождение определителя по статье - http://www.mathprofi.ru/kak_vychislit_opredelitel.html
        // базовая функция для определителя 2-го уровня. К ней будем прибегать, вычисляя в рекурсии определите миноров в массивах урояня больше 2.
        // проверку на ошибки НЕ делаем
        double determinant_2(_matrix m)
        {
            double d = 0;
            // проверка 2 на 2
            if (m.columns == 2 && m.rows == 2) {
                d = (m.M[0, 0] * m.M[1, 1]) - (m.M[1, 0] * m.M[0, 1]);
            } else
            {
                d = 0;
            }            
            return d;
        }

        // нахождение определителя в рекурсивном цикле для матрицы любого порядка
        // проверку на ошибки НЕ делаем
        // определитель решаем, раскрыв его по 0 (1-й) строке.
        double determinant(_matrix m)
        {
            double d = 0;
            int z;
            if ( m.columns == m.rows )
            {                               
                if (m.columns == 2 )
                {
                    // если это матрица 2 на 2, то получаем определитель из базовой функции
                    d = determinant_2(m);
                } else
                {
                    // пороход по колонкам первой строки матрицы
                    for (int c = 0; c < m.columns; c++)
                    {
                        // первая строка у нас по знакам будет: + - + - + ... 
                        // знаки чередуются, поэтому 1 колонка - это нечетное число (знак +), 2я- четное (знак -) и так далее
                        z = (c + 1) % 2 == 0 ? -1 : 1;

                        // собственно само число из 0й строки и c-ой колонки. сразу помножим на знак.
                        double v = z * m.M[0, c];

                        // теперь создаем новый массив c-1 на r-1
                        // т.е. создаем класс и удаляем 0 строку и c-ю колонку
                        _matrix T = new _matrix(m.M);
                        T.delete_row(0);
                        T.delete_column(c);          

                        // вызывем себя, пока не дойдем до базовой функции 2-го порядка
                        // не забываем результаты сумировать с учетом знака
                        double dminor = determinant(T);                        
                        d = d + (dminor * v);
                    }
                }
            } else
            {
                d = 0;
            }

            return d;
        }

    }
}
