using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace OA.admin.CalendarManage
{
    public partial class CalenderMessage : System.Web.UI.Page
    {
        public int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            if (Request["id"] != null)
            {
                id = Convert.ToInt32(Request["id"].ToString());
                bind();
            }
            }
        }

        private void bind()
        {
            ArrayList al = new ArrayList();
            al = SelectCalendars(id);
           

            this.title.InnerText = al[0].ToString();
            this.time.InnerText = al[2].ToString();
            this.content.InnerText = al[1].ToString();
            this.CalendarID.InnerText = al[3].ToString();
        }
        public ArrayList SelectCalendars(int Id)
        {
            ArrayList al = new ArrayList();
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string sql = "select * from Calendar where CalendarID=" + Id + "";
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                al.Add(dr["Motif"].ToString());
                al.Add(dr["Content"].ToString());
                al.Add(dr["AddTime"].ToString());
                al.Add(dr["CalendarID"].ToString());

            }
            return al;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string title = this.title.InnerHtml;
            if (this.title.InnerText.Trim() == "" || this.content.InnerText.Trim() == "" || this.time.InnerText.Trim() == "")
            {
                Response.Write("<script>alert('请输入详细信息!!')</script>");
            }
            else
            {
                string sql = "update Calendar set Motif='" + this.title.InnerText.Trim() + "',Content='" + this.content.InnerText.Trim() + "',addtime='" + this.time.InnerText.Trim() + "'  where CalendarID='" + Request["id"].ToString() + "'";
                if (OperateDB.ExecuteNonQuery(sql)>0)
                {
                    Response.Write("<script>alert('修改成功！！')</script>");

                }
                else
                {
                    Response.Write("<script>alert('出错啦！！')</script>");
                }
            }
        }

        public string qwe(string CalendarID, string title, string time, string content)
        {
            if (CalendarID == null || title == null || title == null || content == null)
            {
                return "asd";
            }
            else
            {
                string sql = "update Calendar set Motif='" + title.Trim() + "',Content='" + content.Trim() + "',addtime='" + time.Trim() + "'  where CalendarID='" + CalendarID + "'";
                OperateDB.ExecuteNonQuery(sql);
                this.title.InnerText = title;
                this.time.InnerText = time;
                this.content.InnerText = content;
                this.CalendarID.InnerText = CalendarID;
                return "asd";
            }

        }
    }
}