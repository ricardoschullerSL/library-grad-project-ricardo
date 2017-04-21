using LibraryGradProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryGradProject.Repos
{
    public class BookReservationRepository : IRepository<BookReservation>
    {
        private List<BookReservation> _bookReservationCollection = new List<BookReservation>();

        public void Add(BookReservation entity)
        {
            List<BookReservation> conflictingReservations = _bookReservationCollection.Where(bookRes => ((bookRes.bookId == entity.bookId) && 
                                                        !((bookRes.endDate < entity.startDate) || (bookRes.startDate > entity.endDate)))).ToList();
            if (conflictingReservations.Count == 0)
            {
                entity.Id = _bookReservationCollection.Count;
                _bookReservationCollection.Add(entity);
            }
            else
            {
                throw new Exception("Conflicting Reservation") ;
            }
        }

        public IEnumerable<BookReservation> GetAll()
        {
            return _bookReservationCollection;
        }

        public BookReservation Get(int id)
        {
            return _bookReservationCollection.Where(bookRes => bookRes.Id == id).SingleOrDefault();
        }

        public void Remove(int id)
        {
            BookReservation reservationToRemove = Get(id);
            _bookReservationCollection.Remove(reservationToRemove);
        }
    }
}