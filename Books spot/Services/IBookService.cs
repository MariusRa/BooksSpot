using Books_spot.Models;

namespace Books_spot.Services
{
    public interface IBookService
    {
        ICollection<Book> GetAllBooks(int page, int size);
        Book GetBookById(Guid bookId);
        Book BorrowedBook(Guid userId, Guid bookId);
        Book UnBorrowedBook(Guid bookId);
        Book Reserve(Guid userId, Guid bookId);
        Book CancelReservation(Guid bookId);
    }
}
