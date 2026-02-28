//using DemoKentico.Core.Services;
//using Kentico.Content.Web.Mvc.Routing;
//using Kentico.PageBuilder.Web.Mvc;
//using Kentico.Web.Mvc;

//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.DependencyInjection;

//var builder = WebApplication.CreateBuilder(args);


//// Enable desired Kentico Xperience features
//builder.Services.AddKentico(features =>
//{
//    // features.UsePageBuilder();
//    // features.UseActivityTracking();
//    // features.UseWebPageRouting();
//    // features.UseEmailStatisticsLogging();
//    // features.UseEmailMarketing();
//});

//builder.Services.AddAuthentication();
//// builder.Services.AddAuthorization();

//builder.Services.AddControllersWithViews();

//var app = builder.Build();
//app.InitKentico();

//app.UseStaticFiles();

//app.UseCookiePolicy();

//app.UseAuthentication();


//app.UseKentico();

//// app.UseAuthorization();

//app.Kentico().MapRoutes();
//app.MapGet("/", () => "The DemoKentico site has not been configured yet.");

//app.Run();

using DemoKentico.Core.Services;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// ── Xperience by Kentico ─────────────────────────────────────────────────────
builder.Services.AddKentico(features =>
{
    features.UsePageBuilder();
    features.UseWebPageRouting();
});

// ── MVC ──────────────────────────────────────────────────────────────────────
builder.Services.AddControllersWithViews();

// ── Application services (DemoKentico.Core) ───────────────────────────────────
builder.Services.AddScoped<IPageService, PageService>();

// ── Content type mappings (DemoKentico.Common) ────────────────────────────────
// Tells the Xperience query executor how to map content items to your models.
// Add one line per reusable content type you create in Admin.
builder.Services.AddSingleton<CMS.ContentEngine.IContentItemMapper>(
    new Kentico.Content.Web.Mvc.ContentItemMapper()
);

var app = builder.Build();

// ── Xperience middleware ──────────────────────────────────────────────────────
app.InitKentico();
app.UseKentico();

// ── Standard middleware ───────────────────────────────────────────────────────
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Page}/{action=Index}/{id?}"
);

app.Run();
