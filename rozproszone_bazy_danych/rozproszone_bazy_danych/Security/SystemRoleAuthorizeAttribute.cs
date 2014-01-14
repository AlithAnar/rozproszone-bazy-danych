using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using rozproszone_bazy_danych.Security;
using rozproszone_bazy_danych.Models;

namespace rozproszone_bazy_danych.Security
{
    public class SystemRoleAuthorizeAttribute : AuthorizeAttribute
    {
        public string RequiredSystemRole { get; set; }
        DataBaseManager dm;
        /// <summary>
        /// Checks permissions using SystemRole enum.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            dm = new DataBaseManager();
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }
            if (dm.IsInRole(httpContext.User.Identity.Name, RequiredSystemRole))
            {
                return true;
            }

            return false;
        }

    }
}