using System;
namespace LibraryGradProject.Models
{
    public class BookReservation
    {
        public int Id { get; set; }
        public int bookId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
