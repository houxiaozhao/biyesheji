using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OA.Administrator
{
    public class admin
    {
        public static bool isadmin(string name) 
        {
            string sql =string.Format( @"SELECT  dutyid
FROM      Userinfo
WHERE   (UserName = '{0}')",name);
            if (Convert.ToInt32( OperateDB.getExecuteScalar(sql))>4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}