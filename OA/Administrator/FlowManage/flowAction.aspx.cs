using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

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
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from FlowAction";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        //DataSet ds = new DBoperate().ExecuteQuery("select * from FlowType", 0, 0, "table1");
        this.GridView1.DataSource = ds.Tables[0];
        this.GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int strid = Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex]["ID"].ToString());
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "delete from FlowAction where ID=" + strid;
        SqlCommand com = new SqlCommand(sql, con);
        if (com.ExecuteNonQuery() > 0)
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
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "update FlowAction set Name='" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString() + "' where ID=" + this.GridView1.DataKeys[e.RowIndex].Value;
        SqlCommand com = new SqlCommand(sql, con);
        com.ExecuteNonQuery();
        con.Close();
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
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "insert into  FlowAction (Name) values('" + this.TextBox1.Text + "')";
        SqlCommand com = new SqlCommand(sql, con);
        com.ExecuteNonQuery();
        con.Close();
        Bind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Bind();
    }
}