using System;
using System.Collections.Generic;

namespace proje_1
{
    public class FindPersons : GetList
    {
        private List<NumberModel> inputList = new List<NumberModel>();
        private List<NumberModel> outputList = new List<NumberModel>();

        public List<NumberModel> findPersons(List<NumberModel> list)
        {
            inputList = list;
            menu();
            return outputList;
        }

        private void menu()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
            Console.WriteLine("**********************************************");
            Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");

            String input = Console.ReadLine();
            int output;

            if (int.TryParse(input, out output))
            {
                if (output == 1)
                {
                    findMenu(output);
                    base.getList(outputList);
                }
                else if (output == 2)
                {
                    findMenu(output);
                    base.getList(outputList);
                }
                else
                {
                    menu();
                }

            }
            else
            {
                menu();
            }


        }

        private void findMenu(int menuChoose)
        {
            String input;

            if (menuChoose == 1)
            {
                Console.WriteLine("İsim veya soyisim giriniz : ");
                input = Console.ReadLine();
                findNameOrSurname(input);
            }
            else if (menuChoose == 2)
            {
                Console.WriteLine("Telefon numarası giriniz : ");
                input = Console.ReadLine();
                findPhoneNumber(input);

            }


        }

        private void findNameOrSurname(String nameOrSurname)
        {
            for (int i = 0; i < inputList.Count; i++)
            {
                bool checkNameOrSurName = inputList[i].Name.Contains(nameOrSurname) || inputList[i].SurName.Contains(nameOrSurname);

                if (checkNameOrSurName)
                {
                    outputList.Add(inputList[i]);
                }
            }
        }

        private void findPhoneNumber(String phoneNumber)
        {
            for (int i = 0; i < inputList.Count; i++)
            {
                bool checkPhoneNumber = inputList[i].PhoneNumber.Contains(phoneNumber);

                if (checkPhoneNumber)
                {
                    outputList.Add(inputList[i]);
                }
            }
        }
    }
}