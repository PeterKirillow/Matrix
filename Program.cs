using System;

namespace Matrix
{
    class Program
    {
        private static int input_mode;

        // http://mathprofi.ru/deistviya_s_matricami.html
        /****************************************************************************/
        static void Main()        
        {
            int choose = 0;

            // выбор способа ввода
            bool b = true;
            Console.WriteLine("Выберите способ ввода:");
            Console.WriteLine("1) Из конфигурационного файла");
            Console.WriteLine("2) Из коммандной строки");
            while (b)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        input_mode = 1;
                        b = false;
                        break;
                    case "2":
                        input_mode = 0;
                        b = false;
                        break;
                    default:
                        break;
                }
            }

            while (choose != 6)
            {
                Console.Clear();
                Console.WriteLine("Программа автоматизации действий над матрицами");
                Console.WriteLine("==============================================");

                choose = menu();

                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Сложение матриц");
                        M1 M1_1 = new M1(input_mode, 1,"A","B");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Вычитание матриц");
                        M1 M1_2 = new M1(input_mode, 2,"A", "B");
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Умножение матрицы на число");
                        M2 M2 = new M2(input_mode, "A");
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Перемножение матриц");
                        M4 M4 = new M4(input_mode, "A", "B");
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Нахождение обратной матрицы");
                        M3 M3 = new M3(input_mode, "D3");
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Вы ввели некорректное значение при выборе пункта меню.");
                        break;
                }
                if (choose != 6) {
                    Console.WriteLine("Нажмите Enter для продолжения...");
                    Console.ReadLine();
                }
            }
        }

        static int menu()
        {
            Console.Clear();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1) Сложение матриц");
            Console.WriteLine("2) Вычитание матриц");
            Console.WriteLine("3) Умножение матрицы на число");
            Console.WriteLine("4) Перемножение матриц");
            Console.WriteLine("5) Нахождение обратной матрицы");
            Console.WriteLine("6) Выход");
            Console.Write("\r\nВведите число от 1 до 6: ");
            return Convert.ToInt16(Console.ReadLine());
        }
    }
}
