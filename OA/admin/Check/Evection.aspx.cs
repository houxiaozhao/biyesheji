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
    public partial class Evection : System.Web.UI.Page
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
            string sql = "select * from Evection where username='" + Session["UserName"].ToString() + "'";
            this.dt1.DataSource = OperateDB.ExecuteDataSet(sql);
            dt1.DataBind();
            string strsql = "select Evectionid from Evection where rtime='未回'";
            id = Convert.ToInt32(OperateDB.getExecuteScalar(strsql));


        }
        protected void goout_Click(object sender, EventArgs e)
        {

            string strsql = "select Evectionid from Evection where rtime='未回'";
            id = Convert.ToInt32(OperateDB.getExecuteScalar(strsql));
            string add = this.add.Text;
            if (string.IsNullOrEmpty(add))
            {
                Response.Write("<script>alert('请输入地点')</script>");
            }
            else
            {
                if (id != 0)
                {
                    Response.Write("<script>alert('还没有回来登记！不能登记出差')</script>");
                }
                else
                {
                    DateTime Da = DateTime.Now;
                    string sql = "insert into  Evection values('" + add + "','" + Da + "','未回','" + this.TextArea1.Value + "','" + Session["UserName"].ToString() + "')";
                    id = Convert.ToInt32(OperateDB.getExecuteScalar(sql));
                    Response.Write("<script>alert('出差登记成功！')</script>");
                }
            }
            Bind();

        }
        protected void comeback_Click(object sender, EventArgs e)
        {
            string strsql = "select Evectionid from Evection where rtime='未回'";
            id = Convert.ToInt32(OperateDB.getExecuteScalar(strsql));

            if (id == 0)
            {
                Response.Write("<script>alert('你还没有出差！')</script>");
            }
            else
            {


                DateTime dt = DateTime.Now;
                string sql = "update Evection set rtime='" + dt + "' where Evectionid='" + id + "'";
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