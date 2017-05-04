using LibraryGradProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Data.Entity;

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
            using (ILibraryDbContext db = _dbContextFactory.GetDbContext())
            {
                Debug.WriteLine("BookReservation started...");
                try
                {
                    var currentReservations = db.Books.Where(b => b.Id == entity.BookId).Include("BookReservations").FirstOrDefault().BookReservations;
                    Debug.WriteLine("Got current reservations");
                    List<BookReservation> conflictingReservations = currentReservations.Where(bookRes => !((bookRes.EndDate < entity.StartDate) || (bookRes.StartDate > entity.EndDate))).ToList();
                    Debug.WriteLine(conflictingReservations.ToString());
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
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }
            }
            
        }

        public IEnumerable<BookReservation> GetAll()
        {
            using (ILibraryDbContext db = _dbContextFactory.GetDbContext())
            {
                return db.BookReservations.ToList();
            }
        }

        public BookReservation Get(int id)
        {
            using (ILibraryDbContext db = _dbContextFactory.GetDbContext())
            {
                BookReservation bres = db.BookReservations.Find(id);
                return bres;
            }
        }

        public void Remove(int id)
        {
            using (ILibraryDbContext db = _dbContextFactory.GetDbContext())
            {
                BookReservation bres = db.BookReservations.Find(id);
                db.BookReservations.Remove(bres);
                db.SaveChanges();
            }
        }
    }
}