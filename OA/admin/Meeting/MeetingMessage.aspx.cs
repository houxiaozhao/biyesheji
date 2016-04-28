using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace OA.admin.Meeting
{
    public partial class MeetingMessage : System.Web.UI.Page
    {
        public string Titles = "";
        public string Types = "";
        public string Expenditure = "";
        public string StartTime = "";
        public string FinishTime = "";
        public string MeetingContent = "";
        public string addTime = "";
        public string UserName = "";
        public string BoardroomName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                int Meetingid = Convert.ToInt32(Request["Meetingid"].ToString());
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                con.Open();
                string sql = "select * from Meeting where Meetingid=" + Meetingid + "";
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    Titles = dr["title"].ToString();
                    Types = dr["Type"].ToString();
                    Expenditure = dr["Expenditure"].ToString();
                    StartTime = dr["StartTime"].ToString();
                    FinishTime = dr["FinishTime"].ToString();
                    MeetingContent = dr["MeetingContent"].ToString();
                    addTime = dr["addTime"].ToString();
                    UserName = SelectName();
                    BoardroomName = dr["BoardroomName"].ToString();
                }
                con.Close();
            }


        }
        public string SelectName()
        {
            int Meetingid = Convert.ToInt32(Request["Meetingid"].ToString());
            string sql = "select Name from Employee where UserName=(select username  from Meeting where Meetingid=" + Meetingid + "  )";
            string Name = OperateDB.getExecuteScalar(sql);
            return Name;

        }
    }
}