namespace BookStore.Api.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime PublishDate { get; set; }
    }
}
