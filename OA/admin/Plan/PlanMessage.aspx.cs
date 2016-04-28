using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace OA.admin.Plan
{
    public partial class PlanMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (!string.IsNullOrEmpty(Request["planid"]))
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                    con.Open();
                    int PlanID = Convert.ToInt32(Request["planid"].ToString());
                    string sql = "select * from [plan] where planid=" + PlanID + " ";
                    SqlCommand com = new SqlCommand(sql, con);
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        this.planID.InnerText = dr["planID"].ToString();
                        this.topic.InnerText = dr["topic"].ToString();
                        this.addtime.InnerText = dr["AddTime"].ToString();
                        this.content.InnerText = dr["Content"].ToString();
                    }
                    con.Close();
                }
            
            
        }
        public string qwe(string planID, string topic, string addtime, string content)
        {
                if (addtime == null || content == null || topic == null)
                {
                    return "输入不完整";
                }
                else
                {
                    try
                    {
                        if (string.IsNullOrEmpty(planID) && addtime != null && content != null && topic != null)
                        {
                            string sql = "insert  [Plan] values('" + Convert.ToDateTime(addtime) + "','" + content + "','" + topic + "','" + Session["UserName"].ToString() + "')";
                            if (OperateDB.ExecuteNonQuery(sql) == 1)
                            {
                                Response.Write("<script>alert('！')</script>");
                                this.topic.InnerText = "";
                                this.addtime.InnerText = "";
                                this.content.InnerText = "";
                                this.planID.InnerText = "";
                            }

                            return "添加成功";
                        }
                        else
                        {
                            string sql = "update [Plan] set topic='" + topic.Trim() + "',Content='" + content.Trim() + "',Addtime='" + addtime.Trim() + "'  where PlanID='" + planID + "'";
                            OperateDB.ExecuteNonQuery(sql);
                            this.topic.InnerText = topic;
                            this.addtime.InnerText = addtime;
                            this.content.InnerText = content;
                            this.planID.InnerText = planID;
                            return "更新成功";
                        }
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>输入正确格式</script>");
                        return "格式不正确";
                    }

                }
            
        }

        private void NewMethod(string tit)
        {
            string sl = "<script language='javascript' type='text/javascript'>  haha('提示','" + tit + "')</script>";
            ClientScript.RegisterStartupScript(typeof(string), "haha", sl);
        }

        
    }
}