using System.Collections.Generic;

namespace proje_2
{
    public class PersonModel
    {
        int personId;
        string name;
        string surName;

        public int PersonId { get => personId; set => personId = value; }
        public string Name { get => name; set => name = value; }
        public string SurName { get => surName; set => surName = value; }
    }    
}