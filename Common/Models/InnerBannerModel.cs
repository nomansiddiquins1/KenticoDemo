namespace DemoKentico.Common.Models
{
    /// <summary>
    /// Kentico content-type model for the "HeroBanner" component.
    /// Equivalent to DFGC.Common.Models.CMS.HeroBanner in the Umbraco project.
    /// 
    /// After you create the "HeroBanner" content type in Kentico admin,
    /// the properties here should map to the fields you define.
    /// </summary>
    public class InnerBannerModel
    {
        public const string CONTENT_TYPE_NAME = "DemoKentico.InnerBanner";

        public string Heading { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

    }
}
