using System.Collections.Generic;

namespace proje_2
{
    public class BoardModel
    {
        string title;
        string content;
        int personId;
        Size size;

        Boards boards = Boards.TODO;

        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public int PersonId { get => personId; set => personId = value; }
        internal Size Size { get => size; set => size = value; }
        internal Boards Boards { get => boards; set => boards = value; }
    }
}