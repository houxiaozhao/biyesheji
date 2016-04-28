using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddressManage_BranchMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    public void Bind()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from Branch";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Close();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Bind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int Dutyid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string sql = "delete Branch where dutyid=" + Dutyid + "";
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
            Bind();
            Response.Write("<script>alert('删除成功！')</script>");
            Bind();
            con.Close();
        }
        catch (Exception ex)
        {

            Response.Write("<script>alert('对不起,此部门还有相关人员！')</script>");
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Bind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int Dutyid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        //string b =GridView1.Rows[e.RowIndex].Cells[0].Text;
        //string a = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim();

        string Branch = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString();

        string sql = "update Branch set Branch='" + Branch + "' where dutyid=" + Dutyid + "";
        SqlCommand com = new SqlCommand(sql, con);
        com.ExecuteNonQuery();
        GridView1.EditIndex = -1;
        Response.Write("<script>alert('修改成功！')</script>");
        Bind();
        con.Close();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[3].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('确认要删除?')");
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.TextBox1.Text.Trim() == "")
        {
            Response.Write("<script>alert('请输入部门名称')</script>");
        }
        else
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string Branch = this.TextBox1.Text.Trim();
            string UserName = Session["UserName"].ToString();
            string sql = "insert Branch values('" + Branch + "','" + DateTime.Now.ToString() + "','" + UserName + "')";
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
            Bind();
        }
    }
}