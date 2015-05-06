using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace UI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult RebackStudentInfo(LoginSchoolPsw studentIdAndPsw)
        {
            
            GetLoginPsw getLoginPsw = GetLoginPsw.GetLoginPswClass(studentIdAndPsw.StudentID, studentIdAndPsw.StudentPsw);
            if(getLoginPsw==null)
            {
                return Json("k107");
            }
            studentModle.StudentInfo studentInfo = getLoginPsw.getInfo();
            if (studentInfo == null)
            {
                return Json("k101");
            }
            if (String.IsNullOrEmpty(studentInfo.Name))
                return Json(studentInfo.Id);
            ComeBackStudentInfo comeBackStudentInfo = new ComeBackStudentInfo()
            {
                StudentId = studentInfo.Id,
                StudentClass = studentInfo.Classid,
                StudentName = studentInfo.Name,
                StudentSex = studentInfo.Sex
                
            };
            
            Session["studentInfo"] = comeBackStudentInfo;

            //ViewData.Model = comeBackStudentInfo;

            return Json(comeBackStudentInfo);
        }
        [HttpPost]
        public JsonResult ok(ComeBackStudentInfo studentInfo)
        {
            ComeBackStudentInfo comeBackStudentInfo = Session["studentInfo"] as ComeBackStudentInfo;
         
            if(comeBackStudentInfo==null||comeBackStudentInfo.StudentId!=studentInfo.StudentId||comeBackStudentInfo.StudentName!=studentInfo.StudentName||comeBackStudentInfo.StudentSex!=studentInfo.StudentSex||comeBackStudentInfo.StudentClass!=studentInfo.StudentClass)
            {
                return Json("k102");

            }
            if (studentInfo.LoginImage != Session["LoginImageStr"] as String)
                return Json("k104");
            if (String.IsNullOrEmpty(studentInfo.StudentAdress) || String.IsNullOrEmpty(studentInfo.StudentLoginPsw) || String.IsNullOrEmpty(studentInfo.StudentPhone))
                return Json("k103");
            LoginPsw loginPsw = new LoginPsw()
            {
                StudentId = studentInfo.StudentId,
                StudentLoginPsw = studentInfo.StudentLoginPsw,
                StudentBasePsw = GetRandom32Num.GetRandom32Num.GetRandom()

            };
            StudentInfo studentInfoMin = new StudentInfo()
            {
                StudentAdress = studentInfo.StudentAdress,
                StudentClass = studentInfo.StudentClass,
                StudentId = studentInfo.StudentId,
                StudentLevel = 1,
                StudentName = studentInfo.StudentName,
                StudentPhone = studentInfo.StudentPhone,
                StudentRecNum = 0,
                StudentSendNum = 0,
                StudentSex = studentInfo.StudentSex
            };
            SaveInfo saveInfo = new SaveInfo(loginPsw, studentInfoMin);
            if (!saveInfo.SaveLoginPsw())
                return Json("k105");
            if (!saveInfo.SaveStudentInfo())
                return Json("k106");
            return Json("k100");
        }

    }
}
