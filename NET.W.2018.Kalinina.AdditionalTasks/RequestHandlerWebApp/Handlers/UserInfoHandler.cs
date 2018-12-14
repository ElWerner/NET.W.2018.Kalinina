using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApp.Handlers
{
    public class UserInfoHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/Views/1.html";
            HtmlString str = new HtmlString(File.ReadAllText(path)); ;

            context.Response.Write(str);
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}