using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Wuqi.Webdiyer;

namespace OA.admin
{
    public partial class suggest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            string sql = "select * from suggest order by suggestid desc";
            Repeater1.DataSource = OperateDB.paged(sql,AspNetPager1);
            Repeater1.DataBind();
        }
       
        protected void btnpub_Click(object sender, EventArgs e)
        {

            string name;
            DateTime dt = DateTime.Now;
            if (this.textcontent.Value == "")
            {
                Response.Write("<script>alert('请输入内容！')</script>");
            }
            else
            {
                if (this.txtname.Text == "")
                {
                    name = "匿名";
                }
                else
                {
                    name = this.txtname.Text;
                }
                string sql = "insert suggest values('" + dt + "','" + name + "','" + this.textcontent.Value + "')";
                OperateDB.ExecuteNonQuery(sql);
                this.textcontent.Value = "";
                Bind();
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}