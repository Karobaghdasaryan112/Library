using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.B;
using LibraryProject.L;
using LibraryProject.M;
namespace LibraryProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string NameLibrary = "Armenian Library";
            Libraries library = new Libraries(NameLibrary);
            Member member = new Member("Karo");
            library.NewMember(member);
            foreach (var item in library.BooksAndMembers)
            {
                Console.WriteLine(item.Key.Title);
                Console.Write(item.Value.Name);
            }
            Console.ReadLine();
        }
    }
}
