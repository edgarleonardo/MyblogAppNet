using BlogApplication.Domain.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Widgets
{
    [ViewComponent(Name = "Newsletter")]
    public class Newsletter : ViewComponent
    {
        IUnitOfWork _db;

        public Newsletter(IUnitOfWork db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}