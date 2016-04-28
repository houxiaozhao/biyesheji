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

public partial class meetingManage_MeetingList : System.Web.UI.Page
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
        string Name = SelectName();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select  * from MyMeeting   order by AddTime desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dtlst.DataSource = ds;
        dtlst.DataBind();
        con.Close();
    }
    public string SelectName()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select Name from Employee where UserName='" + Session["UserName"].ToString() + "'";
        SqlCommand com = new SqlCommand(sql, con);
        SqlDataReader dr = com.ExecuteReader();
        dr.Read();
        string Name = dr.GetValue(0).ToString();
        return Name;

    }

    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        int MeetingID = Convert.ToInt32(e.CommandArgument);
        string[] name;
        string title;

        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        conn.Open();
        string sqlstr = "select * from MyMeeting where MeetingID=" + MeetingID.ToString();
        SqlCommand comm = new SqlCommand(sqlstr, conn);
        SqlDataReader dr = comm.ExecuteReader();
        if (dr.Read())
        {
            name = dr["personnel"].ToString().Trim(';').Split(';');
            title = dr["title"].ToString();
        }
        else
        {
            Response.Write("<script>alert('删除失败！')</script>");
            return;
        }
        conn.Close();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "delete from MyMeeting where MeetingID=" + MeetingID;
        SqlCommand com = new SqlCommand(sql, con);
        com.ExecuteReader();
        con.Close();

        
            
        SqlConnection connn = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        connn.Open();
        foreach (string item in name)
	    {

            string sql1 = "delete from Meeting where personnel='" + item + "' and addtime= '"+e.CommandName+"'";
            SqlCommand commm = new SqlCommand(sql1, connn);
            commm.ExecuteNonQuery();
	    }
        connn.Close();
        Bind();
        log si = new log();
        si.InsertWorkLog(Session["UserName"].ToString(), DateTime.Now.ToString(), "删除了主题为：" + title + "的会议");
        Response.Write("<script>alert('删除成功！')</script>");
       
        
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        DateTime FD = Convert.ToDateTime(this.calendar1.Text);
        DateTime TD = Convert.ToDateTime(this.calendar2.Text);
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string Name = SelectName();
        string sql = "select * from Meeting where addtime between '" + FD + "' and '" + TD + "' and Personnel='" + Name + "' order by AddTime desc ";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dtlst.DataSource = ds;
        dtlst.DataBind();
        con.Close();
    }
}