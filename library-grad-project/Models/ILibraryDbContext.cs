using System.Data.Entity;
using System;

namespace LibraryGradProject.Models
{
    public interface ILibraryDbContext: IDisposable
    {
        IDbSet<Book> Books { get; set; }
        IDbSet<BookReservation> BookReservations { get; set; }
        int SaveChanges();
    }
}
