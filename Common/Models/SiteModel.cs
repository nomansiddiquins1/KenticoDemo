namespace DemoKentico.Common.Models
{
    /// <summary>
    /// Site-level model passed to header and footer partials.
    /// Equivalent to DFGC.Common.Models.CMS.Site in the Umbraco project.
    /// </summary>
    public class SiteModel
    {
        public string SiteName { get; set; } = string.Empty;
        public int AssetsVersion { get; set; } = 1;
    }
}
