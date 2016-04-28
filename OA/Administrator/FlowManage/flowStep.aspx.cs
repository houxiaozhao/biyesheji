using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

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
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from FlowStep where FlowID=" + Request.QueryString["id"].ToString() + " order by Num";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;

        GridView1.DataBind();
        con.Close();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strid = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "delete from FlowStepPerson where StepID=" + strid;
        SqlCommand com = new SqlCommand(sql, con);
        com.ExecuteNonQuery();
        con.Close();
        con.Open();
        string sql1 = "delete from FlowStep where ID=" + strid;
        SqlCommand com1 = new SqlCommand(sql1, con);
        if (com1.ExecuteNonQuery()!=1)
        {
            Response.Write("<script language=javascrip>alert('删除成功！')</script>");
        }
        Bind();
        con.Close();
    }

    public string getAction(string id)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select Name from FlowAction where ID=" + id;
        SqlCommand com = new SqlCommand(sql, con);
        string action= com.ExecuteScalar().ToString();
        con.Close();
        return action;
    }

    public string getPerson(string id)
    {
        string person = null;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        string strSql = "select Name from Employee where Employeeid in (select UserID from FlowStepPerson where StepID=" + Convert.ToInt32(id) + ")";
        SqlDataAdapter da = new SqlDataAdapter(strSql, con);
        DataSet ds=new DataSet ();
        da.Fill(ds);
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
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        string strSql = "select * from FlowAction";
        SqlDataAdapter da = new SqlDataAdapter(strSql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            this.drpAction.Items.Add(new ListItem(dr["Name"].ToString(), dr["ID"].ToString()));
        }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string action = this.drpAction.SelectedItem.Value.ToString(); ;
        int num = Convert.ToInt32(this.txtNum.Text);
        string join = this.drpJoin.SelectedItem.Value.ToString();
        string end = this.drpEnd.SelectedItem.Value.ToString();
        string des = this.txtDes.Text;
        int flowid = Convert.ToInt32(Request.QueryString["id"]);
        string strSql = "insert into FlowStep values(" + action + "," + join + ",'" + des + "'," +
            num + "," + flowid + "," + end + ")";
        SqlCommand com = new SqlCommand(strSql, con);
        if (com.ExecuteNonQuery()!=1)
        {
            Response.Write("<script language=javascript>alert('保存失败！')</script>");
        }
        con.Close();
        Bind();
        
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //this.GridView1.DataKeys[this.GridView1.SelectedIndex]["flowid"].ToString()
        this.panel.Visible = true; 
       
        Button3.Visible = true;
        Button1.Visible = false;
        BindAction();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql="select * from FlowStep where ID=" + this.GridView1.DataKeys[this.GridView1.SelectedIndex][0].ToString();
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds); 
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            this.txtNum.Text = dr["Num"].ToString();
            this.txtDes.Text = dr["Des"].ToString();
            this.drpAction.SelectedValue = dr["ActionID"].ToString();
            this.drpEnd.SelectedValue = dr["isEnd"].ToString();
            this.drpJoin.SelectedValue = dr["isJoin"].ToString();
        }
        con.Close();

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
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string strSql = "update FlowStep set ActionID=" + action + ",IsJoin=" + join + ",Des='" + des + "',Num=" + num + ",IsEnd=" + end + " where ID=" + flowid;
            SqlCommand com = new SqlCommand(strSql, con);
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