using System;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace OA.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string Time = DateTime.Now.ToString();
            string ip;
            if (Context.Request.ServerVariables["HTTP_VIA"] != null) // using proxy
            {
                ip = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP.
            }
            else// not using proxy or can't get the Client IP
            {
                ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP.
            }
           

            //if (Request.Cookies["ip"] == null||Request.Cookies["address"]==null)
            //{
            //    HttpCookie ipcookie = new HttpCookie("ip");
            //    ipcookie.Value = ip;
            //    ipcookie.Expires = DateTime.Now.AddHours(4);
            //    Response.AppendCookie(ipcookie);
            //    HttpCookie addresscookie = new HttpCookie("address");
            //    string url = "http://apis.baidu.com/apistore/iplookupservice/iplookup";
            //    string result= request(url, "ip="+"123.118.106.56");
            //    JObject jo = (JObject)JsonConvert.DeserializeObject(result.Trim());
            //    try
            //    {
            //        addresscookie.Value = jo["retData"]["province"].ToString() + jo["retData"]["city"].ToString() + jo["retData"]["district"].ToString();
                    
            //    }
            //    catch (Exception)
            //    {
            //        addresscookie.Value = "北京朝阳";
            //        throw;
            //    }
            //    addresscookie.Expires = DateTime.Now.AddHours(4);
            //    Response.AppendCookie(addresscookie);

            //}
            
            SqlLogin sl = new SqlLogin();

            if (this.username.Text.Trim() == "")
            {
                Response.Write("<script>alert('请输入帐号!!')</script>");
            }
            else if (this.password.Text.Trim() == "")
            {
                Response.Write("<script>alert('请输入密码!!')</script>");

            }
            else
            {
                string UserName = this.username.Text.Trim();
                string Password = this.password.Text.Trim();

                if (sl.Login(UserName, Password) == false)
                {
                    
                    string State = "帐号或密码错误";
                    //SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
                    //con.Open();
                    string Sql = "insert into News values(" + UserName + ",'" + DateTime.Now + "','" + ip + "','帐号或密码错误')";
                    sl.InsertLoginInfo(UserName, Time, ip, State);
                    Response.Write("<script>alert('帐号或密码错误！！')</script>");
                }
                else
                {
                    Session["UserName"] = UserName;
                    sl.InsertLoginInfo(UserName, Time, ip, "正常登录");
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(UserName, false);
                    Response.Redirect(Request.ApplicationPath+"main.aspx");
                }
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


    }
}