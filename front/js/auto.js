$(document).ready(function(){
	$(document).on('click', "#saveAuto", function(e){
		
		if($("#textareaB").val().length < 1 || $("#textareaA").val().length < 1)
		{
			$( "#dialog" ).dialog({resizable:false});
			$( "#dialog" ).text( "Не сте въвели нищо в полето за забележка!" );
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
		
		var data = {Circumstances:[]},
			data2 = {Circumstances:[]},
			url = servicePart + "Clients/AddAutoRequest";
		$(".vehicleA input").each(function(i, e){
			if($(e).attr("data-name")!="TrailerNumber"){
				if( $(e).val() == "" ||  $(e).val() == undefined){
					$( "#dialog" ).dialog({resizable:false});
					$( "#dialog" ).text( "Не сте въвели " + $(this).prev().text() );
					return false;
				}
			}
			if( $(e).attr("type") == "checkbox" ||  $(e).attr("type") == "file"){
				return false;
			}
			var key = $(e).attr('data-name');
			if( key != undefined ){
				data[key] = $(e).val();
			}
			
		});

		$(".vehicleB input").each(function(i, e){
			
			if( $(e).val() == "" ||  $(e).val() == undefined ){
				$( "#dialog" ).dialog({resizable:false});
				$( "#dialog" ).text( "Не сте въвели " + $(this).prev().text() );
				return false;
			}
			
			if( $(e).attr("type") == "checkbox" || $(e).attr("type") == "file"){
				return false;
			}
			var key = $(e).attr('data-name2');
			if( key != undefined ){
				data2[key] = $(e).val();
			}
			
		});

		$(".checkData span:first-child input[type='checkbox']").each(function(i, e){
			var key = $(e).parent().text();
			
			if( $(e).prop('checked') ){	
				data.Circumstances.push(key);
			}
			
		})

		$(".checkData span:last-child input[type='checkbox']").each(function(i, e){
			var key = $(e).parent().text();
			
			if( $(e).prop('checked') ){	
				data2.Circumstances.push(key);
			}
			
		})
    
		if(data.Circumstances.length==0 || data2.Circumstances.length==0 ){
			$( "#dialog" ).dialog({resizable:false});
				$( "#dialog" ).text( "Трябва да изберете поне една опция!" );
				return false;
			
		}
	
		data.PolicyNumber=$("input[data-name='PolicyNumber']").val();
		data2.PolicyNumber=$("input[data-name='PolicyNumber']").val();
		data.VisibleDamage=$("#textareaA").val();
		data2.VisibleDamage=$("#textareaB").val();
		data.AttachFile=base64Code;
		data2.AttachFile=base64Code;
		data.InsurerCompany=$("#company").val();
		 
		var newInsurerCompany=data.InsurerCompany;
		data.InsurerCompany=capitalizeFirstLetter(newInsurerCompany);
		
		newInsurerCompany=data2.InsurerCompany;
		data2.InsurerCompany=capitalizeFirstLetter(newInsurerCompany);
		
		data.Circumstances = data.Circumstances.join(",");
		data2.Circumstances = data2.Circumstances.join(",");
		
		data.IsGuilty=true;
		data2.IsGuilty=false;
		
		
		data = JSON.stringify(data);
		data2 = JSON.stringify(data2);

		$.ajax({
			url: url,
			method: "POST",
			headers:{SessionId: userInfo.sessionId},
			data: {data},
			success: function( result ){
			},
			error: function( error ){
			}
		});

		$.ajax({
			url: url,
			method: "POST",
			headers:{SessionId: userInfo.sessionId},
			data: {data2},
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
			$("#saveAuto").trigger("click");
		};
	})
});	