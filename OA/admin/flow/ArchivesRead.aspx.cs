using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
namespace OA.admin.flow
{
    public partial class Flow_ArchivesRead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }
        public string arpath = null;
        public string id = null;
        public void Bind()
        {
            id = Request.QueryString["id"].ToString();
            DataSet ds = new Sqlselete().Getds("select * from FlowDoc where ID=" + Convert.ToInt32(Request.QueryString["id"]));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                this.lblTitle.Text = dr["Title"].ToString();
                this.lblFlow.Text = new Sqlselete().getScalar("select Name from Flow where ID=" + Convert.ToInt32(dr["FlowID"])).ToString();
                this.lblUrgent.Text = dr["IsUrgent"].ToString().Equals("0") ? "一般" : "重要";
                this.lblUrgent.ForeColor = dr["IsUrgent"].ToString().Equals("0") ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                this.lblUser.Text = new Sqlselete().getScalar("select Name from Employee where Employeeid=" + dr["UserID"]).ToString();
                this.lblPubDate.Text = dr["PubDate"].ToString();
                this.txtcontent.Text = dr["Content"].ToString();
                arpath = dr["Attachment"].ToString();
                string[] a;
                a = arpath.Split(';');
                string[] AccIDList = { "0" };
                for (int i = 0; i < a.Length; i++)
                {
                    this.lblAr.Text += "<a href=\"Files/"
                            + a[i]
                            + "\" target=\"_blank\">"
                            + a[i]
                            + "</a>" + "&nbsp" + "&nbsp";
                }
            }
            string sql = "select * from FlowAction where ID in (select ActionID from FlowStep where FlowID in (select FlowID from FlowDoc where ID=" + Convert.ToInt32(Request.QueryString["id"]) + "))";
            DataSet dsstep = new Sqlselete().Getds(sql);
            string step = null;
            foreach (DataRow drs in dsstep.Tables[0].Rows)
            {
                step += Convert.ToString(drs["Name"]) + "-->";
            }
            this.lblStep.Text = step + "完成";
        }
        protected void btnRefer_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Server.MapPath(".") + "\\ArchivesFiles\\"))
            {
                Directory.CreateDirectory(Server.MapPath(".") + "\\ArchivesFiles\\");
            }
            //string FileName = this.FileUpload1.PostedFile.FileName;
            string comment = this.txComment.Text.ToString();
            string src = "";
            if (FileUpload1.PostedFile==null)
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
                string ServerPath = Server.MapPath(".");
                string strSeraPath = ServerPath + "\\ArchivesFiles\\" + src;
                FileUpload1.PostedFile.SaveAs(strSeraPath);
            }
               
                int userid = Convert.ToInt32(new Sqlselete().getScalar("select Employeeid from Employee where username='" + Session["UserName"].ToString() + "'"));
                int num = 0;
                DataSet dsp = new Sqlselete().Getds("select * from FlowPath");
                foreach (DataRow dr in dsp.Tables[0].Rows)
                {
                    if (Convert.ToInt32(dr["DocID"]) == Convert.ToInt32(Request.QueryString["id"]) && Convert.ToInt32(dr["UserID"]) == userid && Convert.ToInt32(dr["IsApprove"]) != 2)
                    {
                        num = Convert.ToInt32(dr["Num"]);
                        break;
                    }
                }
                string strSql = "update FlowPath set Comment='" +
                    comment + "',Atteachment='" + src
                    + "',IsApprove=2 where Num=" + num + " and DocID=" + Convert.ToInt32(Request.QueryString["id"]) + " and UserID=" + userid;
                if (new Sqlselete().Query(strSql) > 0)
                {
                    Response.Write("<script>alert('提交成功')</script>");
                }
            
            upEnd();
        }

        public void upEnd()
        {
            DataSet ds = new Sqlselete().Getds("select * from FlowPath where DocID=" + Convert.ToInt32(Request.QueryString["id"]));
            int approve = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (Convert.ToInt32(dr["IsApprove"]) != 2)
                {
                    approve = Convert.ToInt32(dr["IsApprove"]);
                    break;
                }
                else
                {
                    approve = Convert.ToInt32(dr["IsApprove"]);
                }
            }
            if (approve == 2)
            {
                new Sqlselete().Query("update FlowDoc set IsEnd=1 where ID=" + Convert.ToInt32(Request.QueryString["id"]));
            }
        }

    }
}