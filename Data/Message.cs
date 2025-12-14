namespace SiteZnakomstv.Data
{
    public class Message
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public Chatik Chat { get; set; } = null!;

        public string SenderId { get; set; } = null!;
        public ApplicationUser Sender { get; set; } = null!;

        public string Text { get; set; } = "";
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}
