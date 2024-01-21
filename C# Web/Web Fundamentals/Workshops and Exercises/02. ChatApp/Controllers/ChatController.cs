using ChatApp.Models.Chat;
using ChatApp.Models.Message;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private static List<KeyValuePair<string,string>> messages = 
            new List<KeyValuePair<string,string>>();

        public IActionResult Show()
        {
            if (messages.Count < 1)
            {
                return View(new ChatViewModel());
            }

            var chatViewModel = new ChatViewModel()
            {
                Messagees = messages.Select(m =>
                        new MessageViewModel()
                {
                    Sender = m.Key,
                    MessageText = m.Value
                })
                .ToArray()
            };

            return View(chatViewModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chatViewModel)
        {
            var currentMessage = chatViewModel.CurrentMessage;

            messages.Add(new 
                KeyValuePair<string, string>
                (currentMessage.Sender,currentMessage.MessageText));

            return RedirectToAction("Show");
        }
    }
}
