using System.Collections.Generic;
using System.Threading.Tasks;
using DemoKentico.Common.Models;

namespace DemoKentico.Core.Services
{
    /// <summary>
    /// Service interface for retrieving page data from Kentico.
    /// Equivalent to the page-retrieval logic in DFGC.Core.
    /// </summary>
    public interface IPageService
    {
        Task<(Page? Page, IEnumerable<object> Components)> GetPageAsync(int webPageItemId, string languageName, string channelName);
    }
}
