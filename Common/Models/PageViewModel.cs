using System.Collections.Generic;
using System.Linq;

namespace DemoKentico.Common.Models
{
    /// <summary>
    /// View model passed to Views/Page/Index.cshtml.
    /// Aggregates page data, components, SEO/hreflang info, and site data.
    /// Equivalent to the combined ViewData dictionary used in DFGC's page.cshtml.
    /// </summary>
    public class PageViewModel
    {
        public PageModel Page { get; set; } = new();

        public IEnumerable<object> Components { get; set; } = Enumerable.Empty<object>();

        public string CurrentLanguage { get; set; } = "en";

        // hreflang alternate URLs
        public string EnUrl { get; set; } = string.Empty;
        public string ArUrl { get; set; } = string.Empty;
        public bool IsPublishedInEnglish { get; set; } = true;
        public bool IsPublishedInArabic { get; set; }

        // Site-level data for header/footer
        public SiteModel Site { get; set; } = new();
    }
}
