using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace OA.admin.flow
{
    public partial class Flow_MyPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }

        public void Bind()
        {
            int userid = Convert.ToInt32(new Sqlselete().getScalar("select Employeeid from Employee where username='" + Session["UserName"] + "'"));
            DataSet ds = new Sqlselete().Getds("select * from FlowDoc where ID in (select DocID from FlowPath where UserID=" + userid + ")");

            DataView dv = ds.Tables[0].DefaultView;
            PagedDataSource pds = new PagedDataSource();
            AspNetPager1.RecordCount = dv.Count;
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            this.GridView1.DataSource = pds;
            this.GridView1.DataBind();
        }

        public string getFlow(string id)
        {
            string flow = new Sqlselete().getScalar("select Name from Flow where ID=" + Convert.ToInt32(id)).ToString();
            return flow;
        }

        public string getUser(string id)
        {
            string user = new Sqlselete().getScalar("select Name from Employee where Employeeid=" + Convert.ToInt32(id)).ToString();
            return user;
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}