using System;
using System.Collections;

namespace ödev_2
{
    public class Task2
    {
        public static void task2()
        {
            int count = 0;
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();

            Console.WriteLine("Lütfen 20 adet sayı giriniz :");
            while (count < 20)
            {
                Console.WriteLine(count + 1 + ". Sayı :");
                String input = Console.ReadLine();
                int output = 0;

                if (int.TryParse(input, out output))
                {
                    list1.Add(output);
                }
                else
                {
                    continue;
                }

                count++;
            }

            list2.AddRange(list1);

            list1.Sort();

            list2.Sort();
            list2.Reverse();

            int avg = 0;

            for (var i = 0; i < list1.Count; i++)
            {
                if (i == 3)
                {
                    break;
                }
                else
                {
                    avg += Convert.ToInt32(list1[i]) + Convert.ToInt32(list2[i]);
                    Console.WriteLine(list1[i]);
                    Console.WriteLine(list2[i]);
                }
            }



            Console.WriteLine("En büyük ve en küçük sayıların toplamlarının ortalaması : " + (avg / 2));

            Console.WriteLine("En büyük ve en küçük sayıların toplamları : " + avg);

        }
    }
}