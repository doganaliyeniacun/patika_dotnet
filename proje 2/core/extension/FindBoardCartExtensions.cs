using System;
using System.Collections.Generic;

namespace proje_2.core.extension
{
    public class FindBoardCartExtensions
    {
        public static BoardModel findBoardCart(String input,List<BoardModel> list){
            for (var i = 0; i < list.Count; i++)
            {
                bool checkTitle = list[i].Title.ToLower().Contains(input) || list[i].Title.ToUpper().Contains(input);
                if (checkTitle)
                {
                    return list[i];
                }

            }

            return null;
        }
    }
}