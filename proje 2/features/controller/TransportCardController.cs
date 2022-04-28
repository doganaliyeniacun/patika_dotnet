using System;
using System.Collections.Generic;
using proje_2.core.extension;

namespace proje_2.features.controller
{
    public class TransportCardController
    {
        public BoardModel transportBoardCartController(List<BoardModel> boardList, List<PersonModel> personList)
        {
            return transpordCartManegement(boardList, personList);
        }

        private void transpordCartMenu()
        {
            Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
            Console.WriteLine("Lütfen kart başlığını yazınız: ");
        }

        private void chooseOtherMenu()
        {
            Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için : (2)");
        }

        private void findingCard(BoardModel boardModel, List<PersonModel> personList)
        {
            Console.WriteLine("Bulunan Kart Bilgileri:");
            Console.WriteLine("**************************************");
            Console.WriteLine("Başlık      : {0}", boardModel.Title);
            Console.WriteLine("İçerik      : {0}", boardModel.Content);
            Console.WriteLine("Atanan Kişi : {0}", FindPersonExtension.findPerson(boardModel.PersonId, personList));
            Console.WriteLine("Büyüklük    : {0}", boardModel.Size);
            Console.WriteLine("Line        : {0}", boardModel.Boards);
            Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz:\n");
            Console.WriteLine("(1) TODO");
            Console.WriteLine("(2) IN PROGRESS");
            Console.WriteLine("(3) DONE");
        }

        private BoardModel findingCardManegement(BoardModel boardModel, List<PersonModel> personList)
        {
            int output = 0;

            Console.Clear();

            findingCard(boardModel, personList);
            int.TryParse(Console.ReadLine(), out output);

            if (output >= 1 || output <= 3)
            {
                boardModel.Boards = (Boards)output;
                return boardModel;
            }
            else
            {
                Console.WriteLine("Hatalı bir seçim yaptınız!");
                return null;
            }

        }


        private BoardModel transpordCartManegement(List<BoardModel> boardList, List<PersonModel> personList)
        {
            while (true)
            {
                Console.Clear();

                transpordCartMenu();

                String input = Console.ReadLine();
                bool checkBoardCart = FindBoardCartExtensions.findBoardCart(input, boardList) != null ? true : false;

                if (checkBoardCart)
                {
                    BoardModel boardModel;
                    boardModel = FindBoardCartExtensions.findBoardCart(input, boardList);
                    return findingCardManegement(boardModel,personList);
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