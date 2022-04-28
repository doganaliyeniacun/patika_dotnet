using System;
using System.Collections.Generic;
using proje_2.core.extension;

namespace proje_2.features.controller
{
    public class DeleteBoardCartController
    {
        public BoardModel deleteBoardCartController(List<BoardModel> list)
        {
            return deleteBoardCardManegement(list);
        }

        private void deleteBoardCartMenu()
        {
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.WriteLine("Lütfen kart başlığını yazınız: ");
        }

        private static void chooseOtherMenu()
        {
            Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için : (2)");
        }

        private BoardModel deleteBoardCardManegement(List<BoardModel> list)
        {
            while (true)
            {
                Console.Clear();

                deleteBoardCartMenu();

                String input = Console.ReadLine();
                bool checkBoardCart = FindBoardCartExtensions.findBoardCart(input, list) != null ? true : false;

                if (checkBoardCart)
                {
                    return FindBoardCartExtensions.findBoardCart(input, list);
                }
                else
                {
                    int output = 0;
                    while (output < 1 || output > 2)
                    {
                        Console.Clear();
                        chooseOtherMenu();

                        int.TryParse(Console.ReadLine(), out output);
                    }

                    if (output == 1)
                    {
                        Console.Clear();
                        break;
                    }
                    else if (output == 2)
                    {
                        continue;
                    }
                }
            }
            return null;
        }

        
    }
}


