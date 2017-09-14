using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiver.Mvc.RazorPages.More.Pages
{
    public class ViewComponentsModel : PageModel
    {
        public void OnGet()
        {
        }

        // doesn't compile. PageModel base doesn't have ViewComponent
        //public IActionResult UserInfo() => ViewComponent("UserInfo");
    }
}