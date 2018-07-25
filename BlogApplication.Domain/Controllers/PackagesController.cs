using BlogApplication.Domain.Common;
using BlogApplication.Domain.Data.Domain;
using BlogApplication.Domain.Data.Interfaces;
using BlogApplication.Domain.Data.Models;
using BlogApplication.Domain.Middleware;
using BlogApplication.Domain.Services.Packages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogApplication.Domain.Controllers
{
    [Authorize]
    [Route("admin/[controller]")]
    public class PackagesController : Controller
	{
		private readonly string _theme;
        IUnitOfWork _db;
        IPackageService _pkgs;

		public PackagesController(IUnitOfWork db, IPackageService pkgs)
		{
			_db = db;
            _pkgs = pkgs;
			_theme = $"~/{ApplicationSettings.BlogAdminFolder}/";
		}

        [VerifyProfile]
        [HttpGet("widgets")]
        public async Task<IActionResult> Widgets()
        {
            var model = new AdminPackagesModel {
                Profile = GetProfile(),
                Packages = await _pkgs.Find(PackageType.Widgets)
            };
            return View($"{_theme}Packages/Widgets.cshtml", model);
        }

        [VerifyProfile]
        [HttpGet("themes")]
        public IActionResult Themes()
        {
            var model = new AdminPackagesModel { Profile = GetProfile() };
            model.Packages = new List<PackageListItem>();

            return View($"{_theme}Packages/Themes.cshtml", model);
        }

        private Profile GetProfile()
        {
            return _db.Profiles.Single(b => b.IdentityName == User.Identity.Name);
        }
    }
}