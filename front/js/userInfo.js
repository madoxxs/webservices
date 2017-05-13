$(document).ready(function(){
	$(document).on('click', "#saveUpdate", function(e){
		
		if($("input[name='passwordUpdate']").val() != $("input[name='passwordRepeatUpdate']").val()){
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Паролите не съвпадат!" );
			return false;
		}
		
		if($("input[name='firstName']").val().length < 2)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Първото име трябва да е по дълго от 1 символ!" );
			return false;
		}
		
		if($("input[name='lastName']").val().length < 2)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Фамилията трябва да е по дълго от 1 символ!" );
			return false;
		}
		
		
		if(!ValidateEmail($("input[name='email']").val()))
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Въведете правилен имейл!" );
			return false;
		}
		
		if($("input[name='address']").val().length < 6)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Адресът трябва да е по-дълъг от 6 символа!" );
			return false;
		}
		
		var data = {
		},
		url = servicePart + "Users/UpdateUser";
	    if($("input[name='passwordUpdate']").val() != "")
		{
			data.PassHash = sha512( $("input[name='passwordUpdate']").val() );
		}
		data.FullName = $("input[name='firstName']").val() + " " + $("input[name='lastName']").val();
		data.Email = $("input[name='email']").val();
		data.Address = $("input[name='address']").val();
		data.oldUserName=userInfo.userName;
		
		data = JSON.stringify(data);
		
		$.ajax({
			url: url,
			method: "POST",
			headers:{SessionId: userInfo.sessionId},
			data: {data},
			success: function( result ){
				setCookie('logged', '', -1);
				loadHTML("home");
				$(".rightMenu").empty();
				$(".rightMenu").append(
					'<li><a href="#" data-page="login">Вход</a></li>' +
					'<li><a href="#" data-page="registration">Регистрация</a></li>'
				)
				$( "#dialog" ).dialog({resizable:false});
				$( "#dialog" ).text( "Вие успешно направихте промяната!" );
			},
			error: function( error ){
				
				$( "#dialog" ).dialog({resizable:false});
				$( "#dialog" ).text( "Промяната е неуспешна!Опитайте отново!" ); 
			}
		});
	});
});