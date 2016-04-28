using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OA.admin.News
{
    public partial class NewsMessage : System.Web.UI.Page
    {
        public string Titles;
        public string TypeId;
        public string Contents;
        public string names;
        public string Pubdate;
        public int NewsID;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                names = useram();
                TypeId = TypeName();

                //SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                //con.Open();
                //string sql = "select * from News where NewsID=" + NewsID + " ";
                //SqlCommand com = new SqlCommand(sql, con);
                //SqlDataReader dr = com.ExecuteReader();
                //if (dr.Read())
                //{
                //    Titles = dr["title"].ToString();
                //    Contents = dr["Content"].ToString();
                //    Pubdate = dr["Pubdate"].ToString();
                //}
                //con.Close();
                Bind();
            }
        }
        public void Bind()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string sql1 = "select * from News where NewsID=" + NewsID + " ";
            SqlCommand com = new SqlCommand(sql1, con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                Titles = dr["title"].ToString();
                Contents = dr["Content"].ToString();
                Pubdate = dr["Pubdate"].ToString();
                this.title.InnerText = Titles;
                this.content.InnerText = Contents;
                this.pudate.InnerText = Pubdate;
                this.name.InnerText = names;

            }
            con.Close();
            con.Open();
            string sql = "select * from NewsRemark,Employee where NewsRemark.UserID=Employee.Employeeid and NewID='" + Convert.ToInt32(Request["NewsId"].ToString()) + "' order by ID desc";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();

            con.Close();
        }
        public string useram()
        {
            NewsID = Convert.ToInt32(Request["NewsID"].ToString());
            string sql = "select Name from Employee where Employeeid=(select UserID from News where NewsID=" + NewsID + ")";
            return OperateDB.getExecuteScalar(sql);

        }
        public string TypeName()
        {
            string Re = "";
            int NewsID = Convert.ToInt32(Request["NewsID"].ToString());
            string sql = "select type from NewsType where NTID=(select TypeId from news where NewsID=" + NewsID + ")";
            return Re = OperateDB.getExecuteScalar(sql);

        }
        protected void bnSave_ServerClick(object sender, EventArgs e)
        {

            //int b = Convert.ToInt32(Request["NewsID"].ToString());
            //string a = Session["UserName"].ToString();
            //SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            //con.Open();
            //string sql = "insert NewsRemark values(" + b + ",'" + a + "','" + this.txContent.Value.Trim() + "','" + DateTime.Now + "')";
            //SqlCommand com = new SqlCommand(sql, con);
            //com.ExecuteNonQuery();
            //Response.Write("<script>alert('发布成功！！');window.location.href='RemarkList.aspx?NewsID=" + b + "';</script>");
            //con.Close();


        }
        public string Name(string y)
        {


            int NewsID = Convert.ToInt32(Request["NewsID"].ToString());
            string sql = "select Name from Employee where username='" + y + "'";
            return OperateDB.getExecuteScalar(sql);

        }
        protected void btnpub_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textcontent.Value))
            {

            }
            else
            {
                int id = Convert.ToInt32(Request["NewsID"].ToString());
                string userid = getuserid();
                string sql = "insert NewsRemark values('" + this.textcontent.Value.Trim() + "'," + userid + ",'" + id + "','" + DateTime.Now + "')";
                OperateDB.ExecuteNonQuery(sql);
                this.textcontent.Value = "";
                Bind();
            }

        }

        private string getuserid()
        {
            string id = "";
            string sql = "select Employeeid from Employee where username='" + Session["UserName"].ToString() + "'";
            return OperateDB.getExecuteScalar(sql);
        }
    }
}