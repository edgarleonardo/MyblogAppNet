using BlogApplication.Domain.Data.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogApplication.Domain.Data.Interfaces
{
    public interface ICustomRepository : IRepository<CustomField>
    {
        Task<Dictionary<string, string>> GetCustomFields(CustomType customType, int parentId);
        Task<Dictionary<string, string>> GetBlogFields();
        Task<Dictionary<string, string>> GetUserFields(int profileId);

        Task SetCustomField(CustomType customType, int parentId, string key, string value);

        string GetValue(CustomType customType, int parentId, string key);
    }
}