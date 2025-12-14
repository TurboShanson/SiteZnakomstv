// Hubs/ChatHub.cs
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SiteZnakomstv.Hubs
{
    // Наследуемся от Hub<IChatClient>
    public class ChatHub : Hub<IChatClient>
    {
        // Этот метод будет вызван, когда компонент Blazor присоединяется к чату
        public async Task JoinChat(int chatId)
        {
            // Присоединяем текущее соединение к группе, соответствующей ID чата
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
        }

        // Этот метод будет вызван, когда компонент Blazor покидает чат
        public async Task LeaveChat(int chatId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId.ToString());
        }
    }
}