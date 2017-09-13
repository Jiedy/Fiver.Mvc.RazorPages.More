using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiver.Mvc.RazorPages.More.Pages
{
    public class RoutingModel : PageModel
    {
        public string Message { get; set; }

        #region " GET / POST "

        public void OnGet() => this.Message = "Pages/Routing/OnGet";
        public void OnGetOne() => this.Message = "Pages/Routing/OnGetOne";

        public void OnPost() => this.Message = "Pages/Routing/OnPost";
        public void OnPostOne() => this.Message = "Pages/Routing/OnPostOne";

        #endregion

        #region " Action Constraints "

        [HttpPost] // -> ignored
        public void OnGetTwo() => this.Message = "Pages/Routing/OnGetTwo";

        [HttpGet] // -> ignored
        public void OnPostTwo() => this.Message = "Pages/Routing/OnPostTwo";

        #endregion

        #region " Attribute Routing "

        [Route("routetoone")] // -> ignored
        public void OnGetRoute1() => this.Message = "Pages/Routing/OnGetRoute1";

        #endregion

        #region " Url.Page "

        public void OnGetUrlForPage()
            => this.Message = $"Pages/Routing/OnGetUrlForPage: {Url.Page("Routing", "")}";

        // doesn't validate the handler 
        // i.e. you can supply handler that doesn't exist
        public void OnGetUrlForPageAndHandler()
            => this.Message = $"Pages/Routing/OnGetUrlForPageAndHandler: " +
                            $"{Url.Page("Routing", "One")}";

        #endregion

        #region " Parameters "

        public void OnGetWithParam(int id)
            => this.Message = $"Pages/Routing/OnGetWithParam: {id}";

        public void OnPostWithParam(int id)
            => this.Message = $"Pages/Routing/OnPostWithParam: {id}";

        #endregion
    }
}