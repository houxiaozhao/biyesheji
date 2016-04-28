using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OA
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bing1();
            bind2();
            Bind3();
            Bind4();
            Bind5();
        }

        private void Bind5()
        {
            try
            {
                int id = 0;
                string url = "http://apis.baidu.com/songshuxiansheng/news/news";
                string param = "";
                string result = request(url, param);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result.Trim());
                List<Realtimenews> newslist = new List<Realtimenews>();
                foreach (var item in jo["retData"].ToArray())
                {
                    Realtimenews news = new Realtimenews();
                    news.id = id;
                    news.title = item["title"].ToString();
                    news.abs = item["abstract"].ToString();
                    news.url = item["url"].ToString();
                    news.img = item["image_url"].ToString();
                    newslist.Add(news);
                    id++;
                }
                string html = "";
                int i = 0;
                foreach (var item in newslist)
                {
                    string attr = "";
                    if (i == 0)
                    {
                        attr = "panel-collapse collapse in";
                        i = 1;
                    }
                    else
                    {
                        attr = "panel-collapse collapse";
                    }
                    html += string.Format(@"<div class='panel'>
                    <div class='panel-heading'>
                        <div class='row'>
                            <div class='col-md-9'>
                                <h4 class='panel-title'>
                                    <a class='accordion-toggle' data-toggle='collapse' data-parent='#accordion' href='#{0}'>
                                        {1} </a>
                                </h4>
                            </div>
                            <div class='col-md-3 more'>
                                <span class='tools pull-right'>
                                    <a runat='server' href='{2}' class='fa  fa-ellipsis-h' target='_blank'>
                                    </a></span>
                            </div>
                        </div>
                    </div>
                    <div id='{3}' class='{4} '>
                        <div class='panel-body'>
                            <div class=' video item '>
                                <a href='#myModal' data-toggle='modal'>
                                    <img src='{5}' alt='' class='float-lt img-rounded img-thumbnail newimg' />
                                </a>
                            </div>
                            {6}
                        </div>
                    </div>
                </div>", item.id.ToString(), item.title, item.url, item.id.ToString(), attr, item.img, item.abs);
                }
                this.accordion.InnerHtml = html;
            }
            catch (Exception)
            {

                return;
            }
            

        }
        /// <summary>
        /// 发送HTTP请求
        /// </summary>
        /// <param name="url">请求的URL</param>
        /// <param name="param">请求的参数</param>
        /// <returns>请求结果</returns>
        public static string request(string url, string param)
        {
            string strURL = url + '?' + param;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "GET";
            // 添加header
            request.Headers.Add("apikey", "35f9a53a43080378b2b026abb1f0e425");
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }

            return Regex.Unescape(strValue); 
        }
        public string getRemark()
        {
            string html="";
            string sql1 = "select top 5 * from NewsRemark where NewID in (select newsid from News where UserID=(select Employeeid from Employee where username='" + getname() + "')) order by Pubdate desc";
            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con1.Open();
            SqlCommand com1 = new SqlCommand(sql1, con1);
            SqlDataReader dr1 = com1.ExecuteReader();
            List<remark> remarklist = new List<remark>();
            while (dr1.Read())
            {
                remark re = new remark();
                string sql = "select username from Employee where Employeeid=" + dr1["UserID"];
                re.username = OperateDB.getExecuteScalar(sql);
                sql = "select title from News where NewsID=" + dr1["NewID"];
                re.title = OperateDB.getExecuteScalar(sql);
                re.content = dr1["content"].ToString();
                re.time = dr1["Pubdate"].ToString();               
                remarklist.Add(re);
            }
            foreach (var item in remarklist)
            {
                html += string.Format(@"<li class='in'>
                                    <img src='images/anonymous.png' alt='' class='avatar'>
                                    <div class='message'>
                                        <span class='arrow'></span>
                                        <a class='name' href='#'>{0}</a>
                                        <span class='datetime'>at {1}</span>
                                        <span class='body'>
                                            {2}
                                        </span>
                                    </div>
                                </li>",item.username,item.time,item.content);
            }
            return html ;
        }
        public string gettime(string type)
        {

            List<string> timeon = new List<string>();
            List<string> timeoff = new List<string>();
            string sql = "select top 7 Ontutytime,OffdutyTime from [Check] where username='" + Session["UserName"].ToString() + "'";
            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
            con1.Open();
            SqlCommand com1 = new SqlCommand(sql, con1);
            SqlDataReader dr = com1.ExecuteReader();
            while (dr.Read())
	        {
                timeon.Add(Convert.ToDateTime(dr["Ontutytime"].ToString()).ToShortTimeString().Replace(":","."));
                timeoff.Add(Convert.ToDateTime(dr["OffdutyTime"].ToString()).ToShortTimeString().Replace(":", "."));
	        }
            switch (type)
            {
                case "上":
                    return string.Join(",", timeon);
                case"下":
                    return string.Join(",", timeoff);
                default:
                    return "";
            }
        }
        private string getname()
        {
            string sql = "select Name from Employee where username='" + Session["UserName"].ToString() + "'";

            string Name = OperateDB.getExecuteScalar(sql);
            return Name;
        }
        private void bing1()
        {
            string UserName = Session["UserName"].ToString();
            string sql = "select id from UserInfo where UserName='" + UserName + "'";
            int id = Convert.ToInt32(OperateDB.getExecuteScalar(sql));
            string sql1 = "select top 5 * from Calendar where id=" + id + " order by CalendarID desc";
            DataSet ds = OperateDB.ExecuteDataSet(sql1);
            this.DataList1.DataSource = ds.Tables[0];
            this.DataList1.DataBind();
        }
        private void bind2()
        {
            string Name = SelectName();
            string sql = "select top 5 title,sid,Pubdate from Email where Meetname='" + Name + "' order by sid desc ";
            this.DataList2.DataSource = OperateDB.ExecuteDataSet(sql);
            this.DataList2.DataBind();
        }
        public void Bind3()
        {
            string sql = "select top 5 * from News order by NewsID desc";
            DataList3.DataSource = OperateDB.ExecuteDataSet(sql);
            DataList3.DataBind();
        }
        public void Bind4()
        {
            string sql = "select top 5 *  from [Plan] where username='" + Session["UserName"].ToString() + "' order by planid desc";
            this.DataList4.DataSource = OperateDB.ExecuteDataSet(sql);
            this.DataList4.DataBind();
        }
        public string SelectName()
        {
            string sql = "select Name from Employee where username='" + Session["UserName"].ToString() + "'";
            return OperateDB.getExecuteScalar(sql);

        }
    }

    public class remark
    {
        public string content { get; set; }
        public string time { get; set; }
        public string username { get; set; }
        public string title { get; set; }
    }
    public class Realtimenews
    {
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string abs { get; set; }
        public string img { get; set; }
    }

}