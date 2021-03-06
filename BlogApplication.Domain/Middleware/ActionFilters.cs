﻿using BlogApplication.Domain.Common;
using BlogApplication.Domain.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Domain.Middleware
{
    /// <summary>
    /// There are two-level authorization for admin panel
    /// 1. [Authorize] - Verify that user is authenticated
    /// 2. [VerifyProfile] - Verify that user has profile
    /// If user does not have profile - any admin actions
    /// redirected to setup page that must be completed
    /// </summary>
    public class VerifyProfile : ActionFilterAttribute
    {
        DbContextOptions<BlogDbContext> _options;

        public VerifyProfile()
        {
            var builder = new DbContextOptionsBuilder<BlogDbContext>();

            ApplicationSettings.DatabaseOptions(builder);

            _options = builder.Options;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            using (var context = new BlogDbContext(_options))
            {
                var user = filterContext.HttpContext.User.Identity.Name;
                if (context.Profiles.SingleOrDefaultAsync(p => p.IdentityName == user).Result == null)
                {
                    filterContext.Result = new RedirectResult("~/admin/setup");
                }
            }
        }
    }

    public class MustBeAdmin : ActionFilterAttribute
    {
        DbContextOptions<BlogDbContext> _options;

        public MustBeAdmin()
        {
            var builder = new DbContextOptionsBuilder<BlogDbContext>();

            ApplicationSettings.DatabaseOptions(builder);

            _options = builder.Options;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            using (var context = new BlogDbContext(_options))
            {
                var loggedUser = filterContext.HttpContext.User.Identity.Name;
                var profile = context.Profiles.SingleOrDefaultAsync(p => p.IdentityName == loggedUser).Result;

                if(profile == null || !profile.IsAdmin)
                {
                    filterContext.Result = new RedirectResult("~/Error/403");
                }
            }
        }
    }
}