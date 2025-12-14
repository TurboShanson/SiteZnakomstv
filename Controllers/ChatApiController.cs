using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiteZnakomstv.Data;

[ApiController]
[Route("api/chat/{chatId}")]
public class ChatApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public ChatApiController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet("new")]
    public async Task<List<MessageDto>> GetNewMessages(int chatId, DateTime after)
    {
        var messages = await _context.Messages
            .Where(m => m.ChatId == chatId && m.SentAt > after)
            .Include(m => m.Sender)
            .OrderBy(m => m.SentAt)
            .Select(m => new MessageDto
            {
                SenderId = m.SenderId,
                SenderName = m.Sender.Name,
                Text = m.Text,
                SentAt = m.SentAt
            })
            .ToListAsync();

        return messages;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendMessage(int chatId, [FromBody] SendMessageDto dto)
    {
        var userId = _userManager.GetUserId(User);

        var msg = new Message
        {
            ChatId = chatId,
            SenderId = userId!,
            Text = dto.Text,
            SentAt = DateTime.UtcNow
        };

        _context.Messages.Add(msg);
        await _context.SaveChangesAsync();

        return Ok();
    }

    public class SendMessageDto
    {
        public string Text { get; set; } = "";
    }

    public class MessageDto
    {
        public string SenderId { get; set; } = "";
        public string SenderName { get; set; } = "";
        public string Text { get; set; } = "";
        public DateTime SentAt { get; set; }
    }
}
