using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.ContentEngine;
using CMS.Websites;
using CMS.Websites.Routing;
using Kentico.Content.Web.Mvc;
using DemoKentico.Common.Models;

namespace DemoKentico.Core.Services
{
    /// <summary>
    /// Retrieves Page content items from Kentico Xperience.
    /// Equivalent to DFGC.Core's page-retrieval service layer.
    /// </summary>
    public class PageService : IPageService
    {
        private readonly IContentQueryExecutor _queryExecutor;
        private readonly IWebsiteChannelContext _channelContext;

        public PageService(
            IContentQueryExecutor queryExecutor,
            IWebsiteChannelContext channelContext)
        {
            _queryExecutor = queryExecutor;
            _channelContext = channelContext;
        }

        public async Task<(Page? Page, IEnumerable<object> Components)> GetPageAsync(int webPageItemId, string languageName, string channelName)
        {
            var queryBuilder = new ContentItemQueryBuilder()
                .ForContentType(
                    Page.CONTENT_TYPE_NAME,
                    q => q.ForWebsite(channelName)
                          .Where(w => w.WhereEquals(nameof(IWebPageContentQueryDataContainer.WebPageItemID), webPageItemId))
                          .WithLinkedItems(1)
                          .TopN(1)
                )
                .InLanguage(languageName);

            var options = new ContentQueryExecutionOptions
            {
                ForPreview = _channelContext.IsPreview
            };

            var pages = await _queryExecutor.GetMappedWebPageResult<Page>(queryBuilder, options);
            var page = pages.FirstOrDefault();
            
            // Generic approach: Extract the "Components" property via reflection if it exists.
            // This satisfies the requirement to handle any component type (HeroBanner, InnerBanner, etc.)
            // as long as they are mapped to the "Components" property on the Page model.
            IEnumerable<object> components = Enumerable.Empty<object>();
            if (page != null)
            {
                var componentsProperty = page.GetType().GetProperty("Components");
                if (componentsProperty != null)
                {
                    var value = componentsProperty.GetValue(page);
                    if (value is System.Collections.IEnumerable enumerable)
                    {
                        components = enumerable.Cast<object>();
                    }
                }
            }

            return (page, components);
        }
    }
}
