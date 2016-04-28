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
    public partial class ContactsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                con.Open();
                string UserName = Session["UserName"].ToString();
                string sql = "select * from Grouping where username='" + UserName + "' ";


                SqlCommand com = new SqlCommand(sql, con);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    DropDownList1.Items.Add(new ListItem(dr["Type"].ToString(), dr["groupingid"].ToString()));
                }
                DropDownList1.Items.Insert(0, "全部");
                con.Close();


            }
        }
        public void Bind()
        {
            string sql = "select * from AddressList where username='" + Session["UserName"].ToString() + "'";
            dt1.DataSource = OperateDB.ExecuteDataSet(sql);
            dt1.DataBind();
        }
        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            int Sid = Convert.ToInt32(e.CommandArgument);
            string sql = "delete from AddressList where sid=" + Sid + "";
            OperateDB.ExecuteNonQuery(sql);
            Response.Write("<script>alert('删除成功!!')</script>");
            Bind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from AddressList";
            if (DropDownList1.SelectedItem.Text == "全部" && TextBox1.Text == "")
            {
                return;
            }
            else
            {
                if (DropDownList1.SelectedItem.Text != "全部" && TextBox1.Text == "")
                {
                    sql = "select * from AddressList where consort='" + DropDownList1.SelectedItem.Text + "' ";
                }
                if (DropDownList1.SelectedItem.Text == "全部" && TextBox1.Text != "")
                {
                    sql = "select * from AddressList where name like('%" + this.TextBox1.Text + "%')";
                }
                if (DropDownList1.SelectedItem.Text != "全部" && TextBox1.Text != "")
                {
                    sql = "select * from AddressList where consort='" + DropDownList1.SelectedItem.Text + "' and name like('%" + this.TextBox1.Text + "%') ";
                }
                dt1.DataSource = OperateDB.ExecuteDataSet(sql);

                dt1.DataBind();
            }
        }
    }
}