using System.Threading.Tasks;
using CMS.Websites;
using DemoKentico.Common.Constants;
using DemoKentico.Common.Models;
using DemoKentico.Core.Services;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;

// Binds this controller to the Page content type
[assembly: RegisterWebPageRoute(
    contentTypeName: Page.CONTENT_TYPE_NAME,
    controllerType: typeof(DemoKentico.Controllers.PageController)
)]

namespace DemoKentico.Controllers
{
    public class PageController : Controller
    {
        private readonly IWebPageDataContextRetriever _contextRetriever;
        private readonly IPageService _pageService;

        public PageController(
            IWebPageDataContextRetriever contextRetriever,
            IPageService pageService)
        {
            _contextRetriever = contextRetriever;
            _pageService = pageService;
        }

        public async Task<IActionResult> Index()
        {
            var dataContext = _contextRetriever.Retrieve().WebPage;

            var (page, components) = await _pageService.GetPageAsync(
                dataContext.WebPageItemID,
                dataContext.LanguageName,
                dataContext.WebsiteChannelName);

            if (page == null)
            {
                return NotFound();
            }

            var model = new PageViewModel
            {
                Page = page,
                Components = components,
                CurrentLanguage = dataContext.LanguageName,
                Site = new SiteModel
                {
                    SiteName = dataContext.WebsiteChannelName,
                    AssetsVersion = 1
                }
            };

            // Views/Page/Index.cshtml
            return View(model);
        }
    }
}
