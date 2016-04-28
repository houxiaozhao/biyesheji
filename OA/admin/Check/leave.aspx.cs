using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace OA.admin.Check
{
    public partial class leave : System.Web.UI.Page
    {
        public int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        private void Bind()
        {
            string sql = "select * from Leave where username='" + Session["UserName"].ToString() + "'";

            this.dt1.DataSource = OperateDB.ExecuteDataSet(sql);
            dt1.DataBind();
            string strsql = "select LeaveID from Leave where retrue='未回'";
            id = Convert.ToInt32(OperateDB.getExecuteScalar(strsql));


        }
        protected void goout_Click(object sender, EventArgs e)
        {
            string strsql = "select LeaveID from Leave where retrue='未回'";
            id = Convert.ToInt32(OperateDB.getExecuteScalar(strsql));


            if (id != 0)
            {
                Response.Write("<script>alert('还没有回来登记！不能登记请假')</script>");
            }
            else
            {

                DateTime Da = DateTime.Now;
                string sql = "insert into  Leave values('" + Session["UserName"].ToString() + "','" + Da + "','未回','" + this.TextArea1.Value + "')";


                id = Convert.ToInt32(OperateDB.getExecuteScalar(strsql));
                Response.Write("<script>alert('外出登记成功！')</script>");
            }


            Bind();

        }
        protected void comeback_Click(object sender, EventArgs e)
        {
            string strsql = "select LeaveID from Leave where retrue='未回'";
            id = Convert.ToInt32(OperateDB.getExecuteScalar(strsql));

            if (id == 0)
            {
                Response.Write("<script>alert('你还没有请假！')</script>");
            }
            else
            {


                DateTime dt = DateTime.Now;
                string sql = "update Leave set retrue='" + dt + "' where LeaveID='" + id + "'";
                if (OperateDB.ExecuteNonQuery(sql)>0)
                {
                    Response.Write("<script>alert('回来登记成功！')</script>");
                }
                else
                {
                    Response.Write("<script>alert('回来登记失败！')</script>");
                }
            }

            Bind();
        }
    }
}