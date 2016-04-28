using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OA.admin.CalendarManage
{
    public partial class HavingCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.divadd.Visible = false;
            if (!IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
           

            string UserName = Session["UserName"].ToString();
            string sql = "select id from UserInfo where UserName='" + UserName + "'";
            int id =Convert.ToInt32( OperateDB.getExecuteScalar(sql));
            string sql1 = "select * from Calendar where id=" + id + " order by CalendarID desc";
            this.dt1.DataSource = OperateDB.ExecuteDataSet(sql1);
            this.dt1.DataBind();
        }
        protected void button_click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('af')</script>");
        }
        protected void dt1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Button Button1 = e.Item.FindControl("Button1") as Button;
            if (Button1 != null)
            {
                Button1.CommandName = e.Item.ItemIndex.ToString();
            }
        }
        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string sql = "delete from Calendar where CalendarID=" + id + "";
            if (OperateDB.ExecuteNonQuery(sql)>0)
            {
                Bind();
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {

            if (Request.Form["ctl00$ContentPlaceHolder1$addtime"].Trim() == "" || this.Motif.Text.Trim() == "" || this.textcontent.Text.Trim() == "")
            {
                this.Motif.Text = "";
                this.textcontent.Text = "";
                addtime.Text = "";
                return;
            }
            else
            {
                DateTime starttime = Convert.ToDateTime(Request.Form["ctl00$ContentPlaceHolder1$addtime"]);
                string UserName = Session["UserName"].ToString();
                log sl = new log();
                string sql = "select id from UserInfo where UserName='" + UserName + "'";
               
                int ID = Convert.ToInt32( OperateDB.getExecuteScalar(sql));
                string Motif = this.Motif.Text.Trim();
                string Content = this.textcontent.Text.Trim();
                string AddTime = addtime.Text.Trim();
                sl.InsertCalendar(ID, Motif, Content, AddTime);
                Response.Write("<script>alert('添加成功！');</script>");
                Bind();
                this.Motif.Text = "";
                this.textcontent.Text = "";
                addtime.Text = "";
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            this.divadd.Visible = true;
        }
    }
}