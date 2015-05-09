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
    var ttime = h + ':' + m;

    var obj = {
        //goodsId咋办
        masterId: function () {
            return $.get(
                  "/Login/getUserId"
                );
        }(),
        //state
        expressAdress: eAddr,
        takeGoodsAdress: tAddr,
        goodsInfo: gInfo,
        takeTime: ttime
    }
    publish(obj);

}

function publish(obj) {
    $.post("/Goods/setGoodsInfoIn", obj, function (d) {
        //回调
        alert(d);
    });
}