using System.Collections.Generic;
using System.Linq;
using CMS.ContentEngine;
using CMS.Websites;

namespace DemoKentico.Common.Models
{
    /// <summary>
    /// Kentico content-type model for "DemoKentico.Page".
    /// Equivalent to DFGC.Common.Models.CMS.Page in the Umbraco project.
    /// 
    /// After you create the "Page" content type in the Kentico admin,
    /// the CONTENT_TYPE_NAME here must match the code name you used
    /// (e.g. "DemoKentico.Page").
    /// </summary>
    public class PageModel : IWebPageFieldsSource
    {
        public const string CONTENT_TYPE_NAME = "DemoKentico.Page";

        public WebPageFields SystemFields { get; set; } = new();

        /// <summary>
        /// List of child component content items attached to this page.
        /// In DFGC_umbraco this was Page.Components (IEnumerable&lt;IPublishedContent&gt;).
        /// In Kentico this will be populated from linked items / page builder widgets.
        /// </summary>
        public IEnumerable<object> Components { get; set; } = Enumerable.Empty<object>();
    }
}
