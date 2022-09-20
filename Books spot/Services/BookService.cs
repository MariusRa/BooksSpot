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
            return _db.Books.Include(u => u.BookStatuses).Skip((page - 1) * size).Take(size).ToList();
        }

        public Book GetBookById(Guid bookId)
        {
            return _db.Books.Include(x => x.BookStatuses).FirstOrDefault(x => x.BookId == bookId);
        }

        public ICollection<BookStatus> GetBookReservations(Guid id)
        {
            return _db.BookStatuses.Where(x => x.BookId == id).ToList();
        }
        public Book BorrowedBook(Guid userId, Guid bookId)
        {
            var book = _db.Books.FirstOrDefault(x => x.BookId == bookId);

            book.UserId = userId;

            _db.SaveChanges();

            return book;
        }

        public Book UnBorrowedBook(Guid bookId)
        {
            var book = _db.Books.FirstOrDefault(x => x.BookId == bookId);

            book.UserId = Guid.Empty;

            _db.SaveChanges();

            return book;
        }

        public BookStatus Reserve(BookStatus bookStatus)
        {
            _db.BookStatuses.Add(bookStatus);
            _db.SaveChanges();

            return bookStatus;
        }


        public BookStatus CancelReservation(BookStatus bookStatus)
        {
            _db.BookStatuses.Remove(bookStatus);
            _db.SaveChanges();

            return bookStatus;
        }
    }
}
