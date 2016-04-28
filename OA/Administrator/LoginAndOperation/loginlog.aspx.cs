using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using OA;

public partial class System_loginlog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Session["UserName"] == null)
            //{
            //    Response.Write("<script language=javascript>alert('请先登录!');window.location.href='../Login.aspx'</script>");
            //}
            //else
            //{
            Bind();
            //}
        }
    }

    public void Bind()
    {
        DataSet ds = new DataSet();
        string strsql = "select * from LoginInfo ORDER BY loginid DESC";
        ds = OperateDB.ExecuteDataSet(strsql);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        DataColumn dc = dt.Columns.Add("number", System.Type.GetType("System.String"));
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["number"] = (i + 1).ToString();
        }

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
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }
    
}