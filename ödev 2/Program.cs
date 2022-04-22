using System;
using System.Collections;

namespace ödev_2
{
    class Program
    {
        static void Main(string[] args)
        {
            menu();
        }

        private static void menu()
        {
            int x = 0;

            while (x < 1 || x >= 4)
            {
                Console.WriteLine("Lütfen ödev seçiniz(1-2-3) :");
                String input = Console.ReadLine();

                if (int.TryParse(input, out x))
                {
                    x = Convert.ToInt32(input);
                }
                else
                {
                    continue;
                }

            }

            switch (x)
            {
                case 1:
                    Task1.task1();
                    break;
                case 2:
                    Task2.task2();
                    break;
                case 3:
                    Task3.task3();
                    break;
            }
        }


    }
}
