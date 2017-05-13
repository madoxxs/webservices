$(document).ready(function(){
	$(document).on('click', "#reset", function(e){
		if($("input[name='username']").val().length < 1)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Не сте въвели потребителско име!" );
			return false;
		}
		
		if($("input[name='email']").val().length < 1)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Не сте въвели имейл!" );
			return false;
		}
		
		var username = $("input[name='username']").val(),
			email=$("input[name='email']").val(),
			url = servicePart + "Users/ForgivPassword?userName=" + username + "&email=" + email;
		    
		$.ajax({
		url: url,
		headers:{SessionId: userInfo.sessionId},
		success: function(result){
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Паролата е възстановена!Новата парола Ви беше изпратена на имейла!" );
			loadHTML("login");
		},
		error: function( error ){
			var inputString = error.responseText;
				var dataObject =  JSON.parse(inputString);
				if(dataObject.Result== "Username and email are not found"){
					$( "#dialog" ).dialog({resizable:false});
					$( "#dialog" ).text( "Грешно потребителско име или имейл!" );
				}
				else {
					$( "#dialog" ).dialog({resizable:false});
					$( "#dialog" ).text( "Възникна грешка!Моля опитайте пак!" );
				}
		}
	});
	});
});