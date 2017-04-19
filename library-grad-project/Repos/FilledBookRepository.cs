using LibraryGradProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryGradProject.Repos
{
    public class FilledBookRepository : IRepository<Book>
    {
        private List<Book> _bookCollection = new List<Book>();

        public FilledBookRepository()
        {

            Book LotR1 = new Book();
            LotR1.ISBN = "0-345-24032-4";
            LotR1.Title = "Lord of the Rings: The Fellowship Of The Ring";
            LotR1.Author = "J.R.R. Tolkien";
            LotR1.PublishDate = "29 July 1954";

            Book LotR2 = new Book();
            LotR2.ISBN = "0-345-33971-1";
            LotR2.Title = "Lord of the Rings: The Two Towers;";
            LotR2.Author = "J.R.R. Tolkien";
            LotR2.PublishDate = "11 November 1954";

            Book LotR3 = new Book();
            LotR3.ISBN = "0-345-24034-0";
            LotR3.Title = "Lord of the Rings: The Return of the King";
            LotR3.Author = "J.R.R. Tolkien";
            LotR3.PublishDate = "20 October 1955";

            this.Add(LotR1);
            this.Add(LotR2);
            this.Add(LotR3);

        }


        public void Add(Book entity)
        {
            entity.Id = _bookCollection.Count;
            _bookCollection.Add(entity);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookCollection;
        }

        public Book Get(int id)
        {
            return _bookCollection.Where(book => book.Id == id).SingleOrDefault();
        }

        public void Remove(int id)
        {
            Book bookToRemove = Get(id);
            _bookCollection.Remove(bookToRemove);
        }
    }
}