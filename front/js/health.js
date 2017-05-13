$(document).ready(function(){
	//document.getElementById('attach').addEventListener('change', handleFileSelect, false);
	
	$(document).on('click', "#saveHealth", function(e){
		
		if($("input[name='egn']").val().length < 10)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Въвели сте невалидно ЕГН!" );
			return false;
		}
		
		if($("input[name='phone']").val().length < 10)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Въвели сте невалиден мобилен номер!" );
			return false;
		}
		
		if($("input[name='document']").val().length < 1)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Не сте въвели номер на документа!" );
			return false;
		}
		
		if(TryParseInt($("input[name='document']").val(),0)!=$("input[name='document']").val())
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Моля въведете число в полето за номер на документ!" );
			return false;
		}
		
		if($("input[name='iban']").val().length < 1)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Не сте въвели IBAN!" );
			return false;
		}
		
		if($("#company").val()=="Избери")
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Не сте въвели застрахователна компания!" );
			return false;
		}
		
		if(base64Code=="")
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Грешка при прикачването на файла!" );
			return false;
		}
		
		var data = {},
			url = servicePart + "Clients/AddHealthRequest";
			
		data.fullName=	$("input[name='name']").val();
		data.EGN=$("input[name='egn']").val();	
		data.mobilePhone= $("input[name='phone']").val();
		data.email= $("input[name='email']").val();
		data.address=$("input[name='address']").val();
		data.documentNumber=$("input[name='document']").val();
		data.iban=$("input[name='iban']").val();
		data.userId=$("input[name='personalNumber']").val();
		data.company=capitalizeFirstLetter($("#company").val());
		data.attachFile=base64Code;
		
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
				$( "#dialog" ).text( "Вие записахте искането успешно!" );
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
			$("#saveHealth").trigger("click");
		};
	})
});