$(document).ready(function(){
	
	$(document).on('click', "#login", function(e){
		
		var username = $("input[name='login']").val(),
			password = sha512( $("input[name='password']").val() ),
		url = servicePart + "Users/Login?user=" + username + "&pass=" + password
		$.ajax({
			url: url,
			success: function( result ){
				
				var cook = "";
				for( var key in result ){
					cook += key + "=" + result[key] + "_";
				}
				
				setCookie('logged', cook, 1);
				
				userInfo.sessionId = result.sessionId;
				userInfo.userId = result.userId;
				userInfo.userName=result.userName;
				userInfo.firstName=result.firstName;
				userInfo.lastName=result.lastName;
				userInfo.address=result.address;
				userInfo.email=result.email;
				$(".rightMenu").empty();
				$(".rightMenu").append(
					"<li><a href='#' id='user' data-page='userInfo'>"+ result.userName +"</a></li>" + 
					"<li><a href='#' id='logout' data-page='home'>Logout</a><li> "
				);				
				$(".rightMenu li:last-child").remove();
				loadHTML("home");
			},
			error: function( error ){
				var inputString = error.responseText;
				var dataObject =  JSON.parse(inputString);
				if(dataObject.Result== "Username not found"){
					$( "#dialog" ).dialog({resizable:false});
					$( "#dialog" ).text( "Грешно потребителско име или парола!" );
				}
				else {
					$( "#dialog" ).dialog({resizable:false});
					$( "#dialog" ).text( "Възникна грешка!Моля опитайте пак!" );
				}				
			}
		});
		
	})
	
	$(document).keypress(function( e ){
		if( e.keyCode == 13 ){
			$("#login").trigger("click");
		};
	})
	
	$(document).on('click', "#logout", function(e){
		url = servicePart + "Users/Logout?userId="+userInfo.userId ;
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function( result ){
				setCookie('logged', '', -1);
				$(".rightMenu").empty();
				$(".rightMenu").append(
					'<li><a href="#" data-page="login">Вход</a></li>' +
					'<li><a href="#" data-page="registration">Регистрация</a></li>'
				)
				userInfo={};
				loadHTML("home");
			},
			error: function( error ){
				
			}
		});
	})

	
});