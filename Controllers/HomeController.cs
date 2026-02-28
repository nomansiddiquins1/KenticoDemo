using DemoKentico.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DemoKentico.Controllers
{
    /// <summary>
    /// Fallback controller that serves the Home page with a static Hero Banner.
    /// This works even before you create content types in the Kentico admin.
    /// 
    /// Once you set up the Page content type and publish pages in the backoffice,
    /// Kentico's RegisterWebPageRoute will take over and use PageController instead.
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new PageViewModel
            {
                Page = new PageModel(),
                CurrentLanguage = "en",
                IsPublishedInEnglish = true,
                Site = new SiteModel
                {
                    SiteName = "DemoKentico",
                    AssetsVersion = 1
                },
                Components = new List<object>
                {
                    // Static Hero Banner — replace with CMS data later
                    new HeroBannerModel
                    {
                        Heading = "Welcome to <em>DemoKentico</em>",
                        Description = "A Kentico Xperience 31 demo project mirroring the DFGC Umbraco architecture. Set up your content types in the admin to get started.",
                        CtaText = "Open Admin",
                        CtaUrl = "/admin",
                        Design = ""
                    }
                }
            };

            return View("~/Views/Page/Index.cshtml", viewModel);
        }
    }
}
