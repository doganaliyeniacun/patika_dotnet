using System;

namespace proje_1
{
    public class CreateNumber
    {
        private NumberModel numberModel = new NumberModel();
                
        public NumberModel createNummber(){
            getCreateMenu();
            return numberModel;
        }

        private void getCreateMenu(){
            Console.WriteLine("Lütfen isim giriniz :");
            numberModel.Name = Console.ReadLine();
            Console.WriteLine("Lütfen soyisim giriniz :");
            numberModel.SurName = Console.ReadLine();
            Console.WriteLine("Lütfen telefon numarası giriniz :");
            numberModel.PhoneNumber = Console.ReadLine();
        }
    }
}

 
 
 