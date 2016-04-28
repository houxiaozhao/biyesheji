using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OA.admin.Plan
{
    public partial class AddPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert  [Plan] values('" + Convert.ToDateTime(this.calendar1.Text) + "','" + content.Text + "','" + titel.Text + "','" + Session["UserName"].ToString() + "')";
            if (OperateDB.ExecuteNonQuery(sql) == 1)
            {
                titel.Text = "";
                content.Text = "";
                Response.Redirect("Plan.aspx");
            }
            else
            {
                Response.Write("<script>alert('添加失败')</script>");

            }
        }
    }
}