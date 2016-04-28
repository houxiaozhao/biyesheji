using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Flow_StepBind : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);

        if (!IsPostBack)
        {
            con.Open();
            string strSql = "select * from Branch";
            SqlDataAdapter da = new SqlDataAdapter(strSql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DropDownList1.Items.Add(new ListItem(dr["Branch"].ToString(), dr["Dutyid"].ToString()));
            }
            this.DropDownList1.Items.Insert(0, "选择部门....");
            con.Close();
            Bind();

        }
    }
    public void Bind()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);

        Sqlselete ss = new Sqlselete();
        DataSet dsa = ss.SelectEmp("");
        ListBox1.DataSource = dsa.Tables[0];
        ListBox1.DataTextField = "Name";
        ListBox1.DataValueField = "Employeeid";
        ListBox1.DataBind();

        con.Open();
        string strSql1 = "select * from Employee where Employeeid in (select UserID from FlowStepPerson where StepID=" + Request.QueryString["stepid"] + ")";
        SqlDataAdapter daa = new SqlDataAdapter(strSql1, con);
        DataSet dss = new DataSet();
        daa.Fill(dss);


        this.ListBox2.DataSource = dss.Tables[0];
        this.ListBox2.DataTextField = "Name";
        this.ListBox2.DataValueField = "Employeeid";
        this.ListBox2.DataBind();
        con.Close();
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
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            ListBox1.DataSource = ds.Tables[0];
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
            //int result =(int) new DBoperate().ExecuteScalar(strSql);
            //DataSet ds = new DBoperate().ExecuteQuery("select * from FlowStepPerson where StepID=" + stepid);
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(strSql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count < 1)
            {
                SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                con1.Open();
                string sql="insert into FlowStepPerson values(" + stepid + "," + ListBox2.Items[i].Value+",0,0)";
                SqlCommand com = new SqlCommand(sql, con1);
                if (com.ExecuteNonQuery()>0)
                {
                    Response.Write("<script >window.location.href='FlowStep.aspx?id=" + Request.QueryString["flowid"].ToString() + "'</script>");
                }
                con1.Close();
            }
        }
    }
}