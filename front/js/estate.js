$(document).ready(function(){
	$(document).on('click', "#saveEstate", function(e){
	
		if($("input[name='area']").val().length < 1)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Не сте въвели площ на имота!" );
			return false;
		}
		
		if(TryParseInt($("input[name='area']").val(),0)!=$("input[name='area']").val())
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Моля въведете число в полето за площ на имота!" );
			return false;
		}
		
		if(base64Code=="")
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Грешка при прикачването на файла!" );
			return false;
		}
		
		if($("#company").val()=="Избери")
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Не сте въвели застрахователна компания!" );
			return false;
		}
		
		if($("input[name='phone']").val().length < 10)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Въвели сте невалиден мобилен номер!" );
			return false;
		}
		
		if($("input[name='kind']").val().length < 1)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Не сте въвели вид на имота!" );
			return false;
		}
	
		if($("input[name='egn']").val().length < 10)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Въвели сте невалидно ЕГН!" );
			return false;
		}
		
		if($("input[name='price']").val().length < 1)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Не сте въвели площ на имота!" );
			return false;
		}
		
		if(TryParseInt($("input[name='price']").val(),0)!=$("input[name='price']").val())
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Моля въведете число в полето за площ на имота!" );
			return false;
		}
		
		var data = {},
			url = servicePart + "Clients/AddEstateRequest";
		data.fullName=	$("input[name='name']").val();
		data.EGN=$("input[name='egn']").val();	
		data.mobilePhone= $("input[name='phone']").val();
		data.email= $("input[name='email']").val();
		data.address=$("input[name='address']").val();
		data.kind=$("input[name='kind']").val();
		data.area=$("input[name='area']").val();
		data.company=capitalizeFirstLetter($("#company").val());
		data.attachFile=base64Code;
		data.amount=$("input[name='price']").val();
		
		data = JSON.stringify(data);
		
		
		$.ajax({
			url: url,
			method: "POST",
			headers:{SessionId: userInfo.sessionId},
			data: {data},
			success: function( result ){
				$(".rightMenu").empty();
				$(".rightMenu").append(
					"<li><a href='#' id='user' data-page='userInfo'>"+ userInfo.userName +"</a></li>" + 
					"<li><a href='#' id='logout' data-page='home'>Logout</a><li> "
				);				
				$(".rightMenu li:last-child").remove();
				loadHTML("home");
				base64Code="";
				$( "#dialog" ).dialog({resizable:false});
				$( "#dialog" ).text( "Вие записахте полицата успешно!" );
			},
			error: function( error ){
				var inputString = error.responseText;
				var dataObject =  JSON.parse(inputString);
				if(dataObject.Result==  "Този файл вече съществува!"){
					$( "#dialog" ).dialog({resizable:false});
					$( "#dialog" ).text( "Този файл вече съществува!" );
				}
				
			}
		});
		
	});
	
	$(document).keypress(function( e ){
		if( e.keyCode == 13 ){
			$("#saveEstate").trigger("click");
		};
	})
});