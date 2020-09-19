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
    public class AwardHandler : IHttpHandler
    {
        private static IBll _bll = DependencyResolver.Bll;

        private static IEnumerator<Award> _enumerable;

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["updateAward"] != null)
            {
                UpdateAward(context);
            }
            else if (context.Request["removeAward"] != null)
            {
                RemoveAward(context);
            }
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        private void UpdateAward(HttpContext context)
        {
            string jsonStr;

            context.Response.ContentType = "application/json";

            if (_enumerable == null)
            {
                _enumerable = _bll.Awards.GetAllAwards().GetEnumerator();
            }

            if (_enumerable.MoveNext())
            {
                var objAward = new CustomAward(
                    _enumerable.Current.Id,
                    _enumerable.Current.Title
                    );

                foreach (var item in _enumerable.Current.OwnerList)
                {
                    objAward.OwnerList.Add(_bll.Users.GetUser(item));
                }

                jsonStr = JsonConvert.SerializeObject(objAward);

                context.Response.Write(jsonStr);
            }
            else
            {
                context.Response.Write(null);

                _enumerable = null;
            }
        }
        private void RemoveAward(HttpContext context)
        {
            _bll.Awards.RemoveAward(Guid.Parse(context.Request["removeAward"]), _bll);
        }
    }
}