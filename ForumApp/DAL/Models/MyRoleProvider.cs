namespace DataAccessLayer.Models
{
    using System;
    using System.Web.Security;
    using System.Configuration;

    public class MyRoleProvider : RoleProvider
    {
        DAL dal = new DAL(ConfigurationManager.ConnectionStrings["Conection"].ConnectionString);

        public override string[] GetRolesForUser(string username)
        {
            try
            {
                return dal.SelectTypeUser(username);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            try
            {
                string[] roles = GetRolesForUser(username);
                foreach (var role in roles)
                {
                    if (role.Equals(roleName))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
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

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
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
