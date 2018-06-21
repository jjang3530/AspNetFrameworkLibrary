using LibraryApplication.Models;
using System.Data.Entity;

namespace LibraryApplication.Context
{
    public class LibraryDb : DbContext
    {
        public LibraryDb() : base("name=DBCS") { }

        public DbSet<Book> Books { get; set; }

    }
}