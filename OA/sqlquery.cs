using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace OA
{
    class OperateDB
    {
        // <summary>
        /// 获取连接数据库的字符串
        /// </summary>
        public static string ConnString
        {
            get
            {
                return ConfigurationManager.AppSettings["Connection"].ToString();
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, string cmdText)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = cmdText;
        }

        /// <summary>
        /// 执行数据读取操作
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns>如果获取到值，返回true，否则是false</returns>
        public static bool ExecuteReader(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand cmd = new SqlCommand();
                
                PrepareCommand(cmd, conn, cmdText);
                SqlDataReader dr = cmd.ExecuteReader();
                return dr.Read();
            }
        }
        /// <summary>
        /// 获取dr
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static SqlDataReader GetExecuteReader(string cmdText)
        {

            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand Cmd = new SqlCommand(cmdText, conn);
                SqlDataReader MyReader;
                try
                {
                    conn.Open();
                    MyReader = Cmd.ExecuteReader();
                    return MyReader;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                }
            }
        }  

        /// <summary>
        /// 返回第一行第一列
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static string getExecuteScalar(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, cmdText);
                if (cmd.ExecuteScalar()==null)
                {
                    return "0";
                }
                return cmd.ExecuteScalar().ToString();
            }

        }
        /// <summary>
        /// 执行数据增加、删除或修改等操作
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns>返回操作影响的行数</returns>
        public static int ExecuteNonQuery(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, cmdText);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 执行数据操作，将结果保存在数据集中。
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns>数据集对象</returns>
        public static DataSet ExecuteDataSet(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, cmdText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        public static PagedDataSource paged(string sql, AspNetPager AspNetPager1)
        {
            DataSet ds = OperateDB.ExecuteDataSet(sql);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataColumn dc = dt.Columns.Add("number", System.Type.GetType("System.String"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["number"] = (i + 1).ToString();
            }
            DataView dv = ds.Tables[0].DefaultView;
            PagedDataSource pds = new PagedDataSource();
            AspNetPager1.RecordCount = dv.Count;
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            return pds;
        }
    }
}
