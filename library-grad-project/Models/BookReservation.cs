using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryGradProject.Models
{
    public class BookReservation
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
