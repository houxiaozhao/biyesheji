using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace OA.admin.Email
{
    public partial class EmailMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["sid"].ToString());
            string sql1 = "update Email set Status='已查看' where sid=" + id;
            OperateDB.ExecuteNonQuery(sql1);

            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string sql = "select * from Email,Employee where Email.sid=" + id + " and Employee.username='" + Session["UserName"].ToString() + "'";
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                this.meetname.InnerText = dr["Meetname"].ToString();
                this.title.InnerText = dr["title"].ToString();
                this.sendname.InnerText =   dr["sendname"].ToString();
                this.pubdate.InnerText = dr["pubdate"].ToString();
                this.Contents.InnerText = dr["Content"].ToString();
                string[] a;
                a = dr["Appurtenance"].ToString().Split(';');
                string[] AccIDList = { "0" };
                this.appurtenance.InnerHtml = "附  件:";
                for (int i = 0; i < a.Length; i++)
                {
                    this.appurtenance.InnerHtml += "<a href=\"upfiles/"
                            + a[i]
                            + "\" target=\"_blank\">"
                            + a[i]
                            + "</a>" + "&nbsp" + "&nbsp";
                }
            }
            con.Close();
        
        }
    }
}