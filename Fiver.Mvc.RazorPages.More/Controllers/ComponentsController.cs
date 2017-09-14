using Microsoft.AspNetCore.Mvc;

namespace Fiver.Mvc.RazorPages.More.Controllers
{
    public class ComponentsController : Controller
    {
        public IActionResult UserInfo()
        {
            // works if this component's view is in Views/Shared
            // doesn't work if this component's view is in Page/Components/[UserInfo]
            //    which works when accessing from the .cshtml of Razor Page
            return ViewComponent("UserInfo");
        }
    }
}
