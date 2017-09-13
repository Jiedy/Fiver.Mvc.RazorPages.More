using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiver.Mvc.RazorPages.More.Pages
{
    public class ModelBindingModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet() => this.Message = "Pages/ModelBinding/OnGet";

        public void OnGetFromQuery([FromQuery]int id)
            => this.Message = $"Pages/ModelBinding/OnGetFromQuery: {id}";

        public void OnGetFromForm([FromForm]int id) // doesn't work with OnGet[Handler]
            => this.Message = $"Pages/ModelBinding/OnGetFromForm: {id}";

        public void OnPostFromForm([FromForm]int id) 
            => this.Message = $"Pages/ModelBinding/OnPostFromForm: {id}";

        public void OnGetFromBody([FromBody]int id) // doesn't work with OnGet[Handler]
            => this.Message = $"Pages/ModelBinding/OnGetFromBody: {id}";

        public void OnPostFromBody([FromBody]int id) // doesn't work with OnPost[Handler]
            => this.Message = $"Pages/ModelBinding/OnPostFromBody: {id}";

        public void OnGetFromHeader(
            [FromHeader]string host,
            [FromHeader(Name = "User-Agent")]string userAgent)
            => this.Message = $"Pages/ModelBinding/OnGetFromHeader: {host} - {userAgent}";



        public void OnGetComplexFromQuery([FromQuery]MovieInputModel model)
            => this.Message = $"Pages/ModelBinding/OnGetComplexFromQuery: {model.Id} - {model.Title}";

        public void OnPostComplexFromForm([FromForm]MovieInputModel model)
            => this.Message = $"Pages/ModelBinding/OnPostComplexFromForm: {model.Id} - {model.Title}";

        public void OnGetComplexFromHeader(
            HeaderInputModel model)
            => this.Message = $"Pages/ModelBinding/OnGetComplexFromHeader: {model.Host} - {model.UserAgent}";
    }

    public class MovieInputModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }

    public class HeaderInputModel
    {
        [FromHeader]
        public string Host { get; set; }

        [FromHeader(Name = "User-Agent")]
        public string UserAgent { get; set; }
    }
}