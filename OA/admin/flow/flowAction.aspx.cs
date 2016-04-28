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
    public partial class Flow_flowAction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }
        public void Bind()
        {
            string sql = "select * from FlowAction";
            this.GridView1.DataSource = OperateDB.ExecuteDataSet(sql).Tables[0];
            this.GridView1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int strid = Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex]["ID"].ToString());
            string sql = "delete from FlowAction where ID=" + strid;
            if (OperateDB.ExecuteNonQuery(sql) > 0)
            {
                Response.Write("<script language=javascript>alert('删除成功！')</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('删除失败！')</script>");
            }
            Bind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string sql = "update FlowAction set Name='" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString() + "' where ID=" + this.GridView1.DataKeys[e.RowIndex].Value;

            OperateDB.ExecuteNonQuery(sql);
            GridView1.EditIndex = -1;
            Bind();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Bind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into  FlowAction (Name) values('" + this.TextBox1.Text + "')";
            OperateDB.ExecuteNonQuery(sql);
            Bind();
        }
    }
}