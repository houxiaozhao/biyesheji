using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using OA.Account;
using System.IO;
using System.Text;
using System.Net;

namespace OA
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string num=getemailnum(getname());
            if (num!="0")
            {
                this.emailcount.InnerText = num;
                this.title.InnerHtml = "You have " + num + " Mails";
                string sql = "select * from Email where Meetname='" + getname() + "' and Status = '未读'";
                this.dl.DataSource = OperateDB.ExecuteDataSet(sql);
                dl.DataBind();
              
            }
            

        }

        private static string getemailnum(string Name)
        {
            string sql1 = string.Format(@"SELECT  COUNT(*) AS Expr1
FROM      Email
WHERE   (Meetname = '{0}') AND (Status = '未读')", Name);
            string s = OperateDB.getExecuteScalar(sql1);
            return s;
        }

        public  string getname()
        {
            string sql = "select Name from Employee where username='" + Session["UserName"].ToString() + "'";

            string Name = OperateDB.getExecuteScalar(sql);
            return Name;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect(Request.ApplicationPath + "Account/Login.aspx");
        }


       


    }
}