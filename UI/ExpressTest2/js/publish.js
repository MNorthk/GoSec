function bfPub() {
    var eAddr = $('#eAdr').val();
    var tAddr = $('#tAdr').val();
    var gInfo = $("#gInfo").val();
    var h = $("#time-h").val();
    var m = $("#time-m").val();
   
    //开始验证信息

    if (Number(h) > 23 || Number(h) < 0 || Number(m) > 60 || Number(m) < 0) {
        alert("时间是不是不对了~");
        return false;
    }
    if (eAddr == '' || tAddr == '' || gInfo == '' || h == '' || m == '') {
        alert("信息有没有填写的嗯");
        return false;
    }
    h = String(h);
    m=String(m);
    var ttime = h + ':' + m;
   
     
    var id ;
   
   $.get(
                 "/Login/getUserId",function(d){
                     id=d;}
               );
 
    
    var obj = {
        //goodsId咋办
        goosId:12,
        masterId: id ,
        //state
        expressAdress: eAddr,
        takeGoodsAdress: tAddr,
        goodsInfo: gInfo,
        takeTime: ttime
        
    }
     
    publish(obj);

}

function publish(obj) {
    alert(obj);
    $.post("/Goods/setGoodsInfoIn", obj, function (d) {
        //回调
        alert(gInfo);
        switch(d)
        {
            case 'k200':
                {
                    alert("发布成功~");
                    Location.href = 'index.html';
                    break;
                }
            case 'k204':
                {
                    aler('时间写的不对吧~');
                    break;
                }
            case "k201":
                {
                    alert("信息不完整~");
                    break;
                }
            case 'k203':
                {
                    alert("登录超时，请重新登录~");
                    break;
                }
            case 'k202':
                {
                    alert("信息发布失败，请重试~");
                    break;
                }
            default:
                alert("哎呀，不知道哪里出错了~");
                break;
        }
         
    });
}