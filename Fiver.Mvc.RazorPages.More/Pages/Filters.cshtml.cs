using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fiver.Mvc.RazorPages.More.Filters;

namespace Fiver.Mvc.RazorPages.More.Pages
{
    //[HelloPageFilter]
    //[ServiceFilter(typeof(GreetingServiceFilter))]
    //[TypeFilter(typeof(GreetingTypeFilter))]
    [GreetingTypeFilterWrapper]
    public class FiltersModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet() => this.Message = "Pages/Filters/OnGet";

        //[SkipActionFilter] // Action Filters don't seem to work
        //[SkipResultFilter] // Result Filters don't seem to work
        public IActionResult OnGetSkip()
        {   
            return Content("Hello SkipAction");
        }
    }
}