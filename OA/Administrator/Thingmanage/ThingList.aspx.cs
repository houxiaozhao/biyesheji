using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Thing_ThingList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string sql = "select * from OcThingsType ";
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                DropDownList1.Items.Add(new ListItem(dr["Name"].ToString(), dr["Sid"].ToString()));
                DropDownList2.Items.Add(new ListItem(dr["Name"].ToString(), dr["Sid"].ToString()));
            }
            con.Close();
        }

    }
    public void Bind()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from Octhing order by sid desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Close();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int sid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "delete from OcThing where sid=" + sid + "";
        SqlCommand com = new SqlCommand(sql, con);
        com.ExecuteNonQuery();
        Bind();
        Response.Write("<script>alert('删除成功！！')</script>");
        con.Close();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[2].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[0].Text + "\"吗?')");
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string name = this.DropDownList1.SelectedItem.Text;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from Octhing where sortname='" + name + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (this.TextBox1.Text.Trim() != null)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            int Typesid = Convert.ToInt32(DropDownList1.SelectedItem.Value.ToString());
            string sql = "insert OcThings values('" + TextBox1.Text.Trim() + "'," + Typesid + ")";
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
            con.Close();
            Insert();
            Response.Write("<script>alert('操作成功');</script>");
            Bind();
        }
    }
    public void Insert()
    {
        string Worktype = "采购";
        int Count = Convert.ToInt32(this.TextBox2.Text.Trim());
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string Name = TextBox1.Text.Trim();
        int sids = SelectSid(Name);
        int sid = Convert.ToInt32(DropDownList1.SelectedItem.Value);
        string Content = this.TextBox3.Text.Trim();
        string sql = "insert into OcThing values('" + Worktype + "'," + Count + ",'" + sid + "','" + DropDownList1.SelectedItem.Text + "','" + sid + "','" + Name + "','" + Content + "','" + Session["UserName"].ToString() + "')";
        SqlCommand com = new SqlCommand(sql, con);
        com.ExecuteNonQuery();
        con.Close();
    }
    public int SelectSid(string Name)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select sid from  OcThings where name='" + Name + "'";
        SqlCommand com = new SqlCommand(sql, con);
        SqlDataReader dr = com.ExecuteReader();
        dr.Read();
        int i = 0;
        i = Convert.ToInt32(dr["sid"].ToString());
        return i;

    }
}