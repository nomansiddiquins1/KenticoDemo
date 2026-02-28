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

// ── Application services ──────────────────────────────────────────────────────
builder.Services.AddScoped<IPageService, PageService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
