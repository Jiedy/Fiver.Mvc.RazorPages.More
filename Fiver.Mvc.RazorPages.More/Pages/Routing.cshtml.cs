using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiver.Mvc.RazorPages.More.Pages
{
    public class RoutingModel : PageModel
    {
        public string Route { get; set; }
        public string Message { get; set; }
        
        public IActionResult OnGet()
        {
            this.Route = "Pages/Routing/OnGet";
            return Page();
        }

        public IActionResult OnGetOne()
        {
            this.Route = "Pages/Routing/OnGetOne";
            return Page();
        }
        
        [HttpPost] // -> doesn't work
        public IActionResult OnGetTwo()
        {
            this.Route = "Pages/Routing/OnGetTwo";
            this.Message = "Via GET even with [HttpPost] constraint";
            return Page();
        }

        public IActionResult OnPost()
        {
            this.Route = "Pages/Routing/OnPost";
            return Page();
        }

        public IActionResult OnPostOne()
        {
            this.Route = "Pages/Routing/OnPostOne";
            return Page();
        }

        [HttpGet] // -> doesn't work
        public IActionResult OnPostTwo()
        {
            this.Route = "Pages/Routing/OnPostTwo";
            this.Message = "Via POST even with [HttpGet] constraint";
            return Page();
        }

        //[HttpDelete] // -> doesn't work
        public IActionResult OnDelete() // not called
        {
            this.Route = "Pages/Routing/OnDelete";
            return Page();
        }

        //[HttpPut] // -> doesn't work
        public IActionResult OnPut()
        {
            this.Route = "Pages/Routing/OnPut";
            return Page();
        }

        [Route("routetoone")] // -> doesn't work
        public IActionResult OnGetRoute1()
        {
            this.Route = "Pages/Routing/OnGetRoute1";
            return Page();
        }

        public IActionResult OnGetUrlForPage()
        {
            this.Route = "Pages/Routing/OnGetUrlForPage";
            this.Message = $"{Url.Page("Routing","")}";
            return Page();
        }

        public IActionResult OnGetUrlForPageAndHandler()
        {
            // doesn't validate the handler 
            // i.e. you can supply handler that doesn't exist
            this.Route = "Pages/Routing/OnGetUrlForPageAndHandler";
            this.Message = $"{Url.Page("Routing", "One")}"; 
            return Page();
        }

        public IActionResult OnGetWithParam(int id)
        {
            this.Route = "Pages/Routing/OnGetWithParam";
            this.Message = $"Parameter: {id}";
            return Page();
        }

        public IActionResult OnPostWithParam(int id)
        {
            this.Route = "Pages/Routing/OnPostWithParam";
            this.Message = $"Parameter: {id}";
            return Page();
        }
    }
}