using ChatApp.Models.Message;

namespace ChatApp.Models.Chat
{
    public class ChatViewModel
    {
        public MessageViewModel CurrentMessage { get; set; } = null!;

        public ICollection<MessageViewModel> Messagees { get; set; } = null!;
    }
}
