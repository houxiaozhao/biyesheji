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
    public partial class GoOutRegist : System.Web.UI.Page
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
            string sql = "select * from OutRegister where username='" + Session["UserName"].ToString() + "'";

            this.dt1.DataSource = OperateDB.ExecuteDataSet(sql);
            dt1.DataBind();
            string strsql = "select OutRegisterid from OutRegister where ReturnTime='未归' and username='"+Session["UserName"]+"'";
            id = Convert.ToInt32(OperateDB.getExecuteScalar(strsql));


        }

        protected void goout_Click(object sender, EventArgs e)
        {
            string strsql = "select OutRegisterid from OutRegister where ReturnTime='未归' and username='" + Session["UserName"] + "'";
            id = Convert.ToInt32(OperateDB.getExecuteScalar(strsql));


            if (id != 0)
            {
                Response.Write("<script>alert('还没有回来登记！不能登记外出')</script>");
            }
            else
            {

                DateTime Da = DateTime.Now;
                string sql = "insert into  OutRegister values('" + Da.ToString() + "','未归','" + Session["UserName"].ToString() + "','" + this.TextArea1.Value + "','" + Da.ToLongDateString() + "');select @@IDENTITY AS ID;";


                id = Convert.ToInt32(OperateDB.ExecuteNonQuery(sql));
                Response.Write("<script>alert('外出登记成功！')</script>");
            }


            Bind();

        }
        protected void comeback_Click(object sender, EventArgs e)
        {
            string strsql = "select OutRegisterid from OutRegister where ReturnTime='未归' and username='" + Session["UserName"] + "'";
            id = Convert.ToInt32(OperateDB.getExecuteScalar(strsql));

            if (id == 0)
            {
                Response.Write("<script>alert('你还没有外出！')</script>");
            }
            else
            {


                DateTime dt = DateTime.Now;
                string sql = "update OutRegister set returntime='" + dt.ToString() + "' where OutRegisterid='" + id + "'";
                if (OperateDB.ExecuteNonQuery(sql) > 0)
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