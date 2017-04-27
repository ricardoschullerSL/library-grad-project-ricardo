using LibraryGradProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryGradProject.Repos
{
    public class BookReservationRepository : IRepository<BookReservation>
    {

        private DbContextFactory _dbContextFactory;

        public BookReservationRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        
        

        public void Add(BookReservation entity)
            {
            using (LibraryDbContext db = _dbContextFactory.GetDbContext())
            {
                Book _book = db.Books.Find(entity.BookId);
                ICollection<BookReservation> currentReservations = _book.BookReservations;
             
                List<BookReservation> conflictingReservations = currentReservations.Where(bookRes => !((bookRes.EndDate < entity.StartDate) || (bookRes.StartDate > entity.EndDate))).ToList();
                if (conflictingReservations.Count == 0)
                {
                    if (entity.StartDate <= entity.EndDate)
                    {
                        db.BookReservations.Add(entity);
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Book reservation End date before Start date");
                    }
                }
                else
                {
                    throw new Exception("Conflicting Reservation");
                }
            }
            
        }

        public IEnumerable<BookReservation> GetAll()
        {
            using (LibraryDbContext db = _dbContextFactory.GetDbContext())
            {
                return db.BookReservations.ToList();
            }
        }

        public BookReservation Get(int id)
        {
            using (LibraryDbContext db = _dbContextFactory.GetDbContext())
            {
                BookReservation bres = db.BookReservations.Find(id);
                return bres;
            }
        }

        public void Remove(int id)
        {
            using (LibraryDbContext db = _dbContextFactory.GetDbContext())
            {
                BookReservation bres = db.BookReservations.Find(id);
                db.BookReservations.Remove(bres);
                db.SaveChanges();
            }
        }
    }
}