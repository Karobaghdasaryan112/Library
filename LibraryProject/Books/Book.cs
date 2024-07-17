using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.B
{
    public class Book
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Description { get; private set; }
        public int Checked { get; private set; }
        public Book(int Id,string Title,string Author) { 
            this.Id = Id;
            this.Title = Title;
            this.Author = Author;
            Checked = 0;
        }   
        public void CheckedBook()
        {
           if(Checked == 1)
            {
                Checked = 0;
            }
            Checked = 1;
        }
    }
}
