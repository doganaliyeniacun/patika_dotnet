using System;

namespace ödev_1
{
    class Program
    {
        static void Main(string[] args)
        {
            soruMenu();
        }

        private static void soruMenu(){
            byte i = 0;
            
            while (i < 1 || i > 5)
            {
                Console.WriteLine("Lütfen bir soru seçiniz(1,2,3,4) : ");
                i = Convert.ToByte(Console.ReadLine());

                switch (i)
                {
                    case 1:
                        birinciSoru();
                        break;
                    case 2:
                        ikinciSoru();
                        break;
                    case 3:
                        ucuncuSoru();
                        break;
                    case 4:
                        dorduncuSoru();
                        break;
                }
            }
        }


        private static void birinciSoru(){
            Console.WriteLine("Lütfen pozitif bir sayı giriniz :");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Kaç adet sayı girmek istiyorsunuz :");
            int y = Convert.ToInt32(Console.ReadLine());
            int[] list = new int[y];


            for (int i = 0; i < y; i++)
            {
                Console.WriteLine(i+1 +".Sayi :");
                list[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] % 2 == 0)
                {
                    Console.WriteLine("Çift sayı :"+ list[i]);    
                }
                
            }
        }


        private static void ikinciSoru(){
            Console.WriteLine("Pozitif iki sayı giriniz..");
            
            Console.WriteLine("Birinci sayı :");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("İkinci sayı :");
            int y = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Kaç adet sayı girmek istiyorsunuz :");
            int count = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[count];

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(i+1 +".sayi :");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            foreach (var item in numbers)
            {
                if (item == y)
                {
                    Console.WriteLine("Eşit olan sayı :" + item);
                }
                else if (item % 2 == 0)
                {
                    Console.WriteLine("Tam bölünen sayı :" + item);
                }
            }
        }

        private static void ucuncuSoru(){
            Console.WriteLine("Pozitif bir sayı giriniz :");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(x + " adet kelime giriniz :");

            string[] y = new string[x];


            for (int i = 0; i < y.Length; i++)
            {
                Console.WriteLine(i+1 + ". kelime :");
                y[i] = Console.ReadLine();
            }

            Array.Reverse(y);

            foreach (var item in y)
            {
                Console.WriteLine(item);
            }
        }


        private static void dorduncuSoru(){
            Console.WriteLine("Lütfen bir cümle yazınız :");
            String x = Console.ReadLine();
            
            int word = x.Split(' ').Length;
            int character = x.Length;

            Console.WriteLine("Cümle "+ word +" Kelimeden oluşuyor.");
            Console.WriteLine("Cümle "+ character +" harften oluşuyor.");
                     
        }
    }
}
