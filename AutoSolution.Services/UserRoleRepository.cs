using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services
{
    public class UserRoleRepository: AutoSolutionRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository( AutoSolutionContext context) : base(context) { }

        public IEnumerable<SelectListItem> GetUserRoles()
        {
            
                List<SelectListItem> items = Context.Set<UserRole>().Where(n=>n.RoleName== "Service Provider"   || n.RoleName=="Client") .Select(n => new SelectListItem
                {
                    Value = n.UserRoleId.ToString(),
                    Text = n.RoleName
                }).ToList();

                var CityTip = new SelectListItem()
                {
                    Value = null,
                    Text = "          --- Select User Category ---"
                };
                items.Insert(0, CityTip);
                return new SelectList(items, "value", "Text");
        }
    }
}
