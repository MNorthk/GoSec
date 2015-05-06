using Bll;
using Model;
using PM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        public JsonResult CookieLogin()
        {
            //if (Response.Cookies["UserId"] != null)
            if (Request.Cookies["UserIdNorth"] == null || Request.Cookies["UserLoginNorth"] == null)
                return Json("k107");
            string id = Request.Cookies["UserIdNorth"].Value;
            if (String.IsNullOrEmpty(id))
                return Json("k107");
            string base32 = Request.Cookies["UserLoginNorth"].Value;
            if (String.IsNullOrEmpty(base32))
                return Json("k107");
            Bll.CookieLogin cookieLogin = Bll.CookieLogin.getCookieLogin(id, base32);
            if (cookieLogin == null)
                return Json("k107");
            string MKey = cookieLogin.LookBAndId();
            if (MKey == "k100")
            {

                Session["studentNorth"] = id;

            }
            return Json(MKey);

        }
        private string  getId()
        {
            if (Session["studentNorth"] == null)
                return "k203";
            else
                return Session["studentNorth"].ToString();
        }
        public JsonResult getUserId()
        {
            return Json(getId(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult getSomeInfo(string guestId)
        {
            if (guestId == "0")
                guestId = getId();
            if (guestId == "k203")
                return Json("k203");
           // string masterId = getId();
            GetUserInfo getUserInfo = new GetUserInfo();
            SomeStudentInfo someStudentInfo = getUserInfo.someGetUserInfo(guestId);
            if (someStudentInfo == null)
                return Json("k301");
            else
                return Json(someStudentInfo);
        }

        //
        // GET: /Login/
        [HttpPost]
        public JsonResult Login(string StudentId,string StudentPsw,int isCookie)
        {
            if (isCookie == 0)
            {
                Response.Cookies["UserLoginNorth"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(-1);
         
            }
            LoginInOurs loginInOurs = LoginInOurs.getLoginInOurs(StudentId, StudentPsw);
            if (loginInOurs == null)
                return Json("k107");
            string MKey = loginInOurs.LookPswAndId();
            if (MKey == "k100")
            {
                if (isCookie == 1)
                {
                   // string encodeId=Encrypt.Encode(StudentId);
                    Response.Cookies["UserIdNorth"].Value = StudentId;
                    Response.Cookies["UserIdNorth"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["UserLoginNorth"].Value = loginInOurs.getBase32();
                    Response.Cookies["UserLoginNorth"].Expires = DateTime.Now.AddDays(30);
                }
                Session["studentNorth"] = StudentId;

            }
            return Json(MKey);
        }
        
    

    }
}
