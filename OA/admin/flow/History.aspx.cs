using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace OA.admin.flow
{
    public partial class Flow_History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.warn.Visible = false;
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }
        public string id;
        public void Bind()
        {
            id = Request.QueryString["id"];
            DataSet ds = new Sqlselete().Getds("select * from FlowPath where Comment<>'' and DocID=" + id);
            this.GridView1.DataSource = ds.Tables[0];
            this.GridView1.DataBind();
            if (ds.Tables[0].Rows.Count == 0)
            {
                this.warn.Visible = true;
            }
        }

        public string getUser(string id)
        {
            string user = new Sqlselete().getScalar("select Name from Employee where Employeeid=" + Convert.ToInt32(id)).ToString();
            return user;
        }
    }
}