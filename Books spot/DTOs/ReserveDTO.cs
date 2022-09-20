namespace Books_spot.DTOs
{
    public class ReserveDTO
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public bool IsReserved { get; set; }
    }
}
