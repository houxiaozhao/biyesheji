using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace OA.admin.personal
{
    public partial class NewPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text.Trim() == TextBox3.Text.Trim() && TextBox2.Text.Trim() != "" && TextBox3.Text.Trim() != "")
            {
                if (this.TextBox1.Text.Trim() == "")
                {
                    this.div1.Attributes.Add("class", "has-error input-group mar");
                    Response.Write("<script>alert('请填写正确资料')</script>");
                }
                else
                {
                    string sql = "update userinfo set Password='" + this.TextBox2.Text + "' where password='" + this.TextBox1.Text + "' and username='" + Session["UserName"].ToString() + "'";
                    if (OperateDB.ExecuteNonQuery(sql) > 0)
                    {
                        Response.Write("<script>alert('修改成功！');window.location.href='../Main.aspx';</script>");

                    }
                    else
                    {
                        this.div1.Attributes.Add("class", "has-error input-group mar");

                        Response.Write("<script>alert('请填写正确资料')</script>");
                    }
                }
            }
            else
            {
                this.div2.Attributes.Add("class", "has-error input-group mar");
                this.div3.Attributes.Add("class", "has-error input-group mar");
                Response.Write("<script>alert('请填写正确资料');</script>");
            }
        }
    }
}