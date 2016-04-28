using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OA.admin.flow
{
    public partial class Flow_MyApplyList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
                if (Request.QueryString["id"] != null)
                {
                    send();
                }
                if (Request.QueryString["fdid"] != null)
                {
                    del();
                }
            }

        }
        public void Bind()
        {
            Sqlselete ss = new Sqlselete();
            int userid = Convert.ToInt32(ss.SelectEmpByUserName(Session["UserName"].ToString()));
            string sql = "select * from FlowDoc where UserID=" + userid;
            DataSet ds = ss.Getds(sql);
            this.GridView1.DataSource = ds.Tables[0];
            this.GridView1.DataBind();
        }
        public string getFlow(string id)
        {
            Sqlselete ss = new Sqlselete();
            string sql = "select Name from Flow where ID=" + Convert.ToInt32(id);
            string flow = ss.getScalar(sql);
            return flow;
        }

        public string getStep(string id)
        {
            string step = null;
            string sql = "select IsEnd from FlowDoc where ID=" + Convert.ToInt32(id);
            Sqlselete ss = new Sqlselete();

            int end = Convert.ToInt32(ss.getScalar(sql));
            if (end > 0)
            {
                step = "完成";
            }
            else
            {
                string sqlstr = "select * from FlowPath where DocID=" + Convert.ToInt32(id);
                DataSet ds = ss.Getds(sqlstr);
                //Response.Write("<script>alert('" + dr["IsApprove"].ToString() + "')</script>");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (Convert.ToInt32(dr["IsApprove"]) != 2)
                    {
                        string sql1 = "select Name from FlowAction where ID in (select ActionId from FlowStep where Num=" + Convert.ToInt32(dr["Num"]) + " and FlowID=" + Convert.ToInt32(dr["FlowID"]) + ")";
                        step = new Sqlselete().getScalar(sql1).ToString();
                        break;
                    }
                }
            }
            return step;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }

        public void send()
        {

            int approve = Convert.ToInt32(new Sqlselete().getScalar("select top 1 Num from Path where FlowID=" + Convert.ToInt32(Request.QueryString["flowid"]) + " order by Num desc"));
            int userid = Convert.ToInt32(new Sqlselete().getScalar("select Employeeid from Employee where username='" + Session["UserName"].ToString() + "'"));
            int num = Convert.ToInt32(new Sqlselete().getScalar("select Num from Path where UserID=" + userid));
            DataSet ds = new Sqlselete().Getds("select * from Path where FlowID=" + Convert.ToInt32(Request.QueryString["flowid"]));
            int result = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (Convert.ToInt32(dr["UserID"]) == userid)
                {
                    string strSql = "insert into FlowPath (DocID,FlowID,StepID,UserID,IsApprove,Num,IsJoin) values(" + Convert.ToInt32(Request.QueryString["id"]) + "," +
                    Convert.ToInt32(dr["FlowID"]) + "," + Convert.ToInt32(dr["ID"]) + "," + dr["UserID"].ToString() + "," + (approve - Convert.ToInt32(dr["Num"])) + "," + dr["Num"].ToString() + "," + dr["IsJoin"].ToString() + ")";
                    result = new Sqlselete().Query(strSql);




                    //result = new DBoperate().ExecuteUpdate(strSql);
                    continue;
                }
                if (Convert.ToInt32(dr["Num"]) > num)
                {
                    string strsql = "insert into FlowPath (DocID,FlowID,StepID,UserID,IsApprove,Num,IsJoin) values(" + Convert.ToInt32(Request.QueryString["id"]) + "," +
                        Convert.ToInt32(dr["FlowID"]) + "," + Convert.ToInt32(dr["ID"]) + "," + dr["UserID"].ToString() + "," + (approve - Convert.ToInt32(dr["Num"])) + "," + dr["Num"].ToString() + "," + dr["IsJoin"].ToString() + ")";
                    result = new Sqlselete().Query(strsql);
                }
            }
            //修改FlowDoc表中IsSave字段值
            if (result > 0)
            {
                string strSql = "update FlowDoc set IsSave=0 where FlowID=" + Convert.ToInt32(Request.QueryString["flowid"]);


                int rs = new Sqlselete().Query("update FlowDoc set IsSave=0 where FlowID=" + Convert.ToInt32(Request.QueryString["flowid"]));
            }
            Bind();
        }



        public void del()
        {

            int result = new Sqlselete().Query("delete from FlowDoc where ID=" + Request.QueryString["fdid"]);
        }
    }
}