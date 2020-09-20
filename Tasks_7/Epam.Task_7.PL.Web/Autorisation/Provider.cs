﻿using System;
using System.Web.Security;

using Epam.Task_7.Common;
using Epam.Task_7.BLL.Interfaces;

namespace Epam.Task_7.PL.Web.Autorisation
{
    public class Provider : RoleProvider
    {
        private readonly IUsersBll _usersBll;

        public Provider()
        {
            _usersBll = DependencyResolver.Bll.Users;
        }

        public override string[] GetRolesForUser(string login)
        {
            foreach (var user in _usersBll.GetAllUsers())
            {
                if (user.Login == login)
                {
                    return new string[] { user.Role };
                }
            }

            throw new Exception("Login not fought!");
        }

        public override bool IsUserInRole(string login, string roleName)
        {
            foreach (var user in _usersBll.GetAllUsers())
            {
                if (user.Login == login)
                {
                    if (user.Role == roleName)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            throw new Exception("Login not fought!");
        }

        #region Not implemented

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
        #endregion
    }
}