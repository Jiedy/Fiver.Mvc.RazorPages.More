using Microsoft.AspNetCore.Http;

namespace Fiver.Mvc.RazorPages.More.Models
{
    public class FileInputModel
    {
        public IFormFile FileToUpload { get; set; }
    }
}
