using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace OA.admin.AddressManage
{
    public partial class EmploueeAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert('请先登录!');window.location.href='../Login.aspx'</script>");
            }
            else
            {
                if (!IsPostBack)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                    con.Open();
                    string sql = "select * from Branch";
                    SqlCommand com = new SqlCommand(sql, con);
                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        DropDownList1.Items.Add(new ListItem(dr["Branch"].ToString(), dr["Dutyid"].ToString()));
                    }
                    DropDownList1.Items.Insert(0, "全部");
                    con.Close();
                }
            }
            Bind();
        }
        public void Bind()
        {
            string sql = "select * from Employee";
            dt1.DataSource = OperateDB.ExecuteDataSet(sql);
            dt1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from Employee";
            if (DropDownList1.SelectedItem.Text == "全部" && TextBox1.Text == "")
            {
                return;
            }
            else
            {
                if (DropDownList1.SelectedItem.Text != "全部" && TextBox1.Text == "")
                {
                    sql = "select * from Employee where branch='" + DropDownList1.SelectedItem.Text + "' ";
                }
                if (DropDownList1.SelectedItem.Text == "全部" && TextBox1.Text != "")
                {
                    sql = "select * from Employee where name like('%" + this.TextBox1.Text + "%')";
                }
                if (DropDownList1.SelectedItem.Text != "全部" && TextBox1.Text != "")
                {
                    sql = "select * from Employee where branch='" + DropDownList1.SelectedItem.Text + "' and name like('%" + this.TextBox1.Text + "%') ";
                }
                dt1.DataSource = OperateDB.ExecuteDataSet(sql);

                dt1.DataBind();
            }

        }
    }
}