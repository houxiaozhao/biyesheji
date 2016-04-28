using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class AddressManage_EmploueeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserName"] == null)
        {
            Response.Write("<script>alert('请先登录!');window.location.href='../Login.aspx'</script>");
        }
        else
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                con.Open();
                string sql = "select * from Branch";
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    DropDownList1.Items.Add(new ListItem(dr["Branch"].ToString(), dr["Dutyid"].ToString()));
                }
                DropDownList1.Items.Insert(0, "全部");
                con.Close();
            }
        }
        Bind();
    }
    public void Bind()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from Employee";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Close();
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string sql;
        if (DropDownList1.SelectedItem.Text=="全部"&&TextBox1.Text=="")
        {
            sql = "select * from Employee";  
        }
        else if (DropDownList1.SelectedItem.Text!="全部"&&TextBox1.Text=="")
        {
            sql = "select * from Employee where Branch='" + DropDownList1.SelectedItem.Text + "'";
        }
        else if (DropDownList1.SelectedItem.Text=="全部"&&TextBox1.Text!="")
        {
            sql = "select * from Employee where name like('%" + TextBox1.Text + "%') ";
        }
        else
        {
            sql = "select * from Employee where name like('%" + TextBox1.Text + "%') and Branch='" + DropDownList1.SelectedItem.Text + "'";

        }
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('对不起,没有你查找的员工！')</script>");
        }
        else
        {
            GridView1.DataSource = ds;

            GridView1.DataBind();
            con.Close();
        }
    }
    protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        int Employeeid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "delete from Employee where Employeeid=" + Employeeid + "";
        SqlCommand com = new SqlCommand(sql, con);
        com.ExecuteNonQuery();
        Response.Write("<script>alert('删除成功！')</script>");
        Bind();
        con.Close();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int Employeeid = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value.ToString());
        Response.Redirect("AddEmployee.aspx?Employeeid=" + Employeeid + "");
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string Employeeid = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
        Response.Redirect("AddEmployee.aspx?Employeeid=" + Employeeid + "");
    }
    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[6].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[0].Text + "\"吗?')");
            }
        }
    }
}