using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Text_Splitter.ViewModels;

namespace Text_Splitter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(TextViewModel textViewModel)
        {
            if (string.IsNullOrEmpty(textViewModel.Text) && ModelState.ContainsKey("Text"))
            {
                ModelState["Text"].Errors.Clear();
            }
            return View(textViewModel);
        }

        [HttpPost]
        public IActionResult Split(TextViewModel textViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", textViewModel);
            }

            string[] splittedText = textViewModel
                .Text
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            textViewModel.SplitText = string.Join(Environment.NewLine, splittedText);

            return RedirectToAction("Index", textViewModel);
        }

    }
}
