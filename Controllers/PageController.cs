using System.Threading.Tasks;
using CMS.Websites;
using DemoKentico.Common.Constants;
using DemoKentico.Common.Models;
using DemoKentico.Core.Services;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;

// Binds this controller to the Page content type —
// equivalent to Umbraco routing pages of type "page" to page.cshtml
[assembly: RegisterWebPageRoute(
    contentTypeName: PageModel.CONTENT_TYPE_NAME,
    controllerType: typeof(DemoKentico.Controllers.PageController)
)]

namespace DemoKentico.Controllers
{
    public class PageController : Controller
    {
        private readonly IWebPageDataContextRetriever _contextRetriever;
        private readonly IWebPageUrlRetriever _urlRetriever;
        private readonly IPageService _pageService;

        public PageController(
            IWebPageDataContextRetriever contextRetriever,
            IWebPageUrlRetriever urlRetriever,
            IPageService pageService)
        {
            _contextRetriever = contextRetriever;
            _urlRetriever = urlRetriever;
            _pageService = pageService;
        }

        public async Task<IActionResult> Index()
        {
            var dataContext = _contextRetriever.Retrieve().WebPage;

            var page = await _pageService.GetPageAsync(
                dataContext.WebPageItemID,
                dataContext.LanguageName,
                dataContext.WebsiteChannelName);

            if (page == null)
                return NotFound();

            var request = HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";
            var currentPath = request.Path.ToString();

            // Build hreflang URLs — same logic as Umbraco layout.cshtml alternate links
            var enUrl = $"{baseUrl}{currentPath.Replace("/ar/", "/en/")}";
            var arUrl = $"{baseUrl}{currentPath.Replace("/en/", "/ar/")}";

            var viewModel = new PageViewModel
            {
                Page = page,
                Components = page.Components,
                CurrentLanguage = dataContext.LanguageName,
                EnUrl = enUrl,
                ArUrl = arUrl,

                // Determine which languages are published for hreflang rendering
                IsPublishedInEnglish = dataContext.LanguageName == Languages.Default
                    || !string.IsNullOrEmpty(enUrl),
                IsPublishedInArabic = !string.IsNullOrEmpty(arUrl),

                // Site/channel-level data for header and footer partials
                Site = new SiteModel
                {
                    SiteName = dataContext.WebsiteChannelName,
                    AssetsVersion = 1
                }
            };

            // Views/Page/Index.cshtml
            return View(viewModel);
        }
    }
}
