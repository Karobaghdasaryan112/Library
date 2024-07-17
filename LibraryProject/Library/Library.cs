using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.M;
using LibraryProject.B;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Reflection;
namespace LibraryProject.L
{
    public class Libraries
    {
        Random random = new Random();
        public string Name { get; private set; }
        public Dictionary<Book, Member> BooksAndMembers { get; private set; }
        public List<Member> Members { get; private set; }
        public List<Book> Books { get; private set; }
        public int MaxBookCount { get; private set; }
        public int MaxMembersCount { get; private set; }

        public int value { get; private set; }

        public Libraries(string Name)
        {
            this.Name = Name;
            MaxBookCount = 1000;
            MaxMembersCount = 20;
            Members = new List<Member>();
            Books = new List<Book>();
            BooksAndMembers = new Dictionary<Book, Member>();
            List<string> bookTitles = new List<string>
            {
                "To Kill a Mockingbird", "1984", "The Great Gatsby", "Pride and Prejudice",
                "The Catcher in the Rye", "Moby-Dick", "Brave New World", "Jane Eyre",
                "The Lord of the Rings", "The Alchemist"
            };
            List<string> authors = new List<string>
            {
                "Harper Lee", "George Orwell", "F. Scott Fitzgerald", "Jane Austen",
                "J.D. Salinger", "Herman Melville", "Aldous Huxley", "Charlotte Brontë",
                "J.R.R. Tolkien", "Paulo Coelho"
             };
            for (int i = 0; i < bookTitles.Count; i++)
            {
                Books.Add(new Book(i, bookTitles[i], authors[i]));
                
            }
        }
        public bool ValidMember(Member member)
        {
            if (string.IsNullOrWhiteSpace(member.Name))
            {
               return false;
            }
                return true;
        }
        public void AddBook(string bookTitle, string author)
        {
            if (string.IsNullOrWhiteSpace(bookTitle) || string.IsNullOrWhiteSpace(author))
            {
                throw new Exception("invalid book");
            }
            if (Books.Count == MaxBookCount)
            {
                MaxBookCount *= 2;
            }
            foreach (var Book in Books)
            {
                if (Book.Author == author)
                {
                    throw new Exception($"Book {bookTitle} is already registered");
                }
            }
            Books.Add(new Book(Books.Count + 1, bookTitle, author));
        }
        public void RemoveBook(string bookTitle)
        {
            foreach (var Book in Books)
            {
                if (Book.Title == bookTitle)
                {
                    Books.Remove(Book);
                    return;
                }
            }
            throw new Exception("this book isn't registered in Library");
        }

        public Member NewMember(Member member)
        {
            if (ValidMember(member))
            {
                while (true)
                {
                    int index = random.Next(0, Books.Count);
                    if (Books[index].Checked == 1)
                    {
                        continue;
                    }
                    else
                    {
                        member.CheckedBooks.Add(key: Books[index], value: 1);
                        BooksAndMembers.Add(key: Books[index], value: member);
                        break;
                    }
                }
                Members.Add(member);
                return member;
            }
            return null;
        }
        public List<Book> TakeBook(Member member,Book book)
        {
            if (ValidMember(member))
            {
                foreach (var thisBook in Books)
                {
                    if(book == thisBook)
                    {
                        if(thisBook.Checked == 0)
                        {
                            thisBook.CheckedBook();
                            member.CheckedBooks.Add(key: thisBook, value: 1);
                            BooksAndMembers.Add(key: thisBook, value: member);
                        }
                    }
                }
            }
            return Books;
        }
        public List<Book> ReturnBook(Member member, Book book)
        {
            if (ValidMember(member))
            {
                foreach (var thisBook in Books)
                {
                    if (book == thisBook)
                    {
                        if (thisBook.Checked == 1)
                        {
                            thisBook.CheckedBook();
                            member.CheckedBooks.Remove(key: thisBook);
                            BooksAndMembers.Remove(key: thisBook);
                        }
                    }
                }
            }
            return Books;
        }
    }
}
