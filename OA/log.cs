using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace OA
{
    public class log
    {
        public void InsertLoginInfo(string UserName, string LoginTime, string IP, string State)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string sql = "insert into Logininfo values(@UserName,@LoginTime,@IP,@State)";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.Add("@username", UserName);
            com.Parameters.Add("@LoginTime", LoginTime);
            com.Parameters.Add("@IP", IP);
            com.Parameters.Add("@State", State);
            com.ExecuteNonQuery();
            com.Dispose();
            con.Close();
        }
        public void InsertWorkLog(string UserName, string WorkTime, string WorkInfo)
        {
            string sql = "insert into WorkLog values('" + UserName + "','" + WorkTime + "','" + WorkInfo + "')";
            OperateDB.ExecuteNonQuery(sql);
        }

        public void InsertCalendar(int TeacherID, string Motif, string Contert, string AddTime)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string sql = "insert into Calendar values(" + TeacherID + ",'" + Motif + "','" + Contert + "','" + AddTime + "')";
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteReader();
            com.Clone();
            con.Close();
        }
        public void InsertNotepaper(string Message, string AddTime, string UserName)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string sql = "insert into Notepaper values('" + Message + "','" + AddTime + "','" + UserName + "')";
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}