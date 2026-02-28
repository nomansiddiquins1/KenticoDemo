using DemoKentico.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoKentico.Components
{
    /// <summary>
    /// View component for the HeroBanner content type.
    /// Invoked dynamically from Index.cshtml via Component.InvokeAsync("HeroBannerModel").
    /// Equivalent to Umbraco's Html.PartialAsync("Components/heroBanner.cshtml", component).
    /// </summary>
    public class HeroBannerModelViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(HeroBanner model)
        {
            return View("~/Views/Components/HeroBanner.cshtml", model);
        }
    }
}
