using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace OA.admin.flow
{
    public partial class Flow_ArchivesInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }
        public string path = null;
        public string id = null;
        public void Bind()
        {
            id = Request.QueryString["id"].ToString();
            DataSet ds = new Sqlselete().Getds("select * from FlowDoc where ID=" + Convert.ToInt32(Request.QueryString["id"]));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                this.lblTitle.Text = dr["Title"].ToString();
                this.lblStep.Text = new Sqlselete().getScalar("select Name from Flow where ID=" + Convert.ToInt32(dr["FlowID"])).ToString();
                this.lblUrgent.Text = dr["IsUrgent"].ToString().Equals("0") ? "一般" : "重要";
                this.lblUser.Text = new Sqlselete().getScalar("select Name from Employee where Employeeid=" + dr["UserID"]).ToString();
                this.lblPubDate.Text = dr["PubDate"].ToString();
                this.txtcontent.Text = dr["Content"].ToString();
                path = dr["Attachment"].ToString();
                string[] a;
                a = path.Split(';');
                string[] AccIDList = { "0" };
                for (int i = 0; i < a.Length; i++)
                {

                    //LblAcc.Text += "<a href=\"upfiles/" + "+a[i]+"+  target=\"_blank\">" + a[i] + "</a>" + "&nbsp" + "&nbsp";
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
    }
}