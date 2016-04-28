using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OA.admin.Plan
{
    public partial class Plan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            string sql = "select * from [Plan] where username='" + Session["UserName"].ToString() + "'";
            this.dtlst.DataSource = OperateDB.ExecuteDataSet(sql);
            this.dtlst.DataBind();
        }
        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            int PlanId = Convert.ToInt32(e.CommandArgument);
            string sql = "Delete from [Plan] where Planid=" + PlanId + ""; 
            OperateDB.ExecuteNonQuery(sql);
            Response.Write("<script>alert('删除成功！')</script>");
            Bind();
        }
        protected void Button2_Command(object sender, CommandEventArgs e)
        {

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            DateTime starttime = Convert.ToDateTime(this.calendar1.Text);
            DateTime endtime = Convert.ToDateTime(this.calendar2.Text);
            string sql = "select * from [Plan] where addtime between '" + starttime + "' and'" + endtime + "' and username='" + Session["UserName"].ToString() + "'";
            this.dtlst.DataSource = OperateDB.ExecuteDataSet(sql);
            this.dtlst.DataBind();
        }
    }
}