using System;
using System.Collections.Generic;

namespace proje_1
{
    public class SearchManager
    {
        protected NumberModel searchPerson(List<NumberModel> list , String searchResult)
        {            
            if (searchResult != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Name.Contains(searchResult) || list[i].SurName.Contains(searchResult))
                    {
                        return list[i];
                    }

                }            
            }
            return null;
        }
    }
}