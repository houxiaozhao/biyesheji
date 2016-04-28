using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OA.admin.Meeting
{
    public partial class MyMeetingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }

        }
        public void Bind()
        {
            string Name = SelectName();
            string sql = "select  * from Meeting where Personnel='" + Name + "'  order by AddTime desc";
            dtlst.DataSource = OperateDB.ExecuteDataSet(sql);
            dtlst.DataBind();
        }
        public string SelectName()
        {
            string sql = "select Name from Employee where UserName='" + Session["UserName"].ToString() + "'";
            string Name = OperateDB.getExecuteScalar(sql);
            return Name;

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            DateTime FD = Convert.ToDateTime(this.calendar1.Text);
            DateTime TD = Convert.ToDateTime(this.calendar2.Text);
            string Name = SelectName();
            string sql = "select * from Meeting where addtime between '" + FD + "' and '" + TD + "' and Personnel='" + Name + "' order by AddTime desc ";
            dtlst.DataSource = OperateDB.ExecuteDataSet(sql);
            dtlst.DataBind();
        }
    }
}