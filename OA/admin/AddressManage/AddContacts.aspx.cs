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
    public partial class AddContacts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string username = Session["UserName"].ToString();
                string sql = "select * from grouping where username='" + username + "' ";
                DropDownList3.DataSource = OperateDB.ExecuteDataSet(sql);
                DropDownList3.DataTextField = "Type";
                DropDownList3.DataValueField = "groupingid";
                DropDownList3.DataBind();

                if (Request["Sid"] != null)
                {

                    int sid = Convert.ToInt32(Request["Sid"].ToString());
                    this.Label1.Text = "修改联系人";
                    SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                    con1.Open();
                    string sql1 = "select * from AddressList where sid=" + sid + "";
                    SqlCommand com1 = new SqlCommand(sql1, con1);
                    SqlDataReader dr1 = com1.ExecuteReader();
                    if (dr1.Read())
                    {


                        DropDownList3.Items.FindByValue(dr1["Groupingid"].ToString()).Selected = true;
                        DropDownList1.Items.FindByValue(dr1["sex"].ToString()).Selected = true;
                        DropDownList2.Items.FindByValue(dr1["marry"].ToString()).Selected = true;
                        this.TextBox1.ReadOnly = true;
                        TextBox1.Text = dr1["name"].ToString();
                        TextBox2.Text = dr1["HomePost"].ToString();
                        TextBox4.Text = dr1["Mobile"].ToString();
                        TextBox3.Text = dr1["QQ"].ToString();
                        TextBox5.Text = dr1["Intro"].ToString();
                        con1.Close();
                    }

                }

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request["Sid"] != null)
            {

                int sid = Convert.ToInt32(Request["Sid"].ToString());
                string sql = "update addresslist set Marry='" + DropDownList2.SelectedItem.Text + "',Sex='" + DropDownList1.SelectedItem.Text + "', HomePost='" + TextBox2.Text + "',Mobile='" + TextBox4.Text + "',QQ='" + TextBox3.Text + "',Intro='" + TextBox5 + "'";
                try
                {
                    if (OperateDB.ExecuteNonQuery(sql) > 0)
                    {
                        Response.Write("<script>alert('修改成功!');window.location.href='ContactsList.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('修改失败!');</script>");
                    }

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            else
            {
                if (TextBox1.Text.Trim() == "")
                {
                    Response.Write("<script>alert('请添加联系人姓名！')</script>");
                }
                else
                {

                    string sql = "insert addresslist values('" + TextBox1.Text + "','" + DropDownList1.SelectedItem.Text + "','" + DropDownList2.SelectedItem.Text + "','" + null + "','" + DropDownList3.SelectedItem.Text + "'," +
                        "'" + null + "','" + null + "','" + null + "','" + null + "','" + null + "','" + null + "','" + null + "'," +
                        "'" + null + "','" + null + "','" + null + "','" + null + "','" + null + "','" + null + "','" + TextBox2.Text + "'," +
                        "'" + null + "','" + TextBox4.Text + "','" + TextBox3.Text + "','" + null + "','" + TextBox5.Text + "','" + Session["UserName"].ToString() + "','" + DateTime.Now.ToString() + "'," + Convert.ToInt32(DropDownList3.SelectedItem.Value.ToString()) + ")";

                    OperateDB.ExecuteNonQuery(sql);
                    Response.Write("<script>alert('添加成功！！');window.location.href='ContactsList.aspx';</script>");
                }
            }
        }
    }
}