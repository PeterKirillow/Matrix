using System;

namespace Matrix
{
    class Program
    {
        // http://mathprofi.ru/deistviya_s_matricami.html
        /****************************************************************************/
        static void Main()
        {
            // сложение/вычитание матриц
            //Console.WriteLine("сложение");
            //M1 M1_1 = new M1(1);

            //Console.WriteLine("вычитание");
            //M1 M1_2 = new M1(2);

            // умножение матрицы на число
            //Console.WriteLine("умножение матрицы на число");
            //M2 M2_1 = new M2("A");

            // обратная матрица - http://mathprofi.ru/kak_naiti_obratnuyu_matricu.html
            //Console.WriteLine("нахождение обратной матрицы");
            //M3 M3_1 = new M3("D11");
            //M3 M3_1 = new M3("D11");
            M3 M3_1 = new M3(10, 10, 10);
            M3_1.calc();

            // перемножение матриц
            //Console.WriteLine("перемножение матриц");
            //M4 M4_1 = new M4("C1","C2");
            //M4 M4_1 = new M4("C3", "C5");
        }
    }
}
