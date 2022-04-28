using System;

namespace proje_2
{
    public class MainMenu
    {
        CrudOpertations crudOpertations = new CrudOpertations();
        public void mainMenu(){
           mainMenuManegement();
        }
        
         private void mainMenuManegement(){
            while (true)
            {                
                mainMenuItems();
                mainMenuSelected();
            }
        }

        private void mainMenuSelected(){
            int output;
            int.TryParse(Console.ReadLine(),out output);

            switch (output)
            {
                case 1:
                    Console.Clear();
                    crudOpertations.getBoardList();
                    break;
                case 2:
                    Console.Clear();
                    crudOpertations.addBoardCard();
                    break;
                case 3:
                    Console.Clear();
                    crudOpertations.deleteBoardCard();
                    break;
                case 4:
                    Console.Clear();
                    crudOpertations.transportBoardCard();
                    break;
                default:
                    Console.Clear();
                    break;
            }
            
        }

        private void mainMenuItems(){
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) ");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
        }

       

        

    }
}

  
  
  
  
  
  