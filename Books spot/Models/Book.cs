using System.Text.Json.Serialization;

namespace Books_spot.Models
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string PublishingDate { get; set; }
        public string Genre { get; set; }
        public string ISBN10 { get; set; }
        public Guid UserId { get; set; }


        public ICollection<BookStatus> BookStatuses { get; set; }
    }
}
