using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace OA.admin.flow
{
    public partial class Flow_AddApply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            this.warning.Visible = false;
            drpFltype.SelectedIndexChanged += new EventHandler(drpFltype_SelectedIndexChanged);
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con.Open();
            string sql = "select * from FlowType ";
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                this.drpFltype.Items.Add(new ListItem(dr["Name"].ToString(), dr["ID"].ToString()));
            }
            this.drpFltype.Items.Insert(0, "请选择流程类别");
            con.Close();
            if (Request.QueryString["id"] != null)
            {
                this.warning.Visible = true;
                con.Open();
                string sqlstr = "select * from FlowDoc where ID=" + Convert.ToInt32(Request.QueryString["id"]);
                SqlCommand com1 = new SqlCommand(sqlstr, con);
                SqlDataReader dr1 = com1.ExecuteReader();
                string flowid = "";
                while (dr1.Read())
                {
                    this.txtTitle.Text = dr1["Title"].ToString();
                    this.TextBox2.Text = dr1["Content"].ToString();
                    flowid = dr1["FlowID"].ToString();
                    
                }

                con.Close();
                
            }
        }
        protected void drpFltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpFltype.SelectedIndex != 0)
            {
                string type = this.drpFltype.SelectedItem.Value;
                string sql = "select * from Flow where TypeID=" + Convert.ToInt32(type);
                this.drpFlow.DataSource = OperateDB.ExecuteDataSet(sql).Tables[0];
                this.drpFlow.DataTextField = "Name";
                this.drpFlow.DataValueField = "ID";
                this.drpFlow.DataBind();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (drpFltype.SelectedIndex != 0 && !string.IsNullOrEmpty(drpFlow.SelectedItem.Text))
            {
                string title = this.txtTitle.Text;
                int urgent = Convert.ToInt32(this.drpUrgent.SelectedIndex);
                int flowid = Convert.ToInt32(this.drpFlow.SelectedItem.Value);
                Sqlselete ss = new Sqlselete();
                int userid = Convert.ToInt32(ss.SelectEmpByUserName(Session["UserName"].ToString()));
                //string FileName = this.FileUpload1.PostedFile.FileName;
                string content = this.TextBox2.Text;
                string src = "";
                if (Request.QueryString["id"] != null)
                {
                    string sql = "update FlowDoc set Title='" + title + "',Content='" + content + "'";
                    if (OperateDB.ExecuteNonQuery(sql)>0)
                    {
                        Response.Write("<script language=javascript>alert('保存成功！');</script>");
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('保存失败!');</script>");
                    }
                }
                else
                {
                    if (!Directory.Exists(Server.MapPath(".") + "\\Files\\"))
                    {
                        Directory.CreateDirectory(Server.MapPath(".") + "\\Files\\");
                    }

                    if (FileUpload1.PostedFile.ContentLength == 0)
                    {
                        src = "";
                    }
                    else
                    {

                        string strFilePath = FileUpload1.PostedFile.FileName;
                        FileInfo fl = new FileInfo(strFilePath);
                        string Ext = fl.Name;

                        src = Ext;
                        string ServerPath = Server.MapPath(".");
                        string strSeraPath = ServerPath + "\\Files\\" + src;
                        FileUpload1.PostedFile.SaveAs(strSeraPath);

                    }


                    string strSql = "insert into FlowDoc values('" + title + "'," + urgent + "," + flowid + ",1," + userid + ",'" + content + "',default,1,0,'" + src + "')";
                    if (OperateDB.ExecuteNonQuery(strSql)>0)
                    {
                        Response.Write("<script>alert('保存成功！');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('保存失败!');</script>");
                    }
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (drpFltype.SelectedIndex != 0 && !string.IsNullOrEmpty(drpFlow.SelectedItem.Text))
            {
                //插入申请
                string sql;
                string title = this.txtTitle.Text;
                int urgent = Convert.ToInt32(this.drpUrgent.SelectedIndex);
                int flowid = Convert.ToInt32(this.drpFlow.SelectedItem.Value);
                Sqlselete ss = new Sqlselete();
                int userid = Convert.ToInt32(ss.SelectEmpByUserName(Session["UserName"].ToString()));
                //string FileName = this.FileUpload1.PostedFile.FileName;
                string content = this.TextBox2.Text.ToString();
                string src = "";
                if (Request.QueryString["id"] != null)
                {
                    sql = "update FlowDoc set Title='" + title + "',Content='" + content + "',IsSave=0";
                    if (OperateDB.ExecuteNonQuery(sql)!=1)
                    {
                        Response.Write("<script>alert('发送失败!');</script>");
                        return;
                    }
                    sql = "select top 1 Num from Path where FlowID=" + Convert.ToInt32(Request.QueryString["id"]) + " order by Num desc";
                    int approve = Convert.ToInt32(OperateDB.getExecuteScalar(sql));

                    sql = "select Num from Path where UserID=" + userid;
                    int num = Convert.ToInt32(OperateDB.getExecuteScalar(sql));

                    sql = "select * from Path where FlowID=" + flowid;

                    DataSet ds = OperateDB.ExecuteDataSet(sql);
                    

                    //int result = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (Convert.ToInt32(dr["UserID"]) == userid)
                        {
                            string strSql = "insert into FlowPath (DocID,FlowID,StepID,UserID,IsApprove,Num,IsJoin) values(" + Convert.ToInt32(Request.QueryString["id"]) + "," +
                            Convert.ToInt32(dr["FlowID"]) + "," + Convert.ToInt32(dr["ID"]) + "," + dr["UserID"].ToString() + "," + (approve - Convert.ToInt32(dr["Num"])) + "," + dr["Num"].ToString() + "," + dr["IsJoin"].ToString() + ")";
                            if (OperateDB.ExecuteNonQuery(strSql) != 1)
                            {
                                Response.Write("<script>alert('发送失败!');</script>");
                                return;
                            }
                            continue;
                        }
                        if (Convert.ToInt32(dr["Num"]) > num)
                        {
                            string strsql = "insert into FlowPath (DocID,FlowID,StepID,UserID,IsApprove,Num,IsJoin) values(" + Convert.ToInt32(Request.QueryString["id"]) + "," +
                            Convert.ToInt32(dr["FlowID"]) + "," + Convert.ToInt32(dr["ID"]) + "," + dr["UserID"].ToString() + "," + (approve - Convert.ToInt32(dr["Num"])) + "," + dr["Num"].ToString() + "," + dr["IsJoin"].ToString() + ")";
                            if (OperateDB.ExecuteNonQuery(strsql) != 1)
                            {
                                Response.Write("<script>alert('发送失败!');</script>");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    if (!Directory.Exists(Server.MapPath(".") + "\\Files\\"))
                    {
                        Directory.CreateDirectory(Server.MapPath(".") + "\\Files\\");
                    }

                    if (FileUpload1.PostedFile.ContentLength == 0)
                    {
                        src = "";
                    }
                    else
                    {

                        string strFilePath = FileUpload1.PostedFile.FileName;
                        FileInfo fl = new FileInfo(strFilePath);
                        string Ext = fl.Name;

                        src = Ext;
                        string ServerPath = Server.MapPath(".");
                        string strSeraPath = ServerPath + "\\Files\\" + src;
                        FileUpload1.PostedFile.SaveAs(strSeraPath);
                    }

                    string strSql1 = "insert into FlowDoc values('" + title + "'," + urgent + "," + flowid + ",1," + userid + ",'" + content + "',default,1,0,'" + src + "')";
                    if (OperateDB.ExecuteNonQuery(strSql1) != 1)
                    {
                        Response.Write("<script>alert('发送失败!');</script>");
                        return;
                    }

                    //插入申请审批路径
                    sql = "select top 1 ID from FlowDoc order by PubDate desc";
                    int docid = Convert.ToInt32(OperateDB.getExecuteScalar(sql));

                    sql = "select top 1 Num from Path where FlowID=" + flowid + " order by Num desc";
                    int approve = Convert.ToInt32(OperateDB.getExecuteScalar(sql));

                    sql = "select Num from Path where UserID=" + userid;
                    int num = Convert.ToInt32(OperateDB.getExecuteScalar(sql));//序号

                    sql = "select * from Path where FlowID=" + flowid;
                    DataSet ds = OperateDB.ExecuteDataSet(sql);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (Convert.ToInt32(dr["UserID"]) == userid)
                        {
                            string strSql = "insert into FlowPath (DocID,FlowID,StepID,UserID,IsApprove,Num,IsJoin) values(" + docid + "," +
                            Convert.ToInt32(dr["FlowID"]) + "," + Convert.ToInt32(dr["ID"]) + "," + dr["UserID"].ToString() + "," + (approve - Convert.ToInt32(dr["Num"])) + "," + dr["Num"].ToString() + "," + dr["IsJoin"].ToString() + ")";
                            if (OperateDB.ExecuteNonQuery(strSql) != 1)
                            {
                                Response.Write("<script>alert('发送失败!');</script>");
                                return;
                            }
                            continue;

                        }
                        if (Convert.ToInt32(dr["Num"]) > num)
                        {
                            string strsql = "insert into FlowPath (DocID,FlowID,StepID,UserID,IsApprove,Num,IsJoin) values(" + docid + "," +
                                Convert.ToInt32(dr["FlowID"]) + "," + Convert.ToInt32(dr["ID"]) + "," + dr["UserID"].ToString() + "," + (approve - Convert.ToInt32(dr["Num"])) + "," + dr["Num"].ToString() + "," + dr["IsJoin"].ToString() + ")";
                            if (OperateDB.ExecuteNonQuery(strsql) != 1)
                            {
                                Response.Write("<script>alert('发送失败!');</script>");
                                return;
                            }

                        }
                    }
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Bind();
        }
    }
}