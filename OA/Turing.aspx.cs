using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace OA
{
    public partial class Turing : System.Web.UI.Page
    {
        public string userid="";
        protected void Page_Load(object sender, EventArgs e)
        {
            userid = Session["UserName"].ToString();
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

        protected void btn_Click(object sender, EventArgs e)
        {
            string content = this.text.InnerText;
            content = content.Replace("+", "%2B");
            content = content.Replace("&", "%26");
            content = content.Replace("%", "%25");
            this.kefu_text.InnerHtml = string.Format(@"<div class='right'>
                            <div class='text'>
                                <i></i><span>{0}</span></div>
                        </div>",content);
            string url = "http://apis.baidu.com/turing/turing/turing";
            string param = "key=879a6cb3afb84dbf4fc84a1df2ab7319&info=" + content + "&userid=" + Session["UserName"];
            string result = request(url, param);
            JObject jo = (JObject)JsonConvert.DeserializeObject(result.Trim());
            getResult(jo["text"].ToString());
           
        }

        private void getResult(string content)
        {
            this.kefu_text.InnerHtml = string.Format(@"<div class='left'>
                            <div class='text'>
                                <i></i><span>{0}</span></div>
                        </div>", content);
        }
    }
}