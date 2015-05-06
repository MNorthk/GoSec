using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace UI
{
    /// <summary>
    /// LoginImage 的摘要说明
    /// </summary>
    public class LoginImage : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/gif";
            string LoginStr = getString();
            context.Session["LoginImageStr"] = LoginStr;
            ImageLibrary.CheckImage LoginGif = new ImageLibrary.CheckImage(LoginStr);
            MemoryStream ms=LoginGif.GetImage() as MemoryStream;

            context.Response.BinaryWrite(ms.ToArray());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        private static string getString()
        {
            string str;
            str = new Random().Next(1000,9999).ToString();

            return str;
        }
    }
}