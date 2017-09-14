using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiver.Mvc.RazorPages.More.Pages
{
    public class ModelValidationModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        public EmployeeInputModel Employee { get; set; } = new EmployeeInputModel();

        public void OnGet() => this.Message = "Pages/ModelValidation/OnGet";

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            return RedirectToPage("/");
        }
    }
}