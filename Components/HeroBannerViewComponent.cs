using DemoKentico.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoKentico.Components
{
    /// <summary>
    /// View component for the HeroBanner content type.
    /// Invoked dynamically from Index.cshtml via Component.InvokeAsync("HeroBannerModel", new { model = component }).
    /// </summary>
    public class HeroBannerModelViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(HeroBanner model)
        {
            // Now using the CMS model directly in the view
            return View("~/Views/Components/HeroBanner.cshtml", model);
        }
    }
}
