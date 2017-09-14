using Fiver.Mvc.RazorPages.More.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;

namespace Fiver.Mvc.RazorPages.More.Filters
{
    public class HelloPageFilter : Attribute, IPageFilter
    {
        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            var log = "selected";
        }
        
        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var log = "executing";
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            var log = "executed";
            context.HttpContext.Response.Headers.Add(
                "X-Developer", new StringValues("Tahir"));
        }
    }

    public class GreetingServiceFilter : IPageFilter
    {
        private readonly IGreetingService greetingService;

        public GreetingServiceFilter(IGreetingService greetingService)
        {
            this.greetingService = greetingService;
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            var log = "selected";
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var log = "executing";
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            var log = "executed";
            context.HttpContext.Response.Headers.Add(
                "X-Greeting", new StringValues(this.greetingService.Greet("Tahir")));
        }
    }

    public class GreetingTypeFilter : IPageFilter
    {
        private readonly IGreetingService greetingService;

        public GreetingTypeFilter(IGreetingService greetingService)
        {
            this.greetingService = greetingService;
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            var log = "selected";
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var log = "executing";
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            var log = "executed";
            context.HttpContext.Response.Headers.Add(
                "X-Greeting", new StringValues(this.greetingService.Greet("Tahir")));
        }
    }

    public class GreetingTypeFilterWrapper : TypeFilterAttribute
    {
        public GreetingTypeFilterWrapper() : base(typeof(GreetingTypeFilter))
        {
        }
    }

    public class SkipActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.Result = new ContentResult
            {
                Content = "I'll skip the action execution"
            };
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Will not reach here
        }
    }

    public class SkipResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.Cancel = true;
            context.HttpContext.Response.WriteAsync("I'll skip the result execution");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Will not reach here
        }
    }
}
