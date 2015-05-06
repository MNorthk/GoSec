using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class LoginPsw
    {
        public string StudentId { get; set; }
        public string StudentLoginPsw { get; set; }
        public string StudentBasePsw { get; set; }
    }
    public partial class LoginSchoolPsw
    {
        public string StudentID { get; set; }
        public string StudentPsw { get; set; }
    }
    public partial class StudentInfo
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentClass { get; set; }
        public string StudentAdress { get; set; }
        public string StudentPhone { get; set; }
        public int StudentSendNum { get; set; }
        public int StudentRecNum { get; set; }
        public int StudentLevel { get; set; }
        public string StudentSex { get; set; }
    }
    public partial class ComeBackStudentInfo
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentClass { get; set; }
        public string StudentAdress { get; set; }
        public string StudentPhone { get; set; }
        public string StudentLoginPsw { get; set; }
        public string StudentSex { get; set; }
        public string LoginImage { get; set; }
    }
    public class SomeStudentInfo
    {
        public string StudentName { get; set; }
        public int StudentSendNum { get; set; }
        public int StudentRecNum { get; set; }
        public int StudentLevel { get; set; }
    }
}
