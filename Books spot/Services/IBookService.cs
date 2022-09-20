using Books_spot.Models;

namespace Books_spot.Services
{
    public interface IBookService
    {
        ICollection<Book> GetAllBooks(int page, int size);
        Book GetBookById(Guid bookId);
        ICollection<BookStatus> GetBookReservations(Guid id);
        Book BorrowedBook(Guid userId, Guid bookId);
        Book UnBorrowedBook(Guid bookId);
        BookStatus Reserve(BookStatus bookStatus);
        BookStatus CancelReservation(BookStatus bookStatus);
    }
}
