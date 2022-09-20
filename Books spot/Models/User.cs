using System.Text.Json.Serialization;

namespace Books_spot.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        //[JsonIgnore]
        //public ICollection<Book>? Books { get; set; }
        [JsonIgnore]
        public ICollection<BookStatus> BookStatuses { get; set; }
    }
}
