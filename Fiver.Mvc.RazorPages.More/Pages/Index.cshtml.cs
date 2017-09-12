using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiver.Mvc.RazorPages.More.Pages
{
    public class IndexModel : PageModel
    {
        public string Title { get; set; }

        public void OnGet()
        {
            this.Title = "ASP.NET Core 2.0 Razor Pages";
        }
    }
}