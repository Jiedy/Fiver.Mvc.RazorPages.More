using Fiver.Mvc.RazorPages.More.Pages;
using System;
using Xunit;

namespace Fiver.Mvc.RazorPages.Testing
{
    public class PageTests
    {
        [Fact(DisplayName = "OnGet_returns_property_on_page")]
        public void OnGet_returns_property_on_page()
        {
            // Arrange
            var sut = new IndexModel();

            // Act
            sut.OnGet();

            // Assert
            Assert.Equal(
                expected: "ASP.NET Core 2.0 Razor Pages", 
                actual: sut.Title);
        }
    }
}
