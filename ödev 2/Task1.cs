using System;
using System.Collections;

namespace ödev_2
{
    public class Task1
    {
        public static void task1()
        {
            ArrayList primeList = new ArrayList();
            ArrayList primeListN = new ArrayList();

            int count = 0;

            Console.WriteLine("Lütfen 20 adet pozitif sayı giriniz :");

            while (count < 20)
            {
                Console.WriteLine(count + 1 + ". Sayı :");
                String input = Console.ReadLine();
                int result = 0;
                int x = 2;


                if (int.TryParse(input, out result) && result > 0)
                {
                    result = Convert.ToInt32(input);

                    if (result % x != 0)
                    {
                        primeList.Add(result);
                    }
                    else
                    {
                        primeListN.Add(result);
                    }

                    x++;
                }
                else
                {
                    Console.WriteLine("Lütfen pozitif bir sayı giriniz..");
                    continue;
                }


                count++;
            }

            primeList.Sort();
            primeListN.Sort();

            primeList.Reverse();
            primeListN.Reverse();

            int avg = 0;
            
            foreach (int item in primeList)
            {
                Console.WriteLine("Asal olan sayı : "+ item);
                avg += item;
                
            }
            
            foreach (int item in primeListN)
            {
                Console.WriteLine("Asal olmayan sayı : "+ item);
                avg += item;
            }
            
            Console.WriteLine("Ortalaması : " + (avg / 2));
        }
    }
}