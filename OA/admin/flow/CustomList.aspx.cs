using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace OA.admin.flow
{
    public partial class Flow_CustomList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                this.panel.Visible = false;
                DataSet ds = new Sqlselete().Getds("select * from FlowType");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    this.drpType.Items.Add(new ListItem(dr["Name"].ToString(), dr["ID"].ToString()));
                    this.drpFlowType.Items.Add(new ListItem(dr["Name"].ToString(), dr["ID"].ToString()));
                }
                this.drpType.Items.Insert(0, "请选择");
                Bind();
            }
        }
        public void Bind()
        {
            DataSet ds = new Sqlselete().Getds("select * from Flow where IsFix=0");
            this.GridView1.DataSource = ds.Tables[0];
            this.GridView1.DataBind();
        }
        protected void btnFind_Click(object sender, EventArgs e)
        {
            if (this.drpType.SelectedItem.Text == "请选择")
            {
                Bind();
            }
            else
            {
                string type = this.drpType.SelectedItem.Value.ToString();
                DataSet ds = new Sqlselete().Getds("select * from Flow where IsFix=0 and TypeID=" + type);
                this.GridView1.DataSource = ds.Tables[0];
                this.GridView1.DataBind();
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            this.panel.Visible = true;
            this.txtContent.Text = "";
            this.txtName.Text = "";
            this.drpFlowType.SelectedIndex = 0;
            this.Button1.Visible = true;
            this.Button3.Visible = false;
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex]["ID"].ToString());
            int result = new Sqlselete().Query("delete from Flow where ID=" + id);
            if (result > 0)
            {
            }
            else
            {
                Response.Write("<script language=javascript>alert('删除失败！')</script>");
            }
            Bind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = this.txtName.Text;
            int userID = Convert.ToInt32(new Sqlselete().getScalar("select Employeeid from Employee where username='yuguomin'"));
            string typeID = this.drpFlowType.SelectedItem.Value;
            string Des = this.txtContent.Text;
            string strsql = "insert into Flow values('" + name + "'," + typeID + ",'" + Des + "',0," + userID + ")";
            int result = new Sqlselete().Query(strsql);
            if (result > 0)
            {
                Bind();
            }
            else
            {
                Response.Write("<script language=javascript>alert('保存失败！')</script>");
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string id = this.GridView1.DataKeys[this.GridView1.SelectedIndex]["ID"].ToString();

            string name = this.txtName.Text;
            //int userId = new DBoperate().ExecuteScalar("select Employeeid from Employee where username=" + Session["UserName"]);
            int userID = Convert.ToInt32(new Sqlselete().getScalar("select Employeeid from Employee where username='yuguomin'"));
            string typeID = this.drpFlowType.SelectedItem.Value;
            string Des = this.txtContent.Text;
            string strsql = "update Flow set Name='" + name + "',TypeID=" + typeID
                    + ",Des='" + Des + "',UserID=" + userID + "where ID=" + id;
            int result = new Sqlselete().Query(strsql);
            if (result > 0)
            {
                Response.Write("<script language=javascript>alert('修改成功！');</script>");
                Bind();
            }
            else
            {
                Response.Write("<script language=javascript>alert('保存失败！')</script>");
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.panel.Visible = true;
            this.Button1.Visible = false;
            this.Button3.Visible = true;
            string id = this.GridView1.DataKeys[this.GridView1.SelectedIndex]["ID"].ToString();
            DataSet dsf = new Sqlselete().Getds("select * from Flow where ID=" + id);
            foreach (DataRow drf in dsf.Tables[0].Rows)
            {
                this.txtName.Text = drf["Name"].ToString();
                this.drpFlowType.SelectedValue = drf["TypeID"].ToString();
                this.txtContent.Text = drf["Des"].ToString();
            }
        }
    }
}