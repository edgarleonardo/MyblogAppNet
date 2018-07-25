using BlogApplication.Domain.Data.Domain;
using BlogApplication.Domain.Data.Interfaces;
using BlogApplication.Domain.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogApplication.Domain.Controllers.Api
{
    [Authorize]
    [Route("blogifier/api/[controller]")]
    public class ProfileController : Controller
    {
        IUnitOfWork _db;

        public ProfileController(IUnitOfWork db)
        {
            _db = db;
        }

        // PUT: api/profile/setcustomfield
        [HttpPut]
        [Route("setcustomfield")]
        public async Task SetCustomField([FromBody]CustomFieldItem item)
        {
            var profile = GetProfile();
            await _db.CustomFields.SetCustomField(CustomType.Profile, profile.Id, item.CustomKey, item.CustomValue);
        }

        Profile GetProfile()
        {
            try
            {
                return _db.Profiles.Single(p => p.IdentityName == User.Identity.Name);
            }
            catch
            {
                RedirectToAction("Login", "Account");
            }
            return null;
        }
    }
}