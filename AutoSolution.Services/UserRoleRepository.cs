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
    public class UserRoleRepository: AutoSolutionRepository<UserType>, IUserRoleRepository
    {
        public UserRoleRepository( AutoSolutionContext context) : base(context) { }

        public IEnumerable<SelectListItem> GetUserRoles()
        {
            
                List<SelectListItem> items = Context.Set<UserType>().Where(n=>n.UserTypeName == "Service Provider"   || n.UserTypeName== "Client") .Select(n => new SelectListItem
                {
                    Value = n.UserTypeId.ToString(),
                    Text = n.UserTypeName
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
