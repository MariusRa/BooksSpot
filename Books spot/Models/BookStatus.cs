using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Books_spot.Models
{
    public class BookStatus
    {
        [Key]
        public Guid StutusId { get; set; }
        public bool IsReserved { get; set; }


        [JsonIgnore]
        public Guid BookId { get; set; }
        
        public Guid UserId { get; set; }
    }
}
