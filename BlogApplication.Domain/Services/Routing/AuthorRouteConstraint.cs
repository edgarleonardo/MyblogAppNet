using BlogApplication.Domain.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogApplication.Domain.Services.Routing
{
    public class AuthorRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values["slug"] != null)
            {
                var slug = values["slug"].ToString();
                var _context = new BlogDbContext(new DbContextOptions<BlogDbContext>());

                return _context.Profiles.Where(p => p.Slug == slug).FirstOrDefault() != null;
            }
            return false;
        }
    }
}