$(document).ready(function(){
	
	$(document).on('click', "#save", function(e){
		if($("input[name='password']").val() != $("input[name='passwordRepeat']").val()){
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Паролите не съвпадат!" );
			return false;
		}
		
		if($("input[name='password']").val().length < 4)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Паролите трябва да е по дълга от 4 символа!" );
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
			url = servicePart + "Users/NewUser";
		
		data.PassHash = sha512( $("input[name='password']").val() );
		data.FullName = $("input[name='firstName']").val() + " " + $("input[name='lastName']").val();
		data.Name = $("input[name='userName']").val();
		data.Email = $("input[name='email']").val();
		data.Address = $("input[name='address']").val();
		
		data = JSON.stringify(data);
		
		$.ajax({
			url: url,
			method: "POST",
			data: {data},
			success: function( result ){
				loadHTML("home");
				$(".rightMenu").empty();
				$(".rightMenu").append(
					'<li><a href="#" data-page="login">Вход</a></li>' +
					'<li><a href="#" data-page="registration">Регистрация</a></li>'
				)
				$( "#dialog" ).dialog();
				$( "#dialog" ).text( "Вие се регистрирахте успешно!" );
			},
			error: function( error ){
				var inputString = error.responseText;
				var dataObject =  JSON.parse(inputString);
				if(dataObject.Result== "Потребител с това име вече съществува"){
				$( "#dialog" ).dialog({resizable:false});
				$( "#dialog" ).text( "Потребител с това име вече съществува!" );
			}}
		});
		
	});
	
	$(document).keypress(function( e ){
		if( e.keyCode == 13 ){
			$("#save").trigger("click");
		};
	})
});