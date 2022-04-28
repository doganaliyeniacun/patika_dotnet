using System;
using System.Collections.Generic;
using proje_2.core.extension;
using proje_2.features.controller;

namespace proje_2
{
    public class CrudOpertations
    {
        private List<PersonModel> personList = new List<PersonModel>
        {
            new PersonModel{ PersonId = 1 ,Name= "Doğan Ali", SurName = "Yeniacun" },
            new PersonModel{ PersonId = 2 ,Name= "Ali", SurName = "Yeniacun" },
            new PersonModel{ PersonId = 3 ,Name= "Selenay", SurName = "Yeniacun" },
            new PersonModel{ PersonId = 4 ,Name= "Samuray", SurName = "Koç" },
            new PersonModel{ PersonId = 5 ,Name= "Veli", SurName = "Kılınç" }
        };

        private List<BoardModel> boardList = new List<BoardModel>
        {
            new BoardModel{Title = "Test", Content = "içertik test",Size = Size.S,PersonId = 1},
            new BoardModel{Title = "Deneme", Content = "içertik test",Size = Size.S,PersonId = 2,Boards = Boards.INPROGRESS},
        };

        AddBoardCartController addBoardCartController = new AddBoardCartController();
        DeleteBoardCartController deleteBoardCartController = new DeleteBoardCartController();
        TransportCardController transportCardController = new TransportCardController();

        public void getBoardList()
        {
            Console.Clear();
            GetBoardListController.getBoardList(boardList, personList);
        }

        public void addBoardCard()
        {
            Console.Clear();
            boardList.Add(addBoardCartController.addBoardCart(personList));
        }

        public void deleteBoardCard()
        {
            Console.Clear();
            boardList.Remove(deleteBoardCartController.deleteBoardCartController(boardList));
        }

        public void transportBoardCard()
        {
            Console.Clear();
            BoardModel transporBoardModel = transportCardController.transportBoardCartController(boardList, personList);
            
            for (int i = 0; i < boardList.Count; i++)
            {
                if(boardList[i].Title == transporBoardModel.Title)
                    boardList[i] = transporBoardModel;
            }
            

                
        }
    }
}