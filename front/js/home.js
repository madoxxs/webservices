$(document).ready(function(){
	$(document).on('click', "#contactUs", function(e){
		if(!ValidateEmail($("input[name='email']").val()))
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Въведете правилен имейл!" );
			return false;
		}
		
		if($("textarea[name='msg']").val().length <1)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Не сте въвели никакво съдържание!" );
			return false;
		}
		
		var to=$("input[name='email']").val();
		var body=$("textarea[name='msg']").val();
		var subject="Questions about the system";
		var url = servicePart + "Clients/SendMail?to="+to+"&subject="+subject+"&body="+body;
		
		$.ajax({
			url: url,
			success: function(result){
				$( "#dialog" ).dialog({resizable:false});
				$( "#dialog" ).text( "Вие успешно изпратихте вашето запитване!" );
				loadHTML("home");
			},
			error: function( error ){
				$( "#dialog" ).dialog({resizable:false});
				$( "#dialog" ).text( "Възникна грешка и запитването ви не можа да бъде изпратено!" );
			}
		});
		
	})
});