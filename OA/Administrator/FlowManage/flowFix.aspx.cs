using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Flow_flowFix : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.SelectedIndexChanged += new EventHandler(GridView1_SelectedIndexChanged);
        if (!Page.IsPostBack)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string sql = "select * from FlowType";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            //DataSet ds = new DBoperate().ExecuteQuery("select * from FlowType", 0, 0, "table1");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                this.drpType.Items.Add(new ListItem(dr["Name"].ToString(), dr["ID"].ToString()));
                this.flowtype.Items.Add(new ListItem(dr["Name"].ToString(), dr["ID"].ToString()));
            }
            this.drpType.Items.Insert(0, "请选择");
            Bind();
            this.panel2.Visible = false;
        }
    }

    public void Bind()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from Flow where IsFix=1";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);

        //DataSet ds = new DBoperate().ExecuteQuery("select * from Flow where IsFix=1", 0, 0, "tabflow");
        this.GridView1.DataSource = ds.Tables[0];
        this.GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int strid = Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex]["ID"].ToString());
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "delete from Flow where ID=" + strid;
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
    protected void btnFind_Click(object sender, EventArgs e)
    {
        if (this.drpType.SelectedItem.Text == "请选择")
        {
            Bind();
        }
        else
        {
            string type = this.drpType.SelectedItem.Value.ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string sql = "select * from Flow where IsFix=1 and TypeID=" + type;
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            this.GridView1.DataSource = ds.Tables[0];
            this.GridView1.DataBind();
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
         string id = this.GridView1.DataKeys[this.GridView1.SelectedIndex]["ID"].ToString();
         SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
         con.Open();
         string sql = "select * from Flow where ID=" + id;
         SqlDataAdapter da = new SqlDataAdapter(sql, con);
         DataSet ds = new DataSet();
         da.Fill(ds);
         this.panel2.Visible = true;
         this.Button2.Visible = false;
         this.Button1.Visible = true;
         //DataSet ds = new DBoperate().ExecuteQuery("select * from FlowType", 0, 0, "table1");
         foreach (DataRow dr in ds.Tables[0].Rows)
         {
             this.flowname.Text = dr["Name"].ToString();
             this.flowtype.SelectedValue = dr["TypeID"].ToString();
             //this.flowtype.SelectedItem.Value = dr["TypeID"].ToString();
             this.flowcontent.Text = dr["Des"].ToString();
         }
         con.Close();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        this.panel2.Visible = true;
        this.flowname.Text = "";
        this.flowtype.SelectedIndex = 0;
        this.flowcontent.Text = "";
        this.Button1.Visible = false;
        this.Button2.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string id = this.GridView1.DataKeys[this.GridView1.SelectedIndex]["ID"].ToString();

            Sqlselete ss = new Sqlselete();
            int userid = Convert.ToInt32(ss.SelectEmpByUserName(Session["UserName"].ToString()));
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string sql = "update Flow set Name='" + this.flowname.Text + "',TypeID=" + this.flowtype.SelectedItem.Value + ",Des='" + this.flowcontent.Text + "',UserID=" + userid + "where ID="+id;
            SqlCommand com = new SqlCommand(sql, con);
            if (com.ExecuteNonQuery()>0)
            {

            }
            else
            {
                Response.Write("<script>alert('保存失败！');</script>");
            }
            con.Close();
            Bind();
        }
        catch (Exception)
        {

            Response.Write("<script>alert('登录超时，请重新登录！');window.location.href='../Login.aspx'</script>");
        }
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Sqlselete ss = new Sqlselete();

        try
        {
            int userid = Convert.ToInt32(ss.SelectEmpByUserName(Session["UserName"].ToString()));
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string sql = "insert into Flow values('" + this.flowname.Text + "'," + this.flowtype.SelectedItem.Value + ",'" + this.flowcontent.Text + "',1," + userid + ")";
            SqlCommand com = new SqlCommand(sql, con);
            if (com.ExecuteNonQuery() > 0)
            {

            }
            else
            {
                Response.Write("<script>alert('保存失败！');</script>");

            }
            con.Close();
            Bind();
        }
        catch (Exception)
        {
            Response.Write("<script>alert('登录超时，请重新登录！');window.location.href='../Login.aspx'</script>");
        } 
    }

}