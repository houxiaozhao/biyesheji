using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace OA.admin.News
{
    public partial class NewsAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                con.Open();
                string sql = "select * from NewsType ";
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    DropDownList1.Items.Add(new ListItem(dr["Type"].ToString(), dr["NTID"].ToString()));
                }
                DropDownList1.Items.Insert(0, "全部");
                con.Close();
                
            }
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            log si = new log();
            string title = this.titel.Text;
            string content = this.content.Text;
            int type = Convert.ToInt32(this.DropDownList1.SelectedItem.Value);
            int remark = 1;
            string sql = "select Employeeid from Employee where username='" + Session["UserName"] + "'";
            int userid = Convert.ToInt32(OperateDB.getExecuteScalar(sql));

            string strSql = "insert into News values(" + type + ",'" + title + "','" + content + "'," + remark + "," + userid + ",default)";
            if (OperateDB.ExecuteNonQuery(strSql)>0)
            {
                si.InsertWorkLog(Session["UserName"].ToString(), DateTime.Now.ToString(), "添加了标题为：" + title + "的新闻");
                Response.Write("<script>alert('发布成功！');</script>");
                this.titel.Text = "";
                this.content.Text = "";
            }
            else
            {
                Response.Write("<script>alert('发布失败！');</script>");
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            this.titel.Text = "";
            this.content.Text = "";
        }
    }
}