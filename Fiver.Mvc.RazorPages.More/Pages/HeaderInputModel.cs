using Microsoft.AspNetCore.Mvc;

namespace Fiver.Mvc.RazorPages.More.Pages
{
    public class HeaderInputModel
    {
        [FromHeader]
        public string Host { get; set; }

        [FromHeader(Name = "User-Agent")]
        public string UserAgent { get; set; }
    }
}