using System;
using System.Collections.Generic;

namespace proje_1
{
    public class CrudOperataions
    {

        private CreateNumber createNumber = new CreateNumber();
        private DeleteNumber deleteNumber = new DeleteNumber();
        private UpdateNumber updateNumber = new UpdateNumber();

        private GetList getList = new GetList();
        private FindPersons findPersons = new FindPersons();
        
        

        private static List<NumberModel> list = new List<NumberModel>
        {
            new NumberModel{Name = "Ali", SurName = "Yeniacun",PhoneNumber = "00542162612"},
            new NumberModel{Name = "Selenay", SurName = "Yeniacun",PhoneNumber = "00541113612"},
            new NumberModel{Name = "Can", SurName = "Polat",PhoneNumber = "00542161612"},
            new NumberModel{Name = "Sıla", SurName = "Nehir",PhoneNumber = "00532162612"},
            new NumberModel{Name = "Ada", SurName = "Muş",PhoneNumber = "00542165612"},
        };



        public void create()
        {
            list.Add(createNumber.createNummber());
        }

        public void delete()
        {
            list.Remove(deleteNumber.deletePerson(list));
        }

        public void update()
        {

            NumberModel model = updateNumber.updatePerson(list);

            for (var i = 0; i < list.Count; i++)
            {
                if(list[i].Name.Contains(model.Name)){
                    list[i] = model;                    
                }
            }
        }

        public void getAllList()
        {
            getList.getList(list);
        }

        public void findPersonsList()
        {
            findPersons.findPersons(list);
        }
    }
}