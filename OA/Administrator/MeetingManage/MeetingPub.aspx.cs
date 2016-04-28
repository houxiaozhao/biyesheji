using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class meetingManage_MeetingPub : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bindboardroom();
            if (Request["Meetingid"] != null)
            {
                int Meetingid = Convert.ToInt32(Request["Meetingid"].ToString());
                SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                con1.Open();
                string sql1 = "select * from MyMeeting where Meetingid=" + Meetingid + "";
                SqlCommand com1 = new SqlCommand(sql1, con1);
                SqlDataReader dr1 = com1.ExecuteReader();
                dr1.Read();
                title.Text = dr1["Title"].ToString();
                txtOtherMan.Text = dr1["Personnel"].ToString();
                this.type.Items.FindByValue(dr1["Type"].ToString()).Selected = true;
                BoardroomName.Items.FindByText(dr1["BoardroomName"].ToString()).Selected = true;
                Expenditure.Text = dr1["Expenditure"].ToString();
                this.calendar1 .Text = dr1["StartTime"].ToString();
                calendar2.Text = dr1["FinishTime"].ToString();
                MeetingContent.Text = dr1["MeetingContent"].ToString();
                con1.Close();
                this.title.ReadOnly = true;

                this.Button1.Visible = true;
                this.Button2.Visible = false;


            }
            else
            {
                this.Button1.Visible = false;
                this.Button2.Visible = true;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string title = this.title.Text.Trim();
        string Personnel = this.txtOtherMan.Text.Trim();
        string Type = this.type.SelectedItem.Text;
        string Expenditure = this.Expenditure.Text;
        string StartTime = this.calendar1.Text.Trim();
        string FinishTime = this.calendar2.Text.Trim();
        string MeetingContent = this.MeetingContent.Text.Trim();
        string UserName = Session["UserName"].ToString();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        int Meetingid = Convert.ToInt32(Request["Meetingid"].ToString());
        string sql = "update MyMeeting set Title='" + title + "',Personnel='" + Personnel + "',Type='" + Type + "'," +
            "Expenditure='" + Expenditure + "',StartTime='" + StartTime + "',FinishTime='" + FinishTime + "'," +
            "MeetingContent='" + MeetingContent + "' where Meetingid=" + Meetingid + " ";
        SqlCommand com = new SqlCommand(sql, con);
        com.ExecuteReader();
        Response.Write("<script>alert('修改成功！');window.location.href='MeetingListD.aspx';</script>");
        con.Close();
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        string title = this.title.Text.Trim();
        string Personnel = this.txtOtherMan.Text.Trim();
        string Type = this.type.SelectedItem.Text;
        string Expenditure = this.Expenditure.Text;
        string StartTime = this.calendar1.Text.Trim();
        string FinishTime = this.calendar2.Text.Trim();
        string MeetingContent = this.MeetingContent.Text.Trim();
        string UserName = Session["UserName"].ToString();
        string Boardroomname = BoardroomName.SelectedItem.Text;
        int BoardroomID = Convert.ToInt32(BoardroomName.SelectedItem.Value);
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        try
        {
            if (title == "" || Personnel == "" || Type == "" || Expenditure == "" || StartTime == "" | FinishTime == "" || MeetingContent == "")
            {
                Response.Write("<script>alert('请输入详细信息！！')</script>");
            }
            else
            {
                con.Open();
                string[] a;
                a = Personnel.Split(';');

                for (int i = 0; i < a.Length - 1; i++)
                {

                    string sql = "insert into Meeting values('" + Boardroomname + "','" + BoardroomID + "','" + DateTime.Now + "','" + title + "','" + a[i] + "','" + Type + "','" + Expenditure + "'," +
                        "'" + StartTime + "','" + FinishTime + "','" + MeetingContent + "','" + UserName + "')";
                    SqlCommand com = new SqlCommand(sql, con);
                    com.ExecuteNonQuery();


                }

                SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                con1.Open();
                string sql1 = "insert into MyMeeting values('" + Boardroomname + "','" + BoardroomID + "','" + DateTime.Now + "','" + title + "','" + Personnel + "','" + Type + "','" + Expenditure + "'," +
                        "'" + StartTime + "','" + FinishTime + "','" + MeetingContent + "','" + UserName + "')";
                SqlCommand com1 = new SqlCommand(sql1, con1);
                com1.ExecuteNonQuery();
                con1.Close();
                con.Close();
                Response.Write("<script>alert('发布成功！');window.location.href='MeetingList.aspx'</script>");
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('请输入详细信息！！')</script>");
        }
    }

    public void Bindboardroom()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from Boardroom";
        SqlCommand com = new SqlCommand(sql, con);
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            BoardroomName.Items.Add(new ListItem(dr["BoardroomName"].ToString(), dr["BoardroomID"].ToString()));
        }
        con.Close();
    }
}