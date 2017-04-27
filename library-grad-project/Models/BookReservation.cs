using System;
using System.Data.Entity;

namespace LibraryGradProject.Models
{
    public class BookReservation
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
