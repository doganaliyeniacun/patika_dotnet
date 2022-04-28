using System;
using System.Collections.Generic;
using proje_2.core.extension;

namespace proje_2.features.controller
{
    public class AddBoardCartController
    {

        public BoardModel addBoardCart(List<PersonModel> list)
        {
            return boardCartMenu(list);
        }

        private BoardModel boardCartMenu(List<PersonModel> list)
        {

            BoardModel boardModel = new BoardModel();
            int sizeId = 0;
            int personId;

            Console.WriteLine("Başlık Giriniz                                  :");
            boardModel.Title = Console.ReadLine();

            Console.WriteLine("İçerik Giriniz                                  :");
            boardModel.Content = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Lütfen büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :");
                int.TryParse(Console.ReadLine(), out sizeId);
                if (sizeId >= 1 && sizeId <= 5)
                {
                    boardModel.Size = (Size)sizeId;
                    break;
                }
                else
                {
                    continue;
                }
            }

            while (true)
            {
                Console.WriteLine("Kişi Seçiniz(ID)                                       :");
                int.TryParse(Console.ReadLine(), out personId);

                int findId = FindPersonExtension.findPersonId(personId, list);

                if (findId != 0)
                {
                    boardModel.PersonId = personId;
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı girişler yaptınız!");
                    break;
                }
            }

            return boardModel;
        }
    }
}




