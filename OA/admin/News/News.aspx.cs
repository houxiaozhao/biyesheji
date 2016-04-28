using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace OA.admin.News
{
    public partial class News : System.Web.UI.Page
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
            string sql = "select News.NewsID,News.title,NewsType.Type,News.pubdate,News.content from News,NewsType where News.TypeId=NewsType.NTID ";
            dt1.DataSource = OperateDB.ExecuteDataSet(sql);
            dt1.DataBind();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
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
                dt1.DataSource = OperateDB.ExecuteDataSet(sql) ;
                dt1.DataBind();
            }
            catch
            {
                Response.Write("<script>alert('未知的错误')</script>");
            }
        }
    }
}