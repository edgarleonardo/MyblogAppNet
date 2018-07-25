using System.Threading.Tasks;
using BlogApplication.Domain.Data.Models;
using System.Net.Http;

namespace BlogApplication.Domain.Services.Syndication.Rss
{
    public interface IRssService
    {
        Task<HttpResponseMessage> Import(RssImportModel model);
        string Display(string absoluteUri, string author);
    }
}
