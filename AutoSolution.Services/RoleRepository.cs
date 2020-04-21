using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services
{
    public class RoleRepository : AutoSolutionRepository<Roles>, IRoleRepository
    {

        public RoleRepository(AutoSolutionContext context)
          : base(context)
        {
        }


        public string[] CheckIsUserInRole(string username)
        {
            var userRoles = (from u in AutoSolutionContext.User

                             join ur in AutoSolutionContext.UserRoles
                             on u.UserId equals ur.UserId

                             join role in AutoSolutionContext.Roles
                                 on ur.RolesId equals role.RolesId

                             where u.Email == username
                             select role.RoleName).ToArray();

            if (userRoles != null)
                return userRoles;
            else
                return new string[] { }; 
        }

        public string[] GetAllAutoSoltuinRoles()
        {
            throw new NotImplementedException();
        }


        public List<UserRoles> AddRolesTOUser(string user ,string role)
        {
            if(role == "User")
            {
                List<UserRoles> userRoles = new List<UserRoles>();
                AutoSolutionRoleProvider autoSolutionRoleProvider = new AutoSolutionRoleProvider();
                bool isExist = autoSolutionRoleProvider.RoleExists(role);
                if(isExist==true)
                {
                   bool IsInRole= autoSolutionRoleProvider.IsUserInRole(user, role);
                    if(IsInRole==true)
                    {
                        UserRoles userRoles1 = new UserRoles();
                        Roles roles = new Roles();
                       var id = AutoSolutionContext.Roles.Where(x => x.RoleName == role).Select(x=>x.RolesId).FirstOrDefault();
                        userRoles1.RolesId = id;
                        userRoles.Add(userRoles1);
                        return userRoles;
                    }

                }


            }
            return null;
        }

        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }
}
