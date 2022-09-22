using Books_spot.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Books_spot.DAL
{
    public class DbInitializer
    {
        public static void Initialize(BooksSpotDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User{UserId = Guid.NewGuid(),Name = "Library manager",Role = "Admin"},
                new User{UserId = Guid.NewGuid(),Name = "Reader1",Role = "User"},
                new User{UserId = Guid.NewGuid(),Name = "Reader2",Role = "User"}
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var books = new Book[]
            {
                new Book{BookId = Guid.NewGuid(),Title = "The Lord of the Rings",Author = "J.R.R. Tolkien",Publisher = "Houghton Mifflin",PublishingDate = "2002",Genre = "Fiction",ISBN10 = "0618260242",BookBorrowed="",BookReserved=""},
                new Book{BookId = Guid.NewGuid(),Title = "A Game of Thrones",Author = "George R. R. Martin",Publisher = "Bantam Books",PublishingDate = "1996",Genre = "Fiction",ISBN10 = "0553381687", BookBorrowed="",BookReserved=""},
                new Book{BookId = Guid.NewGuid(),Title = "The Orange Girl",Author = " Jostein Gaarder",Publisher = "Phoenix",PublishingDate = "2005",Genre = "Novel",ISBN10 = "0753819929",BookBorrowed="",BookReserved=""},
                new Book{BookId = Guid.NewGuid(),Title = "Desperation in Death",Author = "J.D. Robb",Publisher = "St. Martin's Press",PublishingDate = "2022",Genre = "Romance",ISBN10 = "1250278236",BookBorrowed="",BookReserved=""},
                new Book{BookId = Guid.NewGuid(),Title = "Napoleon: The Decline and Fall of an Empire: 1811-1821",Author = "Michael Broers",Publisher = "Pegasus Books",PublishingDate = "2022",Genre = "Biography",ISBN10 = "1639361774",BookBorrowed="",BookReserved=""}
            };

            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}