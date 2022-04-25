using System;
using System.Collections.Generic;

namespace proje_1
{
    public class GetList
    {
        public void getList(List<NumberModel> list){
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("*******************************************");
            for (var i = 0; i < list.Count; i++)
            {
                Console.WriteLine("İsim : {0}",list[i].Name);
                Console.WriteLine("Soyisim : {0}",list[i].SurName);
                Console.WriteLine("Telefon numarası : {0}",list[i].PhoneNumber);
                Console.WriteLine("-");
            }
            
        }
    }
}