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

public partial class AddressManage_AddEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string sql = "select * from branch";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Branch.DataSource = ds;
            Branch.DataTextField = "Branch";
            Branch.DataValueField = "Dutyid";
            Branch.DataBind();
            con.Close();
            if (Request["Employeeid"] != null)
            {
                this.user.Visible = false;
                this.save.Visible = false;
                this.edit.Visible = true;
                this.upspan.Visible = false;
                this.Label1.Text = "修改员工信息";
                int Employeeid = Convert.ToInt32(Request["Employeeid"].ToString());
                SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                con1.Open();
                string sql1 = "select * from Employee where Employeeid=" + Employeeid + "";
                SqlCommand com1 = new SqlCommand(sql1, con1);
                SqlDataReader dr1 = com1.ExecuteReader();
                if (dr1.Read())
                {

                    name.Text = dr1["name"].ToString();
                    sex.Items.FindByValue(dr1["sex"].ToString()).Selected = true;
                    marry.Items.FindByValue(dr1["Marry"].ToString()).Selected = true;
                    Branch.Items.FindByValue(dr1["Dutyid"].ToString()).Selected = true;
                    //Birthday.Text = dr1["Birthday"].ToString();
                    //Stature.Text = dr1["Stature"].ToString();
                    //Avoirdupois.Text = dr1["Avoirdupois"].ToString();
                    cardtype.Text = dr1["cardtype"].ToString();
                    cardid.Text = dr1["cardid"].ToString();
                    //Speciality.Text = dr1["Speciality"].ToString();
                    //workPhone.Text = dr1["workPhone"].ToString();
                    phone.Text = dr1["movePhone"].ToString();
                    //HomePhone.Text = dr1["HomePhone"].ToString();
                    //xiaolingtong.Text = dr1["xiaolingtong"].ToString();
                    //address.Text = dr1["Homeaddress"].ToString();
                    //Post.Text = dr1["Post"].ToString();
                   // url.Text = dr1["url"].ToString();
                    //Email.Text = dr1["Email"].ToString();
                    QQ.Text = dr1["qq"].ToString();
                    //msn.Text = dr1["msn"].ToString();

                }
                con1.Close();
            }
            else
            {
                this.user.Visible = true;
                this.save.Visible = true;
                this.edit.Visible = false;
                this.Label1.Text = "增加员工";
                this.upspan.Visible = true;
            }

        }
    }
    protected void up_Click(object sender, EventArgs e)
    {
        string src;
        if (FileUpload1.PostedFile.ContentLength == 0)
        {
            src = "";
        }
        else
        {
            string zname = this.name.Text.Trim();
            string strFilePath = FileUpload1.PostedFile.FileName;
            FileInfo fl = new FileInfo(strFilePath);
            string Ext = fl.Extension;
            if (Ext.Equals(".jpg") || Ext.Equals(".gif") || Ext.Equals(".png") || Ext.Equals(".ico"))
            {

                src = zname + Ext;

                string ServerPath = Server.MapPath("~");
                string strSeraPath = ServerPath + "\\picture\\" + src;
                FileUpload1.PostedFile.SaveAs(strSeraPath);
                this.Label1.Text = "图片上传成功";
                src = zname + Ext;
            }
            else
            {
                this.Label1.Text = "图片上传格式不正确";
            }
        }
    }
    protected void save_Click(object sender, EventArgs e)
    {
        //try
        //{
            string zname = this.name.Text.Trim();

            if (username.Text.Trim() == "" || name.Text.Trim() == "")
            {
                Response.Write("<script>alert('姓名和用户名必须填写')</script>");
            }
            else
            {


                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                con.Open();
                int dutyid = Convert.ToInt32(Branch.SelectedItem.Value.ToString());
                string branch = Branch.SelectedItem.Text;
                string sexs = sex.SelectedItem.Text;
                string Marrys = marry.SelectedItem.Text;
                //string Birthdays = Birthday.Text.Trim();
                //string Statures = Stature.Text.Trim();
               // string Avoirdupoiss = Avoirdupois.Text.Trim();
                string cardtypes = cardtype.SelectedItem.Text;
                string cardids = cardid.Text.Trim();
                //string Specialitys = Speciality.Text.Trim();
                string addTime = DateTime.Now.ToShortDateString();
                //string workPhones = workPhone.Text.Trim();
                string movePhones = phone.Text.Trim();
                //string HomePhones = HomePhone.Text.Trim();
                //string xiaolingtongs = xiaolingtong.Text.Trim();
                string addresss = address.Text.Trim();
                //string Posts = Post.Text.Trim();
                //string urls = url.Text.Trim();
                //string Emails = Email.Text.Trim();
                string qq = QQ.Text.Trim();
                //string msns = msn.Text.Trim();
                string sql = "insert into Employee values('" + username.Text.Trim() + "','" + dutyid + "','" + branch + "','" + null + "','" + zname + "','" + sexs + "','" + Marrys + "','" + null + "'," +
                    "'" + null + "','" + null + "','" + cardtypes + "','" + cardids + "','" + null + "','" + addTime + "','" + null + "'," +
                    "'" + movePhones + "','" + null + "','" + null + "','" + addresss + "','" + null + "','" + null + "','" + null + "','" + qq + "','" + null + "')";
                SqlCommand com = new SqlCommand(sql, con);
                com.ExecuteNonQuery();
                SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                con2.Open();
                string password = "123456";
                if (string.IsNullOrEmpty(pwd.Text))
                {
                    password = pwd.Text;
                }
                
                string sql2 = "insert into userinfo values('" + this.username.Text.Trim() + "','" + password + "'," + dutyid + ")";
                SqlCommand com2 = new SqlCommand(sql2, con2);
                com2.ExecuteNonQuery();
                con2.Close();
                Response.Write("<script>alert('添加成功！');</script>");
                con.Close();
            }
        //}
        //catch (Exception ex)
        //{
        //    Response.Write("<script>alert('数据库错误！！')</script>");
        //}
    }
    protected void edit_Click(object sender, EventArgs e)
    {
        string names = this.name.Text;
        int dutyid = Convert.ToInt32(Branch.SelectedItem.Value.ToString());
        string branch = Branch.SelectedItem.Text;
        string sexs = sex.SelectedItem.Text;
        string Marrys = marry.SelectedItem.Text;
        //string Birthdays = Birthday.Text.Trim();
        //string Statures = Stature.Text.Trim();
        //string Avoirdupoiss = Avoirdupois.Text.Trim();
        string cardtypes = cardtype.SelectedItem.Text;
        string cardids = cardid.Text.Trim();
        //string Specialitys = Speciality.Text.Trim();
        string addTime = DateTime.Now.ToShortDateString();
        //string workPhones = workPhone.Text.Trim();
        string movePhones = phone.Text.Trim();
        //string HomePhones = HomePhone.Text.Trim();
        //string xiaolingtongs = xiaolingtong.Text.Trim();
        string Homeaddresss = address.Text.Trim();
        //string Posts = Post.Text.Trim();
        //string urls = url.Text.Trim();
        //string Emails = Email.Text.Trim();
        string qqs = QQ.Text.Trim();
        //string msns = msn.Text.Trim();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        con.Open();
        int Employeeid = Convert.ToInt32(Request["Employeeid"].ToString());
        string sql = "update Employee set  Name='" + names + "',sex='" + sexs + "',Marry='" + Marrys + "',Birthday='" + null + "'," +
            "Stature='" + null + "',branch='" + branch + "',Avoirdupois='" + null + "',cardtype='" + cardtypes + "',cardid='" + cardids + "'," +
            "Speciality='" + null + "',workPhone='" + null + "',movePhone='" + movePhones + "',HomePhone='" + null + "'," +
            "xiaolingtong='" + null + "',Homeaddress='" + Homeaddresss + "',Post='" + null + "',url='" + null + "'," +
            "Email='" + null + "',qq='" + qqs + "',msn='" + null + "' where Employeeid=" + Employeeid + " ";
        SqlCommand com = new SqlCommand(sql, con);
        com.ExecuteNonQuery();
        Response.Write("<script>alert('修改成功!');</script>");
        con.Close();
    }
}