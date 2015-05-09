jQuery(function($){
	$(document).ready(function(){
		$('#changePass').hide();
		$("#modifyPass").hide();
	});
});


function yBtnOnclick(){
	var newName=$('#infoName').val();
	var num=$('#infoNum').val();
	var newNickname=$('#infoNickname').val();
	var newAddr=$("#infoAddr").val();

	$.post('',{
		/////////
	},function(d){
		////
	});
}

$("#infoPass").click(function(){
	$(".infoForm").hide();
	$("#changePass").show();

	
});

$("#changeBtn").click(function(){
		var newPass=$("#newPass").val();
		var num=$("#changeNum").val();
		$.post('',{
///////////////////
		},function(){
			////////////////

			$("#changePass").hide();
			$("#modifyPass").show();
		});

	});
$("#changeBtnNo").click(function(){
	$("#modifyPass").hide();
	$(".infoForm").show();
	$("#changePass").hide();

});