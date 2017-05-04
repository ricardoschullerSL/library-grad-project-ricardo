using System;
using System.Data.Entity;

namespace LibraryGradProject.Models
{
    public class LibraryDbContext : DbContext, ILibraryDbContext
    {
        public LibraryDbContext() : base("name=LibraryDb")
        {
            
        }

        public virtual IDbSet<Book> Books { get; set; }
        public virtual IDbSet<BookReservation> BookReservations { get; set; }
    }
}