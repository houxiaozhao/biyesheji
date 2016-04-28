using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using OA;

public partial class System_NewsList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string sql = "select * from NewsType ";
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                DropDownList1.Items.Add(new ListItem(dr["Type"].ToString(), dr["NTID"].ToString()));
            }
            DropDownList1.Items.Insert(0, "全部");
            con.Close();
            Bind();
        }
    }

    private void Bind()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select News.NewsID,News.title,NewsType.Type,News.pubdate,News.content from News,NewsType where News.TypeId=NewsType.NTID ";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dt1.DataSource = ds;
        dt1.DataBind();
        con.Close();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sql;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        if (DropDownList1.SelectedItem.Value.ToString() == "全部")
        {
            sql = "select News.NewsID,News.title,NewsType.Type,News.pubdate,News.content from News,NewsType where News.TypeId=NewsType.NTID ";
        }
        else
        {

            sql = string.Format(@"select News.NewsID,News.title,NewsType.Type,News.pubdate,News.content 
from News,NewsType where News.TypeId=NewsType.NTID and TypeId={0}", DropDownList1.SelectedItem.Value);

        }
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt1.DataSource = ds;
            dt1.DataBind();
            con.Close();
        }
        catch
        {
            Response.Write("<script>alert('未知的错误')</script>");
        }
    }
    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        log si = new log();
        int NewsID = Convert.ToInt32(e.CommandArgument);
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "Delete from News where NewsID=" + NewsID + "";
        SqlCommand com = new SqlCommand(sql, con);
        if ( com.ExecuteNonQuery()>0)
        {
            Response.Write("<script>alert('删除成功！')</script>");
            si.InsertWorkLog(Session["UserName"].ToString(), DateTime.Now.ToString(), "删除了标题为：" + e.CommandName + "的新闻");
        }
       
        
        Bind();
        con.Close();
    }
}