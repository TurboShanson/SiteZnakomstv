// SiteZnakomstv/Components/Hubs/IChatClient.cs
namespace SiteZnakomstv.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(int chatId, string senderId, string senderName, string text, DateTime sentAt);
    }
}