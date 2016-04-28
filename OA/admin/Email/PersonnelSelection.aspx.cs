using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OA.admin.Email
{
    public partial class PersonnelSelection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                DropDownList1.Items.Insert(0, "选择部门....");

                con.Close();



                
                string sql1 = "select * from Employee";

                ListBox1.DataSource = OperateDB.ExecuteDataSet(sql1);
                ListBox1.DataTextField = "Name";
                ListBox1.DataValueField = "username";
                ListBox1.DataBind();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Dutyid = DropDownList1.SelectedItem.Value.ToString();

            string sql = "select Name,username from Employee  where dutyid=" + Dutyid + "";

            ListBox1.DataSource = OperateDB.ExecuteDataSet(sql);
            ListBox1.DataTextField = "Name";
            ListBox1.DataValueField = "username";
            ListBox1.DataBind();
        }
        protected void addbtn_onserverclick(object sender, EventArgs e)
        {
            bool exist = false;
            foreach (ListItem li in this.ListBox2.Items)
            {
                if (li.Value == this.ListBox1.SelectedItem.Value)
                {
                    exist = true;
                }
            }
            if (exist == false)
            {
                this.ListBox2.Items.Add(new ListItem(this.ListBox1.SelectedItem.Text, this.ListBox1.SelectedItem.Value));
            }
        }
        protected void delbtn_onserverclick(object sender, EventArgs e)
        {
            for (int i = 0; i < ListBox2.Items.Count; i++)
            {
                if (this.ListBox2.Items[i].Selected == true)
                {
                    ListBox2.Items.Remove(this.ListBox2.Items[i]);

                }
            }
        }
        public string pass()
        {
            string txt = "";
            for (int j = 0; j < this.ListBox2.Items.Count; j++)
            {
                txt += this.ListBox2.Items[j];
                txt += ";";

            }
            return txt;

        }
    }
}