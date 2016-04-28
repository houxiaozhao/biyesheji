using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace OA.admin.Note
{
    public partial class noteMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            if (!string.IsNullOrEmpty(Request["NotepaperID"]))
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                con.Open();
                int NotepaperID = Convert.ToInt32(Request["NotepaperID"].ToString());
                string sql = "select * from Notepaper where NotepaperID=" + NotepaperID + " ";
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    this.NotepaperID.InnerText = dr["NotepaperID"].ToString();
                    this.title.InnerText = dr["title"].ToString();
                    this.addtime.InnerText = dr["addtime"].ToString();
                    this.message.InnerText = dr["message"].ToString();
                }
                con.Close();
            }
            else
            {

            }
            //}
        }
        public string qwe(string NotepaperID, string title, string addtime, string message)
        {
            if (addtime == null || message == null || title == null)
            {
                return "ad";
            }
            else
            {
                if (string.IsNullOrEmpty(NotepaperID) && addtime != null && message != null && title != null)
                {
                    string sql = "insert  Notepaper values('" + message + "','" + DateTime.Now + "','" + Session["UserName"].ToString() + "','" + title + "')";
                    if (OperateDB.ExecuteNonQuery(sql) == 1)
                    {
                        Response.Write("<script>alert('添加成功!');</script>");
                        this.title.InnerText = "";
                        this.addtime.InnerText = "";
                        this.message.InnerText = "";
                        this.NotepaperID.InnerText = "";
                    }

                    return "asd";
                }
                else
                {
                    string sql = "update Notepaper set title='" + title.Trim() + "',message='" + message.Trim() + "',Addtime='" + addtime.Trim() + "'  where NotepaperID='" + NotepaperID + "'";

                    OperateDB.ExecuteNonQuery(sql);
                    this.title.InnerText = title;
                    this.addtime.InnerText = addtime;
                    this.message.InnerText = message;
                    this.NotepaperID.InnerText = NotepaperID;
                    return "asd";
                }
            }

        }
    }
}