using System.Linq;
using System.Threading.Tasks;
using CMS.ContentEngine;
using CMS.Websites;
using CMS.Websites.Routing;
using DemoKentico.Common.Models;

namespace DemoKentico.Core.Services
{
    /// <summary>
    /// Retrieves Page content items from Kentico Xperience.
    /// Equivalent to DFGC.Core's page-retrieval service layer.
    /// 
    /// NOTE: Until you create the "DemoKentico.Page" content type in the
    /// Kentico admin backoffice, queries will return null — this is expected.
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

        public async Task<PageModel?> GetPageAsync(int webPageItemId, string languageName, string channelName)
        {
            // Build a content query for the Page content type
            var queryBuilder = new ContentItemQueryBuilder()
                .ForContentType(
                    PageModel.CONTENT_TYPE_NAME,
                    q => q.ForWebsite(channelName)
                          .Where(w => w.WhereEquals(nameof(IWebPageContentQueryDataContainer.WebPageItemID), webPageItemId))
                          .TopN(1)
                )
                .InLanguage(languageName);

            var options = new ContentQueryExecutionOptions
            {
                ForPreview = _channelContext.IsPreview
            };

            var pages = await _queryExecutor.GetMappedWebPageResult<PageModel>(queryBuilder, options);

            return pages.FirstOrDefault();
        }
    }
}
