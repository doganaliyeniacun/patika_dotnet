using System;
using System.Collections.Generic;
using proje_2.core.extension;

namespace proje_2.features.controller
{
    public class GetBoardListController
    {        
        public static void getBoardList(List<BoardModel> boardList,List<PersonModel> personList){            
            foreach (var item in boardList)
            {
                Console.WriteLine("{0} Line",item.Boards);
                Console.WriteLine("************************");
                Console.WriteLine("Başlık      : {0}",item.Title);
                Console.WriteLine("İçerik      : {0}",item.Content);
                Console.WriteLine("Atanan Kişi : {0}",FindPersonExtension.findPerson(item.PersonId,personList));
                Console.WriteLine("Büyüklük    : {0}\n",item.Size);
            }
        }
    }
}

 
 



 