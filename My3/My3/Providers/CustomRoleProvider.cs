using My3Business;
using My3Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace My3.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private IBusinessLayer businessLayer;

        public CustomRoleProvider(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
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
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };

            User user = this.businessLayer.GetUserByEmail(username);

            if (user!=null)
            {
                string userRole = user.Role;
                if (userRole != null)
                    roles = new string[] { userRole };
            }
            return roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
           

            User user = this.businessLayer.GetUserByEmail(username);

            if (user != null)
            {
                string userRole = user.Role;
                if ((userRole != null) && (userRole == roleName))
                    outputResult = true;
            }
            return outputResult;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}