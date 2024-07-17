using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.B;
namespace LibraryProject.M
{
    public class Member
    {
        public string Name;
        public int Id;
        public Dictionary<Book, int> CheckedBooks;
        public Member(string Name)
        {
            CheckedBooks = new Dictionary<Book, int>();
            this.Name = Name;
        }
    }
}
