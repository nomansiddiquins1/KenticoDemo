namespace DemoKentico.Common.Models
{
    /// <summary>
    /// View model used by the HeroBanner ViewComponent and its Razor view.
    /// Maps from HeroBannerModel (CMS content type) to a simple display model.
    /// </summary>
    public class InnerBanner
    {
        public string Heading { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
    }
}
