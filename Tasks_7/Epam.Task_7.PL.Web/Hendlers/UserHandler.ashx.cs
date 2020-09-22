using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Web;

using Epam.Task_7.Common;
using Epam.Task_7.Common.Entities;
using Epam.Task_7.BLL.Interfaces;
using Epam.Task_7.BLL;

namespace Epam.Task_7.PL.Web.Hendlers
{
    public class UserHandler : IHttpHandler
    {
        private static IBll _bll = DependencyResolver.Bll;

        private static IEnumerator<User> _enumerable;

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["updateUser"] != null)
            {
                UpdateUser(context);
            }
            else if (context.Request["removeUser"] != null)
            {
                RemoveUser(context);
            }
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        private void UpdateUser(HttpContext context)
        {
            string jsonStr;

            context.Response.ContentType = "application/json";

            if (_enumerable == null)
            {
                _enumerable = _bll.Users.GetAllUsers().GetEnumerator();
            }

            if (_enumerable.MoveNext())
            {
                var objUser = new AwardedUser(
                    _enumerable.Current.Id,
                    _enumerable.Current.Name,
                    _enumerable.Current.DateOfBirth,
                    _enumerable.Current.Login,
                    _enumerable.Current.Password,
                    _enumerable.Current.Role
                    );

                foreach (var item in _enumerable.Current.AwardList)
                {
                    objUser.AwardList.Add(_bll.Awards.GetAward(item));
                }

                jsonStr = JsonConvert.SerializeObject(objUser);

                context.Response.Write(jsonStr);
            }
            else
            {
                context.Response.Write(null);

                _enumerable = null;
            }
        }
        private void RemoveUser(HttpContext context)
        {
            _bll.Users.RemoveUser(Guid.Parse(context.Request["removeUser"]), _bll);
        }
    }
}