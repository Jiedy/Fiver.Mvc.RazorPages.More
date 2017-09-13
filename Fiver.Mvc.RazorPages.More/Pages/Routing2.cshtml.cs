using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiver.Mvc.RazorPages.More.Pages
{
    public class Routing2Model : PageModel
    {
        public string Message { get; set; }

        public void OnGet() { }

        public void OnGetFromRouting1(int id, string name) 
            => this.Message = $"I came from /Pages/Routing: {id} - {name}";
    }
}