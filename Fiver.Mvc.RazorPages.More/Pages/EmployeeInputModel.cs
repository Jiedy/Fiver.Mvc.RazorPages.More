using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiver.Mvc.RazorPages.More.Pages
{
    public class EmployeeInputModel : IValidatableObject
    {
        public int Id { get; set; }
        
        [Required]
        public string EmployeeNo { get; set; }

        [Url]
        public string BlogUrl { get; set; }

        [DataType(DataType.Date)]
        [AgeCheck]
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }
        
        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(BlogUrl) && 
                    BlogUrl.Contains("tahirnaushad.com"))
                yield return new ValidationResult(
                    "URL already taken", new[] { "BlogUrl" });
        }
    }
    
    public class AgeCheck : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance as EmployeeInputModel;

            if (model == null)
                throw new ArgumentException("Attribute not applied on Employee");
            
            if (model.BirthDate > DateTime.Now.Date)
                return new ValidationResult(GetErrorMessage(validationContext));

            return ValidationResult.Success;
        }

        private string GetErrorMessage(ValidationContext validationContext)
        {
            // Message that was supplied
            if (!string.IsNullOrEmpty(this.ErrorMessage))
                return this.ErrorMessage;

            // Use generic message: i.e. The field {0} is invalid
            //return this.FormatErrorMessage(validationContext.DisplayName);

            // Custom message
            return $"{validationContext.DisplayName} can't be in future";
        }
    }
}
