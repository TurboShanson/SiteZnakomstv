using SiteZnakomstv.Data;

public class Chatik
{
    public int Id { get; set; }

    // Два пользователя
    public string User1Id { get; set; } = null!;
    public ApplicationUser User1 { get; set; } = null!;

    public string User2Id { get; set; } = null!;
    public ApplicationUser User2 { get; set; } = null!;

    public ICollection<Message> Messages { get; set; } = new List<Message>();
}