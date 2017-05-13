$(document).ready(function(){
	if(userInfo.userId==1){
		var url = servicePart + "Clients/AllDocuments";
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				var allDocument=result.Result;
				var all = document.getElementById("1");
			    all.style.width ="50%";
				all.textContent = allDocument+"  регистрирани авариини ситуации";
			},
			error: function( error ){
			}
		});
		
		var url = servicePart + "Clients/GetHealthDocumentsCount";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				
				var health=document.getElementById("3");
				health.style.width = result.Result+'%';
				health.textContent = (result.Result*2).toFixed(2)+'%';
				
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetEstateDocumentsCount";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				var health=document.getElementById("4");
				health.style.width = result.Result+'%';
				health.textContent = (result.Result*2).toFixed(2)+'%';
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetAutoDocumentsCount";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				var health=document.getElementById("2");
				health.style.width = result.Result+'%';
				health.textContent = (result.Result*2).toFixed(2)+'%';
			},
			error: function( error ){
			}
		});
	}
	else if(userInfo.userId==2){
		var url = servicePart + "Clients/AllDocuments?company=Levins";
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				var allDocument=result.Result;
				var all = document.getElementById("1");
			    all.style.width ="50%";
				all.textContent = allDocument+"  регистрирани авариини ситуации";
			},
			error: function( error ){
			}
		});
		
		var url = servicePart + "Clients/GetHealthDocumentsCount?company=Levins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				
				var health=document.getElementById("3");
				health.style.width = result.Result+'%';
				health.textContent = (result.Result*2).toFixed(2)+'%';
				
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetEstateDocumentsCount?company=Levins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				var health=document.getElementById("4");
				health.style.width = result.Result+'%';
				health.textContent = (result.Result*2).toFixed(2)+'%';
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetAutoDocumentsCount?company=Levins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				var health=document.getElementById("2");
				health.style.width = result.Result+'%';
				health.textContent = (result.Result*2).toFixed(2)+'%';
			},
			error: function( error ){
			}
		});
	}
	else if(userInfo.userId==3){
		var url = servicePart + "Clients/AllDocuments?company=Bulins";
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				var allDocument=result.Result;
				var all = document.getElementById("1");
			    all.style.width ="50%";
				all.textContent = allDocument+"  регистрирани авариини ситуации";
			},
			error: function( error ){
			}
		});
		
		var url = servicePart + "Clients/GetHealthDocumentsCount?company=Bulins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				
				var health=document.getElementById("3");
				health.style.width = result.Result+'%';
				health.textContent = (result.Result*2).toFixed(2)+'%';
				
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetEstateDocumentsCount?company=Bulins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				var health=document.getElementById("4");
				health.style.width = result.Result+'%';
				health.textContent = (result.Result*2).toFixed(2)+'%';
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetAutoDocumentsCount?company=Bulins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				var health=document.getElementById("2");
				health.style.width = result.Result+'%';
				health.textContent = (result.Result*2).toFixed(2)+'%';
			},
			error: function( error ){
			}
		});
	}
	else if(userInfo.userId==4){
		var url = servicePart + "Clients/AllDocuments?company=Euroins";
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				var allDocument=result.Result;
				var all = document.getElementById("1");
			    all.style.width ="50%";
				all.textContent = allDocument+"  регистрирани авариини ситуации";
			},
			error: function( error ){
			}
		});
		
		var url = servicePart + "Clients/GetHealthDocumentsCount?company=Euroins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				
				var health=document.getElementById("3");
				health.style.width = result.Result+'%';
				health.textContent = (result.Result*2).toFixed(2)+'%';
				
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetEstateDocumentsCount?company=Euroins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				var health=document.getElementById("4");
				health.style.width = result.Result+'%';
				health.textContent = (result.Result*2).toFixed(2)+'%';
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetAutoDocumentsCount?company=Euroins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				var health=document.getElementById("2");
				health.style.width = result.Result+'%';
				health.textContent = (result.Result*2).toFixed(2)+'%';
			},
			error: function( error ){
			}
		});
	}
	else{
		var url = servicePart + "Clients/AllDocuments?fullName="+ userInfo.firstName+" "+ userInfo.lastName;
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				var allDocument=result.Result;
				var all = document.getElementById("1");
			    all.style.width ="50%";
				all.textContent = allDocument+"  регистрирани авариини ситуации";
			},
			error: function( error ){
			}
		});
		
		var url = servicePart + "Clients/GetHealthDocumentsCount?fullName="+ userInfo.firstName+" "+ userInfo.lastName;
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				
				var health=document.getElementById("3");
				health.style.width = result.Result+'%';
				health.textContent = (result.Result*2).toFixed(2)+'%';
				
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetEstateDocumentsCount?fullName="+ userInfo.firstName+" "+ userInfo.lastName;
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				var health=document.getElementById("4");
				health.style.width = result.Result+'%';
				health.textContent = (result.Result*2).toFixed(2)+'%';
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetAutoDocumentsCount?fullName="+ userInfo.firstName+" "+ userInfo.lastName;
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				var health=document.getElementById("2");
				health.style.width = result.Result+'%';
				health.textContent = (result.Result*2).toFixed(2)+'%';
			},
			error: function( error ){
			}
		});
	}
	var url = servicePart + "Clients/GetGuiltyDriverList";
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				var under=document.getElementById("5");
				under.style.width = 50/(result.Result[0]/(result.Result.length-1))+'%';
				under.textContent = (50/(result.Result[0]/(result.Result.length-1))*2).toFixed(2)+'%';
				var up=document.getElementById("6");
				up.style.width = 50-(50/(result.Result[0]/(result.Result.length-1)))+'%';
				up.textContent = (100-(50/(result.Result[0]/(result.Result.length-1))*2)).toFixed(2)+'%';
			},
			error: function( error ){
			}
		});
	
	
});