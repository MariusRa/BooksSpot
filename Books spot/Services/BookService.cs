using Books_spot.DAL;
using Books_spot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Books_spot.Services
{
    public class BookService : IBookService
    {
        private readonly BooksSpotDbContext _db;
        public BookService(BooksSpotDbContext db)
        {
            _db = db;
        }

        public ICollection<Book> GetAllBooks(int page, int size)
        {
            return _db.Books.Skip((page - 1) * size).Take(size).ToList();
        }

        public Book GetBookById(Guid bookId)
        {
            return _db.Books.FirstOrDefault(x => x.BookId == bookId);
        }
               
        public Book BorrowedBook(Guid userId, Guid bookId)
        {
            var book = _db.Books.FirstOrDefault(x => x.BookId == bookId);

            book.BookBorrowed = userId.ToString();

            _db.SaveChanges();

            return book;
        }

        public Book UnBorrowedBook(Guid bookId)
        {
            var book = _db.Books.FirstOrDefault(x => x.BookId == bookId);

            book.BookBorrowed = "";

            _db.SaveChanges();

            return book;
        }

        public Book Reserve(Guid userId, Guid bookId)
        {
            var book = _db.Books.FirstOrDefault(x => x.BookId == bookId);

            book.BookReserved = userId.ToString();

            _db.SaveChanges();

            return book;
        }

        public Book CancelReservation(Guid bookId)
        {
            var book = _db.Books.FirstOrDefault(x => x.BookId == bookId);

            book.BookReserved = "";

            _db.SaveChanges();

            return book;
        }
    }
}
