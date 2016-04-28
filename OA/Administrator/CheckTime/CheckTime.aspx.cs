using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OA.Administrator.CheckTime
{
    public partial class CheckTime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            DateTime shang = Convert.ToDateTime(this.shang.Value);
            DateTime xia = Convert.ToDateTime(this.xia.Value);
            string sql = "update CheckTime set shangtime='" + shang + "',xiatime='" + xia + "'";
            if (OperateDB.ExecuteNonQuery(sql)>0)
            {
                Response.Write("<script>alert('修改成功')</script>");
                this.shang.Value = "";
                this.xia.Value = "";
            }
            else
            {
                Response.Write("<script>alert('修改失败')</script>");
            }
        }
    }
}