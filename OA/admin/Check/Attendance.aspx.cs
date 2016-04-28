using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OA.admin.Check
{
    public partial class Attendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.span1.Visible = false;
            this.span2.Visible = false;
            this.ok.Attributes.Add("onclick", "javascript:return confirm('确认考勤?')");
            this.ok1.Attributes.Add("onclick", "javascript:return confirm('确认考勤?')");

            if (!IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            string sql = "select * from  [Check] where userName='" + Session["UserName"].ToString() + "'";
            this.dt1.DataSource = OperateDB.ExecuteDataSet(sql);
            dt1.DataBind();
        }


        protected void towork_Click(object sender, EventArgs e)
        {
            string UserName = Session["UserName"].ToString();
            int i = 1;
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string Da = DateTime.Now.ToLongDateString();
            string sql = "select * from [Check] where UserName='" + UserName + "' and shang=" + i + " order by OndutyId desc";
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader dr = com.ExecuteReader();

            if (dr.Read())
            {
                string Check = dr["Checkdate"].ToString();
                if (Check == Da)
                {
                    Response.Write("<script>alert('你已完成上班考勤！')</script>");

                    this.span2.Visible = false;
                }
                else
                {
                    this.span2.Visible = false;
                    this.span1.Visible = true;
                }

            }
            else
            {
                this.span2.Visible = false;
                this.span1.Visible = true;
            }

            con.Close();
        }
        protected void offwork_Click(object sender, EventArgs e)
        {
            int i = 1;
            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con1.Open();
            string Da1 = DateTime.Now.ToLongDateString();
            string sql1 = "select * from [Check] where UserName='" + Session["UserName"].ToString() + "' and shang=" + i + " order by OndutyId desc";
            SqlCommand com1 = new SqlCommand(sql1, con1);
            SqlDataReader dr1 = com1.ExecuteReader();
            if (dr1.Read())
            {
                string Check1 = dr1["Checkdate"].ToString();
                if (Check1 == Da1)
                {

                    int c = 1;
                    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                    con.Open();
                    string Da = DateTime.Now.ToLongDateString();
                    string sql = "select * from [Check] where UserName='" + Session["UserName"].ToString() + "' and xia=" + c + " order by OndutyId desc";
                    SqlCommand com = new SqlCommand(sql, con);
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        string Check = dr["Checkdate"].ToString();
                        if (Check == Da)
                        {
                            Response.Write("<script>alert('你已完成下班考勤！')</script>");
                            this.span1.Visible = false;

                        }
                        else
                        {
                            this.span1.Visible = false;
                            this.span2.Visible = true;
                        }

                    }
                    else
                    {
                        this.span1.Visible = false;
                        this.span2.Visible = true;
                    }

                    con.Close();
                }
                else
                {
                    Response.Write("<script>alert('对不起,你上班还未考勤！')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('对不起,你上班还未考勤！')</script>");
            }

            con1.Close();

        }
        protected void ok_Click(object sender, EventArgs e)
        {
            string sql = "select ShangTime from Checktime ";
            DateTime shang = Convert.ToDateTime(OperateDB.getExecuteScalar(sql));
            DateTime time = Convert.ToDateTime(DateTime.Now.ToString());
            TimeSpan d = shang.TimeOfDay;
            TimeSpan dd = time.TimeOfDay;
            if (d > dd)
            {
                int i = 1;
                int b = 0;
                string Da = DateTime.Now.ToLongDateString();
                string state = "考勤成功";
                string id = Session["UserName"].ToString();
                string Content = this.TextArea1.Value;
                Response.Write("<script>alert('考勤成功！')</script>");
                string sql1 = "insert into  [Check] values('" + time.ToString() + "',null,'" + Da + "','" + id + "','" + state + "',null,'" + Content + "',null," + i + "," + b + ")";
                OperateDB.ExecuteNonQuery(sql1);
                Bind();

            }
            else
            {
                int i = 1;
                int b = 0;
                string Da = DateTime.Now.ToLongDateString();
                string id = Session["UserName"].ToString();
                string state = "迟到";
                string Content = this.TextArea1.Value;
                DateTime Time1 = DateTime.Now;
                string sql2 = "insert into [Check] values('" + Time1.ToString() + "',null,'" + Da + "','" + id + "','" + state + "',null,'" + Content + "',null," + i + "," + b + ")";
                OperateDB.ExecuteNonQuery(sql2);
                Bind();


            }
        }
        protected void cancel_Click(object sender, EventArgs e)
        {
            this.span1.Visible = false;
        }
        protected void ok1_Click(object sender, EventArgs e)
        {
            string sql = "select xiaTime from Checktime ";
            DateTime xia = Convert.ToDateTime(OperateDB.getExecuteScalar(sql).ToString());
            DateTime time = Convert.ToDateTime(DateTime.Now.ToString());
            TimeSpan d = xia.TimeOfDay;
            TimeSpan dd = time.TimeOfDay;
            if (d > dd)
            {
                DateTime dt = DateTime.Now;
                string Da = DateTime.Now.ToLongDateString();
                string y = "早退";
                string Whys = this.TextArea1.Value.Trim();
                int s = 1;
                int x = 1;
                string sql1 = "update [Check] set offdutyTime='" + dt.ToString() + "',offdutystate='" + y + "',offwhys='" + Whys + "',shang=" + s + ",xia=" + x + " where username='" + Session["UserName"].ToString() + "' and CheckDate='" + Da + "'";
                OperateDB.ExecuteNonQuery(sql1);
                Bind();

            }
            else
            {
                DateTime dt = DateTime.Now;
                string Da = DateTime.Now.ToLongDateString();
                string y = "成功考勤";
                string Whys = this.TextArea1.Value.Trim();
                int s = 1;
                int x = 1;
                string sql1 = "update [Check] set offdutyTime='" + dt.ToString() + "',offdutystate='" + y + "',offwhys='" + Whys + "',shang=" + s + ",xia=" + x + " where username='" + Session["UserName"].ToString() + "' and CheckDate='" + Da + "'";
                OperateDB.ExecuteNonQuery(sql1);
                Bind();
            }
        }
        protected void cancel1_Click(object sender, EventArgs e)
        {
            this.span2.Visible = false;
        }
    }
}