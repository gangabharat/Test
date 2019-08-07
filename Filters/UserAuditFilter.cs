using Arduino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arduino.Filters
{
    public class UserAuditFilter : ActionFilterAttribute
    {
        tblAudit _IAudit;
        public UserAuditFilter()
        {
            _IAudit = new tblAudit();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            tblAudit objaudit = new tblAudit(); // Getting Action Name 

            string actionName = filterContext.ActionDescriptor.ActionName; //Getting Controller Name 
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var request = filterContext.HttpContext.Request;


            if (HttpContext.Current.Session["UserID"] != null)
            {
                objaudit.UserID = Convert.ToString(HttpContext.Current.Session["UserID"]);
            }
            else if (HttpContext.Current.Session["AdminUser"] != null)
            {
                objaudit.UserID = Convert.ToString(HttpContext.Current.Session["AdminUser"]);
            }
            else            
            {
                string strUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString().Replace(Environment.UserDomainName + "\\", "").Trim().ToString();
                objaudit.UserID = strUser;
            }


            objaudit.SessionID = HttpContext.Current.Session.SessionID; // Application SessionID // User IPAddress 
            objaudit.IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress;
            objaudit.PageAccessed = Convert.ToString(filterContext.HttpContext.Request.Url); // URL User Requested 
            objaudit.LoggedInAt = DateTime.Now; // Time User Logged In || And time User Request Method 

            if (actionName == "LogOff")
            {
                objaudit.LoggedOutAt = DateTime.Now; // Time User Logged OUT 
            }

            objaudit.LoginStatus = "A";
            objaudit.ControllerName = controllerName; // ControllerName 
            objaudit.ActionName = actionName;

            Uri myReferrer = request.UrlReferrer;

            if (myReferrer != null)
            {
                string actual = myReferrer.ToString();

                if (actual != null)
                {
                    objaudit.UrlReferrer = request.UrlReferrer.AbsolutePath;
                }
            }

            _IAudit.SaveAudit(objaudit);

        }
    }
}