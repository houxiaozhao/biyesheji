using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OA.admin.AddressManage
{
    public partial class MyGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }
        public void Bind()
        {

            string sql = "select * from grouping where username='" + Session["UserName"].ToString() + "'";
            dt1.DataSource = OperateDB.ExecuteDataSet(sql);
            dt1.DataBind();

        }
        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.CommandArgument);
                string sql = "delete from grouping where  groupingid=" + id + "";
                OperateDB.ExecuteNonQuery(sql);
                Response.Write("<script>alert('删除成功!')</script>");
                Bind();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('对不起,先要删除此组联系人!!')</script>");
            }
        }
    }
}