using DemoKentico.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoKentico.Components
{
    /// <summary>
    /// View component for the InnerBanner content type.
    /// Invoked dynamically from Index.cshtml via Component.InvokeAsync("InnerBannerModel", new { model = component }).
    /// </summary>
    public class InnerBannerModelViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(InnerBanner model)
        {
            // Now using the CMS model directly in the view
            return View("~/Views/Components/InnerBanner.cshtml", model);
        }
    }
}
