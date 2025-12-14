namespace SiteZnakomstv.Services
{
    public class MessageNotifier
    {
        // Событие, которое компоненты чата могут подписывать.
        // Он будет принимать Id чата, чтобы компоненты могли проверить,
        // относится ли сообщение к их текущему окну чата.
        public event Action<int>? OnNewMessage;

        // Метод для вызова события при отправке нового сообщения.
        public void NotifyMessageSent(int chatId)
        {
            OnNewMessage?.Invoke(chatId);
        }
    }
}