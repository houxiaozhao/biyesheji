using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OA.admin.flow
{
    public partial class Flow_StepBind : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strSql = "select * from Branch";
                DataSet ds = OperateDB.ExecuteDataSet(strSql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DropDownList1.Items.Add(new ListItem(dr["Branch"].ToString(), dr["Dutyid"].ToString()));
                }
                this.DropDownList1.Items.Insert(0, "选择部门....");
                Bind();

            }
        }
        public void Bind()
        {

            Sqlselete ss = new Sqlselete();
            DataSet dsa = ss.SelectEmp("");
            ListBox1.DataSource = dsa.Tables[0];
            ListBox1.DataTextField = "Name";
            ListBox1.DataValueField = "Employeeid";
            ListBox1.DataBind();

            string strSql1 = "select * from Employee where Employeeid in (select UserID from FlowStepPerson where StepID=" + Request.QueryString["stepid"] + ")";


            this.ListBox2.DataSource = OperateDB.ExecuteDataSet(strSql1).Tables[0];
            this.ListBox2.DataTextField = "Name";
            this.ListBox2.DataValueField = "Employeeid";
            this.ListBox2.DataBind();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "选择部门....")
            {
                Bind();
            }
            else
            {
                string Dutyid = DropDownList1.SelectedItem.Value.ToString();
                string sql = "select Name,username from Employee  where dutyid=" + Dutyid + "";
                ListBox1.DataSource = OperateDB.ExecuteDataSet(sql).Tables[0];
                ListBox1.DataTextField = "Name";
                ListBox1.DataValueField = "username";
                ListBox1.DataBind();
            }
        }
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool exist = false;
            foreach (ListItem li in this.ListBox2.Items)
            {
                if (li.Value == this.ListBox1.SelectedItem.Value)
                {
                    exist = true;
                }
            }
            if (exist == false)
            {
                this.ListBox2.Items.Add(new ListItem(this.ListBox1.SelectedItem.Text, this.ListBox1.SelectedItem.Value));
            }
        }
        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ListBox2.Items.Count; i++)
            {
                if (this.ListBox2.Items[i].Selected == true)
                {
                    ListBox2.Items.Remove(this.ListBox2.Items[i]);

                }

            }
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            int stepid = Convert.ToInt32(Request.QueryString["stepid"]);
            for (int i = 0; i < this.ListBox2.Items.Count; i++)
            {
                string strSql = "select * from FlowStepPerson where UserID=" + ListBox2.Items[i].Value + " and StepID=" + stepid;
                if (OperateDB.ExecuteDataSet(strSql).Tables[0].Rows.Count < 1)
                {
                    string sql = "insert into FlowStepPerson values(" + stepid + "," + ListBox2.Items[i].Value + ",0,0)";
                    if (OperateDB.ExecuteNonQuery(sql) > 0)
                    {
                        Response.Write("<script >window.location.href='FlowStep.aspx?id=" + Request.QueryString["flowid"].ToString() + "'</script>");
                    }
                }
            }
        }
    }
}