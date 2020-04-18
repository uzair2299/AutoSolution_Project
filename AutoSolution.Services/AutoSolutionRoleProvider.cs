using AutoSolution.Database.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace AutoSolution.Services
{
    public class AutoSolutionRoleProvider : RoleProvider
    {

   
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            //foreach (string rolename in roleNames)
            //{
            //    if (rolename == null || rolename == "")
            //        throw new ProviderException("Role name cannot be empty or null.");
            //    if (!RoleExists(rolename))
            //        throw new ProviderException("Role name not found.");
            //}

            //foreach (string username in usernames)
            //{
            //    if (username == null || username == "")
            //        throw new ProviderException("User name cannot be empty or null.");
            //    if (username.Contains(","))
            //        throw new ArgumentException("User names cannot contain commas.");

            //    foreach (string rolename in roleNames)
            //    {
            //        if (IsUserInRole(username, rolename))
            //            throw new ProviderException("User is already in role.");
            //    }
            //}



            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            RoleRepository roleRepository = new RoleRepository(new AutoSolutionContext());

            var Roles = roleRepository.GetAll();
            string[] RolesArray = new string[6];
               for (var item = 0; item < Roles.Count; item++)
                {
                    RolesArray[item] = Roles[item].RoleName;
                }
            return RolesArray;
        }

        public override string[] GetRolesForUser(string username)
        {
            RoleRepository roleRepository = new RoleRepository(new AutoSolutionContext());
            return roleRepository.CheckIsUserInRole(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool userIsInRole = false;

            if (username == null || username == "")
                throw new ProviderException("User name cannot be empty or null.");
            if (roleName == null || roleName == "")
                throw new ProviderException("Role name cannot be empty or null.");

            var roles = GetRolesForUser(username);
            if (roles==null)
            {
                 return userIsInRole;
            }
            else
            {
                userIsInRole = true;
                return userIsInRole;
            }

       }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string RoleName)
        {
            if (RoleName == null || RoleName == "")
                throw new ProviderException("Role name cannot be empty or null.");
            var roles = GetAllRoles();

            foreach (string role in roles)

            {

                if (role.Equals(RoleName))

                {

                    return true;

                }
            }
            return false;
        }
    }
}
