using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;
/// <summary>
/// Sqlselete 的摘要说明
/// </summary>
public class Sqlselete
{
	public Sqlselete()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public bool Login(string UserName, string Password)
    {
        bool Result = false;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from UserInfo where username=@UserName and Password=@Password";
        //string sql = "select * from UserInfo where username='" + UserName + "' and Password='" + Password + "'";
        SqlCommand com = new SqlCommand(sql, con);
        com.Parameters.Add("@username", UserName);
        com.Parameters.Add("@Password", Password);
        SqlDataReader dr = com.ExecuteReader();
        
        if (dr.Read())
        {
            return Result = true;
        }
        else
        {
            return Result;
        }


    }
    public ArrayList SelectClassInfo(string ClassID)
    {
       
        ArrayList al = new ArrayList();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from ClassInfo where classid='"+ClassID+"'";
        SqlCommand com = new SqlCommand(sql,con);
        SqlDataReader dr = com.ExecuteReader();
       
        while ( dr.Read())
        {
            al.Add(dr["Classid"].ToString());
            al.Add(dr["EntranceTime"].ToString());
            al.Add(dr["ManCount"].ToString());
            al.Add(dr["TeacherName"].ToString());
            al.Add(dr["Grade"].ToString());
            al.Add(dr["State"].ToString());
           
            
        }

        return al;

       
    }
    public ArrayList SelectTeacher()
    {
        ArrayList al = new ArrayList();
       
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select name from TeacherInfo ";
        SqlCommand com = new SqlCommand(sql,con);
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
           al.Add( dr.GetValue(0).ToString());
              
        }


        return al;

       

    }
    public ArrayList SelectClassId()
    {
        ArrayList al = new ArrayList();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select ClassId from ClassInfo ";
        SqlCommand com = new SqlCommand(sql,con);
        SqlDataReader dr = com.ExecuteReader();
        while(dr.Read())
        {
            al.Add(dr.GetValue(0).ToString());
        }
        return al;

      
    }
    public ArrayList SelectStu(int StuId)
    {
        ArrayList al = new ArrayList();

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();

        string sql = "select * from StudentInfo where studentID="+StuId+"";
        SqlCommand com = new SqlCommand(sql,con);
        SqlDataReader dr = com.ExecuteReader();
        while(dr.Read())
        {
            al.Add(dr["Name"].ToString());
            al.Add(dr["Age"].ToString());
            al.Add(dr["Sex"].ToString());
            al.Add(dr["Address"].ToString());
            al.Add(dr["Phone"].ToString());
            al.Add(dr["ClassID"].ToString());


        }
        return al;

 
    }
    public DataTable  Select(string Check,string Info)
    {
    
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from ClassInfo  where "+Check+" like('%"+Info+"%')  ";
        SqlDataAdapter da = new SqlDataAdapter(sql,con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds.Tables[0];

       
    }
    public DataSet SelectTInfo()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from TeacherInfo";
        SqlDataAdapter da = new SqlDataAdapter(sql,con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

       
    }
    public DataTable SelectStudenInfo(string Check, string Input)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from StudentInfo where " + Check + " like('%" + Input + "%') ";
        SqlDataAdapter da = new SqlDataAdapter(sql,con);
        DataSet ds = new DataSet();
        da.Fill(ds);

        return ds.Tables[0];

      
    }
    public SqlDataReader SelectCalendar(int TeacherID,string AddTime)
    {
       
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from Calendar where id=" + TeacherID + " and AddTime='"+AddTime+"'";
        SqlCommand com = new SqlCommand(sql,con);
        SqlDataReader dr=com.ExecuteReader();
        return dr;

    }
    public int SelectTeacherID(string UserName)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select id from UserInfo where UserName='"+UserName+"'";
        SqlCommand com = new SqlCommand(sql,con);
        SqlDataReader dr = com.ExecuteReader();
        dr.Read();
        int i = Convert.ToInt32(dr["id"].ToString());
        return i;
 
    }
    public ArrayList SelectCalendars(int Id)
    {
        ArrayList al = new ArrayList();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from Calendar where CalendarID=" + Id + "";
        SqlCommand com = new SqlCommand(sql,con);
        SqlDataReader dr = com.ExecuteReader();
        if(dr.Read())
        {
            al.Add(dr["Motif"].ToString());
            al.Add(dr["Content"].ToString());
            al.Add(dr["AddTime"].ToString());
            al.Add(dr["CalendarID"].ToString());
            
        }
        return al;
    
    }
    public DataSet MyCalendar(int id)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from Calendar where id=" + id + " order by CalendarID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql,con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    public DataSet MyCalendar(int id,int num)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select top "+num+" * from Calendar where id=" + id + " order by CalendarID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    public DataSet SelectAddressList(int id)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from AddressList where id="+id+"";
        SqlDataAdapter da = new SqlDataAdapter(sql,con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    public DataSet SelectNotepaper(string UserName)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        string sql = "select * from Notepaper where UserName='"+UserName+"'";
        SqlDataAdapter da = new SqlDataAdapter(sql,con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
        
    }
    public DataSet SelectRest()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();

        string sql = "select * from Rest";
        SqlDataAdapter da = new SqlDataAdapter(sql,con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    public DataSet SelectEmp(string strWhere)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();

        string sql = "select * from Employee";
        if (!strWhere.Equals(""))
        {
            sql += " where" + strWhere;
        }
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    public string SelectEmpByName(string name)
    {
        string reStr = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();

        string sql = "select Employeeid from Employee where name='" + name + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            reStr = ds.Tables[0].Rows[0][0].ToString();
        }
        return reStr;
    }
    public string SelectEmpByUserName(string username)
    {
        string reStr = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();

        string sql = "select Employeeid from Employee where username='" + username + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            reStr = ds.Tables[0].Rows[0][0].ToString();
        }
        return reStr;
    }
    public string SelectEmpById(string id)
    {
        string reStr = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();

        string sql = "select name from Employee where Employeeid='" + id + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            reStr = ds.Tables[0].Rows[0][0].ToString();
        }
        return reStr;
    }
    /// <summary>
    /// 返回dataset
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public DataSet Getds(string sql)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds;
    }
    /// <summary>
    /// 返回第一行第一列
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public string getScalar(string sql)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        SqlCommand com = new SqlCommand(sql, con);
        string Scalar = com.ExecuteScalar().ToString();
        con.Close();
        return Scalar;
    }
    /// <summary>
    /// 返回受影响行数
    /// </summary>
    /// <param name="strSql"></param>
    /// <returns></returns>
    public int Query(string strSql)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        SqlCommand com = new SqlCommand(strSql, con);
        int result = com.ExecuteNonQuery();
        con.Close();
        return result;
    }

}
