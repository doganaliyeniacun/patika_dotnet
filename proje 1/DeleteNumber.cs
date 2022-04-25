using System;
using System.Collections.Generic;

namespace proje_1
{
    public class DeleteNumber : SearchManager
    {
        private NumberModel numberModel = new NumberModel();
        private List<NumberModel> list;

        private int chooseOtherMenuIndex;

        private bool checkQuit = true;


        public NumberModel deletePerson(List<NumberModel> list)
        {
            this.list = list;

            while (true)
            {
                if(checkQuit)
                    findPerson();

                if (numberModel != null)
                    return numberModel;
                else
                {

                    chooseOtherMenuIndex = chooseOtherMenu();

                    if (chooseOtherMenuIndex == 1)
                    {
                        break;
                    }
                    else if (chooseOtherMenuIndex == 2)
                    {
                        checkQuit = true;
                        continue;
                    }else{
                        checkQuit = false;
                    }


                }

            }
            return null;

        }

        private int chooseOtherMenu()
        {
            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için      : (2)");

            String input;
            int result;
            input = Console.ReadLine();

            if (int.TryParse(input, out result))
            {
                if (result == 1)
                    return 1;
                else if (result == 2)
                    return 2;
            }
            return 0;
        }

        private void findPerson()
        {
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
            String searchResult = Console.ReadLine();
            numberModel = base.searchPerson(list, searchResult);
        }
    }
}