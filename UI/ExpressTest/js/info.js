var begin=function(){
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
var href=function()
{
    location.href = "login.html";
}
$(function () {
    begin();
    getInfo();


});
function getInfo() {
    //var str = '';
 	    $.get("/Goods/getSomeGoodsInfo", function (d) {
 			//处理返回的快递信息，提取姓名 快递名  快递所在的位置以及快递的主人对本单快递的备注啥的
 	        //把所有的信息都加过来
 	        var str = '';
 	        for (var u in d)
 	        {
 	            str = str + '<li><a class="ui-btn ui-btn-icon-right ui-icon-carat-r" href=""><h2>来自 ' + d[u].takeGoodsAdress + '的某同学有快递在' + d[u].expressAdress + '</h2><p>' + d[u].goodsInfo + '</p></a></li>';
 	        }
		 	    $("#infolist").html(str);
 	    });

	 
	 
 	    
}

	