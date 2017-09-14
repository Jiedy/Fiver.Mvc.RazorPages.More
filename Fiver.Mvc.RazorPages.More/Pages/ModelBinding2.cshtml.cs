using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiver.Mvc.RazorPages.More.Pages
{
    public class ModelBinding2Model : PageModel
    {
        public string Message { get; set; }

        [BindProperty(SupportsGet = true)]
        public MovieInputModel Movie { get; set; } = new MovieInputModel();

        public void OnGet()
        {
            this.Message = $"Pages/ModelBinding2/OnGet: {Movie.Id} {Movie.Title}";
        }

        public void OnGetSave()
        {
            // GET with a handler not working withint <form>
            // it binds the Movie correctly but doesn't come here
            // unless you have a field on the form for 'handler'
            this.Message = $"Pages/ModelBinding2/OnGetSave: {Movie.Id} {Movie.Title}";
        }

        public void OnPost()
        {
            // without [BindProperty] Movie will be null i.e. not bind
            this.Message = $"Pages/ModelBinding2/OnPost: {Movie.Id} {Movie.Title}";
        }

        public void OnPostSave()
        {
            // without [BindProperty] Movie will be null i.e. not bind
            this.Message = $"Pages/ModelBinding2/OnPostSave: {Movie.Id} {Movie.Title}";
        }
    }
}