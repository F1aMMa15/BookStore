namespace BookStore.Api.Entities
{
    public record Order
    {
        public int Id { get; set; }
        public List<Book> Books { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
