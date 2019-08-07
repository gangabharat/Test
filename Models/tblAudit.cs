using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using Arduino;

namespace Arduino.Models
{
    public class tblAudit
    {
        [Key]
        public int AuditID { get; set; }
        public string UserID { get; set; }
        public string SessionID { get; set; }
        public string IPAddress { get; set; }
        public string PageAccessed { get; set; }
        public Nullable<System.DateTime> LoggedInAt { get; set; }
        public Nullable<System.DateTime> LoggedOutAt { get; set; }
        public string LoginStatus { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string UrlReferrer { get; set; }

        public int SaveAudit(tblAudit otblAudit)
        {
            int res = -1;
            using (SqlConnection objcon = new SqlConnection(Database.ConnectionString))
            {
                SqlCommand objcommand = new SqlCommand("USP_IUD_Audit", objcon);
                objcommand.CommandType = CommandType.StoredProcedure;
                objcommand.Parameters.AddWithValue("@pMode", "3");
                objcommand.Parameters.AddWithValue("@pAuditID", otblAudit.AuditID);
                objcommand.Parameters.AddWithValue("@pUserID", otblAudit.UserID);
                objcommand.Parameters.AddWithValue("@pSessionID", otblAudit.SessionID);
                objcommand.Parameters.AddWithValue("@pIPAddress", otblAudit.IPAddress);
                objcommand.Parameters.AddWithValue("@pPageAccessed", otblAudit.PageAccessed);
                objcommand.Parameters.AddWithValue("@pLoggedInAt", otblAudit.LoggedInAt);
                objcommand.Parameters.AddWithValue("@pLoggedOutAt", otblAudit.LoggedOutAt);
                objcommand.Parameters.AddWithValue("@pLoginStatus", otblAudit.LoginStatus);
                objcommand.Parameters.AddWithValue("@pControllerName", otblAudit.ControllerName);
                objcommand.Parameters.AddWithValue("@pActionName", otblAudit.ActionName);
                objcommand.Parameters.AddWithValue("@pUrlReferrer", otblAudit.UrlReferrer);
                objcon.Open();
                res = objcommand.ExecuteNonQuery();
                objcon.Close();
            }
            return res;
        }
    }
}