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
    public partial class Flow_flowStep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.SelectedIndexChanged += new EventHandler(GridView1_SelectedIndexChanged);
            this.panel.Visible = false;

            if (!Page.IsPostBack)
            {
                Bind();
            }
        }

        public void Bind()
        {
            string sql = "select * from FlowStep where FlowID=" + Request.QueryString["id"].ToString() + " order by Num";
            GridView1.DataSource = OperateDB.ExecuteDataSet(sql);

            GridView1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strid = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
            string sql = "delete from FlowStepPerson where StepID=" + strid;
            OperateDB.ExecuteNonQuery(sql);
            string sql1 = "delete from FlowStep where ID=" + strid;
            if (OperateDB.ExecuteNonQuery(sql1) != 1)
            {
                Response.Write("<script language=javascrip>alert('删除成功！')</script>");
            }
            Bind();
        }

        public string getAction(string id)
        {
            string sql = "select Name from FlowAction where ID=" + id;
            string action = OperateDB.getExecuteScalar(sql);
            return action;
        }

        public string getPerson(string id)
        {
            string person = null;
            string strSql = "select Name from Employee where Employeeid in (select UserID from FlowStepPerson where StepID=" + Convert.ToInt32(id) + ")";
            DataSet ds = OperateDB.ExecuteDataSet(strSql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                person += dr["Name"].ToString();
                person += ";";
            }
            return person;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            this.panel.Visible = true;

            Button1.Visible = true;
            Button3.Visible = false;
            BindAction();
            txtNum.Text = "";
            drpEnd.SelectedIndex = 0;
            drpJoin.SelectedIndex = 0;
            txtDes.Text = "";
        }

        private void BindAction()
        {
            string strSql = "select * from FlowAction";
            DataSet ds = OperateDB.ExecuteDataSet(strSql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                this.drpAction.Items.Add(new ListItem(dr["Name"].ToString(), dr["ID"].ToString()));
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string action = this.drpAction.SelectedItem.Value.ToString(); ;
            int num = Convert.ToInt32(this.txtNum.Text);
            string join = this.drpJoin.SelectedItem.Value.ToString();
            string end = this.drpEnd.SelectedItem.Value.ToString();
            string des = this.txtDes.Text;
            int flowid = Convert.ToInt32(Request.QueryString["id"]);
            string strSql = "insert into FlowStep values(" + action + "," + join + ",'" + des + "'," +
                num + "," + flowid + "," + end + ")";
            if (OperateDB.ExecuteNonQuery(strSql) != 1)
            {
                Response.Write("<script language=javascript>alert('保存失败！')</script>");
            }
            Bind();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.GridView1.DataKeys[this.GridView1.SelectedIndex]["flowid"].ToString()
            this.panel.Visible = true;

            Button3.Visible = true;
            Button1.Visible = false;
            BindAction();
            string sql = "select * from FlowStep where ID=" + this.GridView1.DataKeys[this.GridView1.SelectedIndex][0].ToString();
            DataSet ds = OperateDB.ExecuteDataSet(sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                this.txtNum.Text = dr["Num"].ToString();
                this.txtDes.Text = dr["Des"].ToString();
                this.drpAction.SelectedValue = dr["ActionID"].ToString();
                this.drpEnd.SelectedValue = dr["isEnd"].ToString();
                this.drpJoin.SelectedValue = dr["isJoin"].ToString();
            }

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string action = this.drpAction.SelectedItem.Value.ToString(); ;
                int num = Convert.ToInt32(this.txtNum.Text);
                string join = this.drpJoin.SelectedItem.Value.ToString();
                string end = this.drpEnd.SelectedItem.Value.ToString();
                string des = this.txtDes.Text;
                int flowid = Convert.ToInt32(this.GridView1.DataKeys[this.GridView1.SelectedIndex][0].ToString());
                string strSql = "update FlowStep set ActionID=" + action + ",IsJoin=" + join + ",Des='" + des + "',Num=" + num + ",IsEnd=" + end + " where ID=" + flowid;
                if (OperateDB.ExecuteNonQuery(strSql) > 0)
                {

                }
                else
                {
                    Response.Write("<script>alert('保存失败！');</script>");
                }
                Bind();
            }
            catch (Exception)
            {

                Response.Write("<script>alert('登录超时，请重新登录！');window.location.href='../Login.aspx'</script>");
            }

        }





    }
}