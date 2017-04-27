using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryGradProject.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base("name=LibraryDb")
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookReservation> BookReservations { get; set; }
    }
}