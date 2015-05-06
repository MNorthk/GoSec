


function logbtncli()
{
    var cook = 0;
   
	 var num=$("#idtext").val();
	 var pass = $("#pastext").val();
	 if (document.getElementById("isCookie").checked==true)
	     cook = 1;
	 else
	     cook = 0;
	// alert(cook);
	 $.post("/Login/Login",//登陆页面用
	 	{
	 	    StudentId: num,
	 	    StudentPsw: Encode(pass),
            isCookie:cook
	 	},
	 	function(d){
	 	    switch (d) {
	 	      
	 	        case "k107": alert("登陆失败"); break;
	 	        case "k108": alert("密码错误"); break;
	 	        case "k109": alert("账号错误"); break;
	 	        case "k110": alert("服务器错误"); break;
	 	        case "k100": location.href = "info.html"; break;
	 	        default: alert("我也不知道哪里错了。。");
	 	    }
	 	});
}




function  bfcli()
{
	var num=$("#in-number").val();
	var bfpass=$("#in-pass").val();
	$.post("/Home/RebackStudentInfo",//一开始注册时的身份认证用
		{StudentID:num,
		StudentPsw:Encode(bfpass)},
		function(d){
		    switch(d)
		    {
		        case "k101":alert("该账号已注册");break; 
		        case "k107":alert("登陆失败");break; 
		        case "k108":alert("密码错误");break; 
		        case "k109":alert("账号错误");break; 
		        case "k110":alert("服务器错误");break; 
		        ////case "":alert("");break; 
		        ////case "":alert("");break; 
		        ////case "":alert("");break; 
		        ////case "":alert("");break; 
		        ////    登陆失败  k107
		        ////    该账号已注册  k101
		        ////    与教务系统信息不同  k102
		        ////    未填写全  k103
		        ////    验证码错误  k104
		        ////    密码保存失败  k105
		        ////    个人信息保存失败  k106
		        ////    密码错误 k108
		        ////    账号错误 k109
		        ////    服务器错误 k110
		            ////    Base32码错误 k111
		        default:
		            $("#bf-form").attr("class", "pm-hide");
		            $("#regi-form").attr("class", "pm-show");
		            $("input[name='StudentId']").val(d.StudentId);
		            $("input[name='StudentId']").attr('disabled','true');
		            $("input[name='StudentClass']").val(d.StudentClass);
		            $("input[name='StudentName']").val(d.StudentName);
		            $("input[name='StudentSex']").val(d.StudentSex);
		            location.href = "sign.html";

		    }
			//if(d.str=="Y"){
			//	$("#bf-form").attr("class", "pm-hide");
			//	$("#regi-form").attr("class", "pm-show");
			//	//然后补全一堆东西
			//	// 姓名
			//	// 性别
			//	// 班级
			//	// 考生号（？）
			//	// 学籍状态
			//	// 身份证号（？）
			//}
		});
	

}

function bfSubmit() {

    var number = document.getElementById("re-number").value.toString();
    var name = document.getElementById("re-name").value.toString();
    var cls = document.getElementById("re-class").value.toString();
    var tel = document.getElementById("re-tel").value.toString();
    var sex = document.getElementById("re-sex").value.toString();
    var ss = document.getElementById("re-ss").value.toString();
    var password1 = document.getElementById("re-pass1").value.toString();
    var veri = document.getElementById("re-veri").value.toString();
    if (tel.length != 11)
    {
        alert("手机号不对哎，再看看~");
        return;
    }
    if (tel == '' || ss == '' || password1 == '')
    {
        alert("好像有什么地方没有写哎，再检查一遍吧~");
        return;
    }
    var obj = {
        StudentId: number,
        StudentName: name,
        StudentClass: cls,
        StudentPhone: tel,
        StudentSex: sex,
        StudentAdress: ss,
        StudentLoginPsw: password1,
        LoginImage:veri
        }
    doSubmit(obj);

 

}//纯判断
//学号re-number 姓名re-name 班级re-class 手机号re-tel 性别re-sex 宿舍地址re-ss 设置密码re-pass1 验证码re-veri

function doSubmit(obj) {
    $.ajax({
        url: "/Home/ok",
        type:'post',
        data: obj,
        beforeSend:function(){
            //发送前的界面处理
        },
        success: function (j) {
            switch(j)
            {
                case "k102": alert("与教务系统信息不同"); break;
                case "k103": alert("未填写全"); break;
                case "k104": alert("验证码错误"); break;
                case "k105": alert("密码保存失败"); break;
                case "k106": alert("个人信息保存失败"); break;
                case "k100": alert("成功"); break;
            }
            //返回的json的处理
        }
    })
}//注册时的数据提交

 