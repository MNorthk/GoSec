jQuery(function ($) {

    $(window).load(function () {
      
    });






	 $(document).ready(function () {
	 	$(".infoDiv").hide();
	 	$.get("###",function(d){
 			//处理返回的快递信息，提取姓名 快递名  快递所在的位置以及快递的主人对本单快递的备注啥的
		var str='';//把所有的信息都加过来
		// for(var u in d){
		// 	str=str+'<li><a class="infoA ui-btn ui-btn-icon-right ui-icon-carat-r" href=""><h2>来自 '+d[u].东区还是西区，或者宿舍楼号 +'的 '+d[u]./*收件人*/ +'有快递在'+d[u]./*取快递的位置*/ +'</h2><p>'+d[u]./*快递主人的备注啊描述啊啥的*/ +'</p></a></li>';
		// }
		if(str=='')
		{
			str+='<li><a class="ui-btn"><h2>哎呀，没有人发布消息哎~</h2></a></li>'
		}
 		
	 
	 
	 document.getElementById("infolist").innerHTML = str;
	 });
	 });


	 	$("#rightStatus").change(function(){
		var status=$(this).children("option:selected").val();
		  
		switch(status)
		{
			case '登录':location.href='login.html';break;
			case '注册':location.href='sign.html';break;
			default:;break;
		}
	});
});


var begin = function () {
    $.post("/Login/CookieLogin", function (d) { $("#LoginMes").val(d) });
    if ($("#LoginMes").val() != "k100") {
        $("#rightK").html(" <select  data-native-menu='false'><option>游客</option><option id='z-login'>登陆</option><option>注册</option>	 </select>");
    } else {
        $.post("/Login/getSomeInfo", { guestId: "0" }, function (d) {

            if (d.StudentName == null) {
                $("#rightK").html(" <select  data-native-menu='false'><option>游客</option><option>登陆</option><option>注册</option> </select>");
            }
            else
                $("#rightK").html(" <select  data-native-menu='false'><option>" + d.StudentName + "</option><option>About Me</option><option>退出</option> </select>");
        });
    }
};
var href = function () {
    location.href = "login.html";
}
$(function () {
    begin();
    getInfo();


});


 	function getInfo(){
 	    $.get("/Goods/getSomeGoodsInfo", function (d) {
 			//处理返回的快递信息，提取姓名 快递名  快递所在的位置以及快递的主人对本单快递的备注啥的
		var str='';//把所有的信息都加过来
		for (var u in d) {
		    str = str + '<li><a class="ui-btn ui-btn-icon-right ui-icon-carat-r" href=""><h2>来自 ' + d[u].takeGoodsAdress + '的某同学有快递在' + d[u].expressAdress + '</h2><p>' + d[u].goodsInfo + '</p></a></li>';
		}
		$("#infolist").html(str);
 		
	 if(str=='')
		{
			str+='<li><a class="ui-btn"><h2>哎呀，没有人发布消息哎~</h2></a></li>'
		}
	 
	 document.getElementById("infolist").innerHTML = str;
	 });
}

	$(".infoA").click(function (){
		$.post("/Login/CookieLogin", function (d) {
        if (d == "k100")
        {
            alert("ok");//登录状态
            $('#infolist').hide();
            $(".infoDiv").show();
            $('#yes').click(function(){
            	//显示详细信息
            });
           
        }
        else 
        	alert("亲，还没登录呢~");
    });

		$('#no').click(function(){
			$(".infoDiv").hide();
			$('#infolist').show();
		});
	});

