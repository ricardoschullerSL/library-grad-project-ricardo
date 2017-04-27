using LibraryGradProject.Models;
using LibraryGradProject.Repos;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace LibraryGradProject.Controllers
{
    public class BookReservationsController : ApiController
    {
        private IRepository<BookReservation> _bookReservationRepo;

        public BookReservationsController(IRepository<BookReservation> bookReservationRepository)
        {
            _bookReservationRepo = bookReservationRepository;
        }
 
        // GET api/bookreservations
        public IEnumerable<BookReservation> Get()
        {
            return _bookReservationRepo.GetAll();
        }

        // GET api/bookreservations/{int}
        public BookReservation Get(int id)
        {
            return _bookReservationRepo.Get(id);
        }

        // POST api/bookreservations
        public void Post(BookReservation newReservation)
        {
            try
            {
                _bookReservationRepo.Add(newReservation);

            }
            catch(Exception e)
            {
                Console.WriteLine("User tried to make a conflicting book reservation", e);

            }
        }

        // PUT api/bookreservations/{int}
        public void Put(BookReservation newReservation)
        {
            _bookReservationRepo.Remove(newReservation.Id);
            _bookReservationRepo.Add(newReservation);
        }

        // DELETE api/bookreservations/{int}
        public void Delete(int id)
        {
            _bookReservationRepo.Remove(id);
        }
    }
}