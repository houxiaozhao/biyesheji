using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;
using System.Collections;
using AjaxControlToolkit;

namespace OA.admin.Email
{
    public partial class SendEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
                string sql = "delete from Appurtenance where 1=1";
                OperateDB.ExecuteNonQuery(sql);
            }
            Bind();
        
        }

        private void Bind()
        {
            string sql1 = "select * from Appurtenance ";
            this.GridView1.DataSource = OperateDB.ExecuteDataSet(sql1);
            this.GridView1.DataBind();
        }
        public string getzuijin()
        {
            string html = @"<li>
                        <h5>
                            最近联系</h5>
                    </li>";
            string sql = "SELECT  meetname,sid FROM  Email WHERE   Sid in (select max(sid) from Email WHERE   (sendname = '" + getname() + "') group by Meetname having COUNT(*) > 1)";
            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con1.Open();
            SqlCommand com1 = new SqlCommand(sql, con1);
            SqlDataReader dr = com1.ExecuteReader();
            List<string> namelist = new List<string>();
            while (dr.Read())
            {
                namelist.Add(dr["meetname"].ToString());
            }
            foreach (string item in namelist)
            {
                html += string.Format(@"<li><a href='#'><i class='fa fa-comments text-success'></i>{1}</a></li>",item);
            }
            return html;

        }

        private string getname()
        {
            string sql = "select Name from Employee where username='" + Session["UserName"].ToString() + "'";

            string Name = OperateDB.getExecuteScalar(sql);
            return Name;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Title = this.txTitle.Value.Trim();
                string Type = DropDownList1.SelectedItem.Text;
                string Content = Request.Form["textarea"];
                string SendName = Session["UserName"].ToString();
                string MeetName = this.txtOtherMan.Text.Trim();
                DateTime Time = DateTime.Now;
                string Status = "未读";
                ArrayList al = new ArrayList();
                string App = "";
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {

                    al.Add(GridView1.Rows[i].Cells[0].Text.ToString());
                }
                App = string.Join(";", al.ToArray());

                string[] a;
                a = MeetName.Split(';');
                for (int i = 0; i < a.Length - 1; i++)
                {
                    string sql = "insert into Email values('" + Title + "','" + Type + "','" + Content + "','" + SendName + "','" + a[i] + "','" + Time + "','" + Status + "','" + App + "')";
                    OperateDB.ExecuteNonQuery(sql);

                }

               
                string sql1 = "insert into SendMail values('" + Title + "','" + Type + "','" + Content + "','" + SendName + "','" + MeetName + "','" + Time + "','" + App + "')";
                OperateDB.ExecuteNonQuery(sql1);
                Response.Write("<script>alert('发送成功！');window.location.href='Email.aspx';</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('发送失败！')</script>");
                throw;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Appurtenanceid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            string url = Server.MapPath("~") + "\\upfiles\\" + src;
            if (File.Exists(url))
            {
                File.Delete(url);
            }
            string sql = "delete from Appurtenance where Appurtenanceid=" + Appurtenanceid + "";
            OperateDB.ExecuteNonQuery(sql);
            this.Label1.Text = "删除成功";
            Bind();
        }
        public static string src = "";
        protected void bnUpload_ServerClick(object sender, EventArgs e)
        {
            try
            {

                if (FileUpload1.PostedFile.ContentLength == 0)
                {
                    src = "";
                }
                else
                {

                    string strFilePath = FileUpload1.PostedFile.FileName;
                    FileInfo fl = new FileInfo(strFilePath);
                    string Ext = fl.Name;
                    //string i = fl.Name;

                    src = Ext;
                    string ServerPath = Server.MapPath("~");
                    string strSeraPath = ServerPath + "\\upfiles\\" + src;
                    FileUpload1.PostedFile.SaveAs(strSeraPath);
                    this.Panel1.Visible = true;
                    string sql = "insert Appurtenance values('" + Session["UserName"] + "','" + src + "')";
                    OperateDB.ExecuteNonQuery(sql);

                    this.Panel1.Visible = true;
                    Bind();

                }
            }
            catch (Exception ex)
            {
                this.Label1.Text = "只能上传5M以下的文件.";
            }
        }
    }
}