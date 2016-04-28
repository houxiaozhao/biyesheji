using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace OA.admin.Email
{
    public partial class Email : System.Web.UI.Page
    {
        private string Name;
        protected void Page_Load(object sender, EventArgs e)
        {
            Name = SelectName();

            if (!IsPostBack)
            {
                this.sma.InnerText = "-------收件箱";

                Bind(getsql());
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.sma.InnerText = "-------" + this.DropDownList1.Text;
            string sql = getsql();
            Bind(sql);

        }
        public string getsql()
        {
            string sql = "";
            switch (this.DropDownList1.SelectedIndex)
            {
                case 0:
                    sql = "select * from Email where Email.Meetname='" + Name + "'";
                    break;
                case 1:
                    sql = "select * from Email where Email.sendname='" + Name + "'";
                    break;
                case 2:
                    sql = "select * from Draft where Username='" + Session["UserName"].ToString() + "'";
                    break;
                default:
                    break;
            }
            return sql;
        }
        public string getsql(DateTime start, DateTime end, Boolean tag)
        {

            string sql = "";
            if (tag)
            {
                switch (this.DropDownList1.SelectedIndex)
                {
                    case 0:
                        sql = "select * from Email,Employee where Pubdate between '" + start + "' and '" + end + "' and  Email.Meetname='" + Name + "' and Email.sendname=Employee.username order by sid desc ";
                        break;
                    case 1:
                        sql = "select * from Email,Employee where Pubdate between '" + start + "' and '" + end + "' and  Email.sendname='" + Name + "' and Email.sendname=Employee.username order by sid desc ";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                sql = "select * from Draft where addDate between '" + start + "' and '" + end + "' and username='" + Session["UserName"].ToString() + "'";
            }

            return sql;
        }
        public void Bind(string sql)
        {
            DataSet ds = OperateDB.ExecuteDataSet(sql);           
            if (this.DropDownList1.SelectedIndex == 0 || DropDownList1.SelectedIndex == 1)
            {

                this.DataList2.DataSource = ds;
                this.DataList2.DataBind();
                DataList2.Visible = true;
                DataList1.Visible = false;
            }
            else if (DropDownList1.SelectedIndex == 2)
            {
                this.DataList1.DataSource = ds;
                this.DataList1.DataBind();
                DataList2.Visible = false;
                DataList1.Visible = true;
            }

        }

        private string SelectName()
        {
            string sql = "select Name from Employee where username='" + Session["UserName"].ToString() + "'";
            return OperateDB.getExecuteScalar(sql);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Request.Form["ctl00$ContentPlaceHolder1$calendar1"] == "" || Request.Form["ctl00$ContentPlaceHolder1$calendar2"] == "")
            {
                Bind(getsql());
            }
            else
            {
                DateTime FD = Convert.ToDateTime(Request.Form["ctl00$ContentPlaceHolder1$calendar1"]);
                DateTime TD = Convert.ToDateTime(Request.Form["ctl00$ContentPlaceHolder1$calendar2"]);
                if (this.DropDownList1.SelectedIndex == 0 || DropDownList1.SelectedIndex == 1)
                {

                    this.DataList2.DataSource = OperateDB.ExecuteDataSet(getsql(FD, TD, true));
                    this.DataList2.DataBind();
                    DataList2.Visible = true;
                    DataList1.Visible = false;
                }
                else if (DropDownList1.SelectedIndex == 2)
                {
                    this.DataList1.DataSource = OperateDB.ExecuteDataSet(getsql(FD, TD, false));
                    this.DataList1.DataBind();
                    DataList2.Visible = false;
                    DataList1.Visible = true;
                }
            }
        }
        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            int sid = Convert.ToInt32(e.CommandArgument);
            string sql = "select Appurtenance from Email where sid=" + sid + "";
            string ss = OperateDB.getExecuteScalar(sql);
            string[] a = ss.Split(';');
            string url = "";
            for (int i = 0; i < a.Length; i++)
            {
                string b = a[i];
                url = Server.MapPath("~") + "\\upfiles\\" + b;
            }

            if (File.Exists(url))
            {
                File.Delete(url);
            }
            string sql1 = "delete from Email where sid=" + sid + "";
            OperateDB.ExecuteNonQuery(sql1);
            Bind(getsql());
        }
        public string tb_ServerClick1(string id)
        {
            if (id == null)
            {
                return "asd";
            }
            else
            {
                int sid = Convert.ToInt32(id);
                string status = "已查看";
                string sql = "update Email set Status='" + status + "' where sid=" + id + " ";
                OperateDB.ExecuteNonQuery(sql);
                return "asdasd";
            }


        }

    }
}