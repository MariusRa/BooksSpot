using Books_spot.DTOs;
using Books_spot.Models;
using Books_spot.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books_spot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        public BooksController(IBookService bookService, IUserService userService)
        {
            _bookService = bookService;
            _userService = userService;
        }

        [HttpGet]
        public ICollection<Book> ListBooks()
        {
            return _bookService.GetAllBooks(1, 10);
        }

        [HttpPost("search")]
        public ICollection<Book> SearchBooks(SearchDTO dto)
        {
            var books = _bookService.GetAllBooks(1, 10);

            ICollection<Book> booksCollection = new List<Book>();

            if (!String.IsNullOrEmpty(dto.Search))
            {
                var booksByAuthor = (books.Where(b => b.Author.ToLower().Contains(dto.Search.ToLower())).ToList());
                if (booksByAuthor.Count != 0)
                {
                    foreach (var book in booksByAuthor)
                    {
                        booksCollection.Add(book);
                    }
                }
                var booksByTitle = (books.Where(b => b.Title.ToLower().Contains(dto.Search.ToLower())).ToList());
                if (booksByTitle.Count != 0)
                {
                    foreach (var book in booksByTitle)
                    {
                        booksCollection.Add(book);
                    }
                }
                var booksByPublisher = (books.Where(b => b.Publisher.ToLower().Contains(dto.Search.ToLower())).ToList());
                if (booksByPublisher.Count != 0)
                {
                    foreach (var book in booksByPublisher)
                    {
                        booksCollection.Add(book);
                    }
                }
                var booksByGenre = (books.Where(b => b.Genre.ToLower().Contains(dto.Search.ToLower())).ToList());
                if (booksByGenre.Count != 0)
                {
                    foreach (var book in booksByGenre)
                    {
                        booksCollection.Add(book);
                    }
                }
                var booksByDate = (books.Where(b => b.PublishingDate.ToLower().Contains(dto.Search.ToLower())).ToList());
                if (booksByDate.Count != 0)
                {
                    foreach (var book in booksByDate)
                    {
                        booksCollection.Add(book);
                    }
                }
                var booksByISBN = (books.Where(b => b.ISBN10.ToLower().Contains(dto.Search.ToLower())).ToList());
                if (booksByISBN.Count != 0)
                {
                    foreach (var book in booksByISBN)
                    {
                        booksCollection.Add(book);
                    }
                }
            }

            return booksCollection;
        }

        [HttpPost("status")]
        public ICollection<Book> SearchBooksStatus(StatusDTO dto)
        {
            if (!dto.IsBorrowed)
            {
                var freeBooks = _bookService.GetAllBooks(1, 10).Where(x => x.BookBorrowed == "").ToList();

                return freeBooks;
            }

            var allBooks = _bookService.GetAllBooks(1, 10);

            return allBooks;
        }

        [HttpPost("borrow")]
        public IActionResult BorrowBook(BorrowDTO dto)
        {
            var user = _userService.GetUserById(dto.UserId);
            if (user == null) return BadRequest(new { message = "User not exists" });
            var book = _bookService.GetBookById(dto.BookId);

            if (book.BookBorrowed == "")
            {
                _bookService.BorrowedBook(dto.UserId, dto.BookId);

                return Ok(new
                {
                    message = "Book was borrowed successfully"
                });
            }
            else if (book.BookBorrowed == user.UserId.ToString() || user.Role == "Admin")
            {
                _bookService.UnBorrowedBook(dto.BookId);

                return Ok(new
                {
                    message = "Book was returned successfully"
                });
            }

            return Ok(new
            {
                message = "Book is borrowed by other reader"
            });
        }

        [HttpPost("reserve")]
        public IActionResult ReservedBook(ReserveDTO dto)
        {
            var user = _userService.GetUserById(dto.UserId);
            if (user == null) return BadRequest(new { message = "User not exists" });
            var book = _bookService.GetBookById(dto.BookId);

            if (book.BookReserved == "")
            {
                _bookService.Reserve(dto.UserId, dto.BookId);

                return Ok(new
                {
                    message = "Book was reserved successfully"
                });
            }
            else if (book.BookReserved == user.UserId.ToString() || user.Role == "Admin")
            {
                _bookService.CancelReservation(dto.BookId);

                return Ok(new
                {
                    message = "Reservation was canceled successfully"
                });
            }

            return Ok(new
            {
                message = "Book is reserved by other reader"
            });
        }
    }
}
