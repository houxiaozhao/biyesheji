using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using OA;

namespace OA.Account
{
    class SqlLogin
    {
        internal bool Login(string UserName, string Password)
        {
            string sql =string .Format( "select * from UserInfo where username='{0}' and Password='{1}'",UserName,Password);
            return OperateDB.ExecuteReader(sql);
        }

        internal void InsertLoginInfo(string UserName, string LoginTime, string IP, string State)
        {
            string sql = string.Format("insert into Logininfo values('{0}','{1}','{2}','{3}')", UserName, LoginTime, IP, State);
            OperateDB.ExecuteNonQuery(sql);
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
}
