using System;
using System.Collections;

namespace ödev_2
{
    public class Task3
    {

        public static void task3()
        {
            string vowel = "aeıioöuü";
            ArrayList list = new ArrayList();

            Console.WriteLine("Lütfen bir cümle giriniz :");
            string sentence = Console.ReadLine();

            foreach (char item in sentence)
            {
                if (vowel.Contains(item))
                    list.Add(item);
            }

            list.Sort();

            for (var i = 0; i < list.Count; i++)
                Console.WriteLine("Cümle içindeki sesli harf : " + list[i]);

        }

    }
}