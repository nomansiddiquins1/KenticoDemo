using DemoKentico.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoKentico.Components
{
    /// <summary>
    /// View component for the HeroBanner content type.
    /// Invoked dynamically from Index.cshtml via Component.InvokeAsync("HeroBannerModel").
    /// Equivalent to Umbraco's Html.PartialAsync("Components/heroBanner.cshtml", component).
    /// </summary>
    public class InnerBannerModelViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(InnerBannerModel model)
        {
            // Map from content type model to view model
            // (mirrors DFGC's approach of having the view inherit from the CMS model)
            var viewModel = new HeroBanner
            {
                Heading = model?.Heading ?? string.Empty,
                Description = model?.Description ?? string.Empty,
            };

            return View("~/Views/Components/InnerBanner.cshtml", viewModel);
        }
    }
}
