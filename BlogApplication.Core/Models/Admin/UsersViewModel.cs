using BlogApplication.Domain.Common;
using BlogApplication.Domain.Data.Models;
using BlogApplication.Models.AccountViewModels;
using System.Collections.Generic;

namespace BlogApplication.Models.Admin
{
    public class UsersViewModel : AdminBaseModel
    {
        public RegisterViewModel RegisterModel { get; set; }

        public IEnumerable<ProfileListItem> Blogs { get; set; }
        public Pager Pager { get; set; }
    }
}
