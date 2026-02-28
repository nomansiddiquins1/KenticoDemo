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
        public IViewComponentResult Invoke(HeroBannerModel model)
        {
            // Map from content type model to view model
            // (mirrors DFGC's approach of having the view inherit from the CMS model)
            var viewModel = new HeroBanner
            {
                Heading = model?.Heading ?? string.Empty,
                Description = model?.Description ?? string.Empty,
                BackgroundImageUrl = model?.BackgroundImageUrl ?? string.Empty,
                CtaText = model?.CtaText ?? string.Empty,
                CtaUrl = model?.CtaUrl ?? string.Empty,
                DesignClass = model?.Design switch
                {
                    "Yellow Theme" => "bg-yellow",
                    "Pink Theme" => "bg-pink",
                    "Orange Theme" => "bg-orange",
                    _ => string.Empty
                }
            };

            return View("~/Views/Components/HeroBanner.cshtml", viewModel);
        }
    }
}
