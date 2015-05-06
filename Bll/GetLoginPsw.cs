using Dal;
using getStudentInfo;
using Model;
using PM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{

    public class GetUserInfo
    {
        public SomeStudentInfo someGetUserInfo(string studentId)
        {
            GoSecEntities Student = new GoSecEntities();
            var a=from u in Student.StudentInfo
                  where u.StudentId==studentId
                  select new SomeStudentInfo(){
                      StudentName=u.StudentName[0]+u.StudentSex.Replace("男","帅哥").Replace("女","美女"),
                      StudentSendNum=u.StudentSendNum,
                      StudentRecNum=u.StudentRecNum,
                      StudentLevel=u.StudentLevel
                  };
            if (a.Count() < 1)
                return null;
            else return a.First();
        }
        //这块也不行，得加查看人的验证，再写我就疯啦！！！
        public StudentInfo allGetUserInfo(string studentId,string UserId)
        {

           
                GoodsEntities goods = new GoodsEntities();
                var b = from u in goods.GoodsInfos
                        where u.guestId == UserId && DateTime.Compare(u.takeTime, DateTime.Now) > 0
                        select u;
                if (b.Count() < 1&&studentId!=UserId)
                    return null;

             GoSecEntities Student = new GoSecEntities();
            var a = from u in Student.StudentInfo
                    where u.StudentId == studentId
                    select u;
            if (a.Count() < 1)
                return null;
            else return a.First();
        }

    }
    public class GetLoginPsw
    {
        private string StudentId;
        private string StudentPsw;
        private GoSecEntities Student;
        private  GetLoginPsw(string id,string psw)
        {
            StudentId = id;
            StudentPsw = Encrypt.Decode(psw);
            Student = new GoSecEntities();
        }
        public static GetLoginPsw GetLoginPswClass(string id,string psw)
        {
            if (String.IsNullOrEmpty(id) || String.IsNullOrEmpty(psw))
                return null;
            if (id.Length != 8)
                return null;
            return new GetLoginPsw(id,psw);
        }
        private bool isInTable()
        {
            var i = from u in Student.LoginPsw
                    where u.StudentId == StudentId
                    select u;
            if (i.Count() > 0)
                return true;
            else
                return false;
        }
        private bool isInSchoolTable()
        {
            var i = from u in Student.LoginSchoolPsw
                    where u.StudentID == StudentId
                    select u;
            if (i.Count() > 0)
                return true;
            else
                return false;
        }

        public studentModle.StudentInfo getInfo()
        {
            if (isInTable())
                return null;
            
            studentModle.StudentInfo student = getStudentInfos.GetInfo(new studentModle.IdAndPsw() { StudentId = this.StudentId, StudentPsw = this.StudentPsw });
            if (!String.IsNullOrEmpty(student.Name) && !isInSchoolTable())
            {
                Student.LoginSchoolPsw.Add(new LoginSchoolPsw() { StudentID = this.StudentId, StudentPsw = this.StudentPsw });
                Student.SaveChanges();
            }
            return student;

        }


    }
    public class SaveInfo
    {
        private  LoginPsw loginPsw;
        private StudentInfo studentInfo;
        private GoSecEntities Student;
        public SaveInfo(LoginPsw loginPsw,StudentInfo studentInfo)
        {
            this.loginPsw = loginPsw;
            this.studentInfo = studentInfo;
            Student = new GoSecEntities();
        }
        public bool SaveLoginPsw()
        {
            Student.LoginPsw.Add(loginPsw);
            int i = Student.SaveChanges();
            if (i == 1)
                return true;
            else return false;
        }
        public bool SaveStudentInfo()
        {
            Student.StudentInfo.Add(studentInfo);
            int i = Student.SaveChanges();
            if (i == 1)
                return true;
            else return false;

        }

    }

    public class LoginInOurs
    {
        private string id;
        private string psw;
        private string base32;
        private GoSecEntities Student;
        private LoginInOurs(string id,string psw)
        {
            this.id = id;
            this.psw = Encrypt.Decode(psw);
            Student = new GoSecEntities();
               
        }
        public static LoginInOurs getLoginInOurs(string id,string psw)
        {
            if (String.IsNullOrEmpty(id) || String.IsNullOrEmpty(psw))
                return null;
            return new LoginInOurs(id,psw);
        }
        public string LookPswAndId()
        {
            var stu = from u in Student.LoginPsw
                      where u.StudentId == id
                      select new {psw=u.StudentLoginPsw,mybase32=u.StudentBasePsw};
            if (stu.Count() < 1)
                return "k109";
            if (stu.First().psw.ToString() == psw)
            {
                base32 = stu.First().mybase32;
                return "k100";
            }
            else
                return "k108";
        }
        public string getBase32()
        {
            //return from u in Student.LoginPsw
            //       where u.StudentId==id
            //       select
            return base32;
        }
        
    }
    public class CookieLogin
    {
        private string id;
        private string base32;
        private GoSecEntities Student;
         private CookieLogin(string id,string base32)
        {
            this.id = id;
            this.base32 = base32;
            Student = new GoSecEntities();
               
        }
         public static CookieLogin getCookieLogin(string id, string base32)
        {
            if (String.IsNullOrEmpty(id) || String.IsNullOrEmpty(base32))
                return null;
            return new CookieLogin(id, base32);
        }
         public string LookBAndId()
         {
             var stu = from u in Student.LoginPsw
                       where u.StudentId == id
                       select new { mybase32 = u.StudentBasePsw };
             if (stu.Count() < 1)
                 return "k109";
             if (stu.First().mybase32.ToString() == base32)
             {
                
                 return "k100";
             }
             else
                 return "k111";
         }
        

    }
}
