using System;
using System.Collections.Generic;

namespace proje_1
{
    public class Menu
    {
        CrudOperataions crudOperataions = new CrudOperataions();
        private int itemNumber;

        private int ItemNumber
        {
            get => itemNumber;
            set
            {
                if (value < 1 || value > 5)
                    itemNumber = 0;
                else
                    itemNumber = value;
            }
        }

        public void chooseMenuItems()
        {
            MenuItems menuItems = new MenuItems();

            while (true)
            {
                getMenuItems();
                ItemNumber = (int)Extensions.ParseInt32(Console.ReadLine());
                menuItems = (MenuItems)ItemNumber;

                switch (menuItems)
                {
                    case MenuItems.Create:
                        crudOperataions.create();
                        break;
                    case MenuItems.Delete:
                        crudOperataions.delete();
                        break;
                    case MenuItems.Update:
                        crudOperataions.update();
                        break;
                    case MenuItems.GetList:
                        crudOperataions.getAllList();
                        break;
                    case MenuItems.SearchList:
                        crudOperataions.findPersonsList();
                        break;
                    default:
                        break;
                }

                
            }



        }

        private void getMenuItems()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) ");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak﻿");
        }
    }
}







