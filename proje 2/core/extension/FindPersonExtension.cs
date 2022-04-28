using System.Collections.Generic;

namespace proje_2.core.extension
{
    public class FindPersonExtension
    {
        public static string findPerson(int personId,List<PersonModel> personList){                        
            foreach (var item in personList)
            {
                if (item.PersonId == personId)
                {
                    return (item.Name + ' ' +item.SurName).ToString();
                }                
            }
            return null;
        }

        public static int findPersonId(int personId,List<PersonModel> personList){                        
            foreach (var item in personList)
            {
                if (item.PersonId == personId)
                {
                    return item.PersonId;
                }                
            }
            return 0;
        }
    }
}