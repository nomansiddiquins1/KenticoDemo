namespace DemoKentico.Common.Models
{
    /// <summary>
    /// View model used by the HeroBanner ViewComponent and its Razor view.
    /// Maps from HeroBannerModel (CMS content type) to a simple display model.
    /// </summary>
    public class HeroBanner
    {
        public string Heading { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BackgroundImageUrl { get; set; } = string.Empty;
        public string CtaText { get; set; } = string.Empty;
        public string CtaUrl { get; set; } = string.Empty;
        public string DesignClass { get; set; } = string.Empty;
    }
}
