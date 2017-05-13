$(document).ready(function(){
	var attach="";
	if(userInfo.userId==1){
		var url = servicePart + "Clients/GetHealthDocuments";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				ensurance(result.Result, "health");
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetEstateDocuments";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				ensurance(result.Result, "estate");
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetAutoDocuments";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				ensurance(result.Result, "auto");
			},
			error: function( error ){
			}
		});
	}
	else if(userInfo.userId==2){
		var url = servicePart + "Clients/GetHealthDocuments?company=Levins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				ensurance(result.Result, "health");
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetEstateDocuments?company=Levins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				ensurance(result.Result, "estate");
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetAutoDocuments?company=Levins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				ensurance(result.Result, "auto");
			},
			error: function( error ){
			}
		});
	}
	else if(userInfo.userId==3){
		var url = servicePart + "Clients/GetHealthDocuments?company=Bulins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				ensurance(result.Result, "health");
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetEstateDocuments?company=Bulins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				ensurance(result.Result, "estate");
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetAutoDocuments?company=Bulins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				ensurance(result.Result, "auto");
			},
			error: function( error ){
			}
		});
	}
	else if(userInfo.userId==4){
		var url = servicePart + "Clients/GetHealthDocuments?company=Euroins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				ensurance(result.Result, "health");
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetEstateDocuments?company=Euroins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				ensurance(result.Result, "estate");
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetAutoDocuments?company=Euroins";
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				ensurance(result.Result, "auto");
			},
			error: function( error ){
			}
		});
	}
	else if(userInfo.userId!=1 && userInfo.userId!=2 && userInfo.userId!=3 && userInfo.userId!=4){
		var url = servicePart + "Clients/GetHealthDocuments?fullName="+ userInfo.firstName+" "+ userInfo.lastName;
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				ensurance(result.Result, "health");
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetEstateDocuments?fullName="+ userInfo.firstName+" "+ userInfo.lastName;
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				ensurance(result.Result, "estate");
			},
			error: function( error ){
			}
		});
		
		url = servicePart + "Clients/GetAutoDocuments?fullName="+ userInfo.firstName+" "+ userInfo.lastName;
		
		$.ajax({
			url: url,
			headers:{SessionId: userInfo.sessionId},
			success: function(result){
				ensurance(result.Result, "auto");
			},
			error: function( error ){
			}
		});
	}
	function ensurance(obj, type){
		
		switch(type){
			case "health":
				build(obj, "health");				
				break;
			case "auto":
				build(obj, "auto");
				break;
			default:
				build(obj, "estate");
				break;
		}
		
	}
	
	function build(obj, a){
		var h = document.createElement("div");
			h.className = "expand";
		obj.forEach(function(v, i){
			var div = document.createElement("div");
			var span = document.createElement("span");
			( a == "auto" ) ? span.textContent = "Име: " + v.LeaderFullName : span.textContent = "Име: " + v.FullName
			div.appendChild(span);
			if(userInfo.userId != 2 && userInfo.userId != 3 && userInfo.userId != 4){
				var span = document.createElement("span");
				( a == "auto" ) ? span.textContent = "Създадено на: " + v.CreateDate.split("T")[0] + "/" + v.CreateDate.split("T")[1] : span.textContent = "Създадено на: " + v.CreatedAt.split("T")[0] + "/" + v.CreatedAt.split("T")[1]
				div.appendChild(span);
			}
			else{
				var span = document.createElement("span");
				span.textContent = v.Id;
				div.appendChild(span);
			}
			var span = document.createElement("span");
			( a == "auto" )? span.textContent = "Застраховател: " + v.InsurerCompany : span.textContent = "Застраховател: " + v.Company
			div.appendChild(span);
			div.className = "unit";					
			if( userInfo.userId == 2 || userInfo.userId == 3 || userInfo.userId == 4 ){
				var button = document.createElement("button");
				button.textContent = "Преглед";
				button.className="preview"+a;
				div.appendChild(button);
				var button = document.createElement("button");
				button.textContent = "Изпрати";
				button.className="sendDocument";
				div.appendChild(button);
			}else if( i == 0 && a != "auto" && userInfo.userId != 1){
				
				var button = document.createElement("button");
				button.textContent = "Преглед";
				button.className="preview"+a;
				div.appendChild(button);
				var button = document.createElement("button");
				button.textContent = "Изпрати";
				button.className="sendDocument";
				div.appendChild(button);
				
			}else if(i==0 && a== "auto" && userInfo.userId != 1){
				var button = document.createElement("button");
				button.textContent = "Преглед";
				button.className="preview"+a;
				div.appendChild(button);
				var button = document.createElement("button");
				button.textContent = "Изпрати";
				button.className="sendDocument";
				div.appendChild(button);
			}
			var input = document.createElement("input");
			input.className = "hidden";
			input.value = v.Id;
			div.appendChild(input);
			
			h.appendChild(div)
			
		});
		
		document.getElementsByClassName(a)[0].appendChild(h);
	}
	
	var elem = document.getElementsByTagName("label");
	for( var ii = 0; ii < elem.length; ii++){
		elem[ii].addEventListener("click", function(e){
			myMove(e);
		});
	}
	
	function myMove(elem) {
	  elem = elem.target.nextSibling.nextSibling;
	  if( elem == null ) return false;
	  elem.style.display = "block";
	  
	  var o = "";
	  
	  if( document.getElementById("open") != null ){  
		o = document.getElementById("open").offsetHeight;
	  }

	  var sh = elem.children.length * 26,
	   eh = 0,
	   t = "",
	   id = "";

	  if( elem.attributes["id"] != undefined ){
	   id = setInterval( frameD, 10 );
	   elem.removeAttribute("id");
	   return false; 
	  }

	  var open = document.getElementById("open");

	  if( open == null ){
	   sh = 0,
	   eh = elem.children.length * 26,
	   t = true;
	   id = setInterval( frame, 10 );
	   elem.id = "open";
	  }else{
	   document.getElementById("open").removeAttribute("id")
	   sh = elem.children.length * 26,
	   eh = 0,
	   t = false;
	   id = setInterval( frame, 10 );
	   elem.id = "open";
	  }

	function frameD() {
		eh = 0;
		if (o <= eh) {
			clearInterval(id);
			elem.style.height = '0px';
		} else {
			o -= 5;
			elem.style.height = o + 'px';             
		}

	}

		 function frame() {

			 if( t == true ){
			  if (sh >= eh) {
				  clearInterval(id);
			  } else {
			   sh += 5;
			   elem.style.height = sh + 'px';              
			  }
			  
			 }else{

			  if (sh <= eh) {
				  open.style.height = '0px'; 
				  clearInterval(id);
				  sh = 0,
				 eh = elem.children.length * 26,
				 t = true;
				 id = setInterval( frame, 10 );
			  } else {
			   sh -= 5;
			   open.style.height = sh + 'px';             
			  }

			 }
		 }
	 }
	 
	 $(".preview button").click(function(e){
		  $(".preview").hide();
		  $(".contentP").empty();	
	 });
	 
	 $(".health").on("click", ".previewhealth", function(e){
		$(".contentP").empty();

		if(userInfo.userId !=1 && userInfo.userId !=2 && userInfo.userId !=3 && userInfo.userId !=4){

			var url = servicePart + "Clients/GetHealthDocumentByFullName?fullName="+ userInfo.firstName+" "+ userInfo.lastName;
			
			$.ajax({
				url: url,
				headers:{SessionId: userInfo.sessionId},
				success: function(result){
					var a = result.Result;
					for(var key in a){
						if( key != "Id" && key != "CreatedAt" && key != "AttachFile" && key != "ModifiedAt"){
							$(".contentP").append(
								"<div class='inputRowWrapper'>" +
									"<label>"+ translate[key] +": </label>" +
									"<span>"+ a[key] +"</span>" +
								"</div>"
							);
						}
					}
					attach="images/Health/"+a.FullName.split(' ')[0]+a.DocumentNumber+".jpg";
					$(".contentP").append(
						"<div class='inputRowWrapper'>" +
							"<label>Прикачен амбулаторен лист: </label>" +
							
							"<button id='prevPic' data-attach='"+ attach +"'>Изображение</button>"+
						"</div>"
					);
				},
				error: function( error ){
				}
			});

		}
		else if(userInfo.userId<5){
			
			var url = servicePart + "Clients/GetHealthDocumentById?Id="+e.target.nextSibling.nextSibling.value;
			
			$.ajax({
				url: url,
				headers:{SessionId: userInfo.sessionId},
				success: function(result){
					var a = result.Result;
					for(var key in a){
						if( key != "Id" && key != "CreatedAt" && key != "AttachFile" && key != "ModifiedAt"){
							$(".contentP").append(
								"<div class='inputRowWrapper'>" +
									"<label>"+ translate[key] +": </label>" +
									"<span>"+ a[key] +"</span>" +
								"</div>"
							);
						}
					}
					attach="images/Health/"+a.FullName.split(' ')[0]+a.DocumentNumber+".jpg";
					$(".contentP").append(
						"<div class='inputRowWrapper'>" +
							"<label>Прикачен амбулаторен лист: </label>" +
							
							"<button id='prevPic' data-attach='"+ attach +"'>Изображение</button>"+
						"</div>"
					);
				},
				error: function( error ){
				}
			});
		}
		
		$(".preview").show();
	 });
	 
	$(document).on("click", "#prevPic", function(e){
		$(".contentP").append(
			"<img src='"+ e.target.attributes["data-attach"].value + "' />"
		);
	});
	 
	$(".estate").on("click", ".previewestate", function(e){
		$(".contentP").empty();
		if(userInfo.userId !=1 && userInfo.userId !=2 && userInfo.userId !=3 && userInfo.userId !=4){

			var url = servicePart + "Clients/GetEstateDocumentByFullName?fullName="+ userInfo.firstName+" "+ userInfo.lastName;
			var attach="";
			
			$.ajax({
				url: url,
				headers:{SessionId: userInfo.sessionId},
				success: function(result){
					var a = result.Result;
					for(var key in a){
						if( key != "Id" && key != "CreatedAt" && key != "AttachFile" && key != "ModifiedAt"){
							$(".contentP").append(
								"<div class='inputRowWrapper'>" +
									"<label>"+ translate[key] +": </label>" +
									"<span>"+ a[key] +"</span>" +
								"</div>"
							);
						}
					}
					attach="images/Estate/"+a.FullName.split(' ')[0] + "_" +a.Area + "_"+a.InsuranceAmount+".jpg";
					$(".contentP").append(
						"<div class='inputRowWrapper'>" +
							"<label>Прикачена снимка на имота: </label>" +
							
							"<button id='prevPic' data-attach='"+ attach + "'>Изображение</button>"+
						"</div>"
					);
				},
				error: function( error ){
				}
			});
		}
		else if(userInfo.userId<5){
			var url = servicePart + "Clients/GetEstateDocumentById?Id="+e.target.nextSibling.nextSibling.value;
			var attach="";
			
			$.ajax({
				url: url,
				headers:{SessionId: userInfo.sessionId},
				success: function(result){
					var a = result.Result;
					for(var key in a){
						if( key != "Id" && key != "CreatedAt" && key != "AttachFile" && key != "ModifiedAt"){
							$(".contentP").append(
								"<div class='inputRowWrapper'>" +
									"<label>"+ translate[key] +": </label>" +
									"<span>"+ a[key] +"</span>" +
								"</div>"
							);
						}
					}
					attach="images/Estate/"+a.FullName.split(' ')[0] + "_" +a.Area + "_"+a.InsuranceAmount+".jpg";
					$(".contentP").append(
						"<div class='inputRowWrapper'>" +
							"<label>Прикачена снимка на имота: </label>" +
							
							"<button id='prevPic' data-attach='"+ attach +"'>Изображение</button>"+
						"</div>"
					);
				},
				error: function( error ){
				}
			});
			
		}
		$(".preview").show();
	 });
	 $(".previewauto").unbind("click");
	 $(".auto").on("click", ".previewauto", function(e){		 
		getAutoData(e);
	 });
	 
	 
	 
	$(".contentP").on("click", "#nextAuto", function(){

		$(".preview").hide();
		$(".contentP").empty();
		$(".preview").show();

		a = auto.Result[1];
			$(".contentP").append(
				"<div class='headerContainerDocument'>" +
					"<span>Превозно средство Б</span>" +
				"</div>"
			);
			for(var key in a){
				if( key != "Id" && key != "CreateDate" && key != "AttachFile" && key != "Circumstances" && key != "IsGuilty" && key != "ValidTo" && key != "ValidFrom" && key != "LeaderBornDate" && key != "LeaderCertificateValidTo"){
					$(".contentP").append(
						"<div class='inputRowWrapper'>" +
							"<label>"+ translate[key] +": </label>" +
							"<span>"+ a[key] +"</span>" +
						"</div>"
					);
				}
				else if(key == "ValidTo" || key == "ValidFrom" || key == "LeaderBornDate" || key == "LeaderCertificateValidTo"){
							$(".contentP").append(
								"<div class='inputRowWrapper'>" +
									"<label>"+ translate[key] +": </label>" +
									"<span>"+ a[key].split("T")[0] +"</span>" +
								"</div>"
							);
				}
			}
			attach="images/Auto/"+a.LeaderFullName.split(' ')[0] +a.PolicyNumber+".jpg";
			$(".contentP").append(
				"<div class='inputRowWrapper'>" +
					"<label>Прикачена снимка на ПТП: </label>" +
					
					"<button id='prevPic' data-attach='"+ attach +"'>Изображение</button>"+
				"</div>"
			);
			
			url = servicePart + "Clients/GetCircumstancesById?list="+ a.Circumstances;
		
			$.ajax({
				url: url,
				headers:{SessionId: userInfo.sessionId},
				success: function(result){
					var a = result.Result;
					$(".contentP").append(
						"<div class='headerContainerDocument'>" +
							"<span>Обстоятелства:</span>" +
						"</div>"
					);
					for(var key in a){
						$(".contentP").append(
							"<div class='inputRowWrapper'>" +
								"<span> -"+ a[key] +"</span>" +
							"</div>"
						);
								
					}
					
					$(".contentP").append(
						"<div class='inputRowWrapper'>" +
							"<button id='prevAuto'>Предишна страница</button>"+
						"</div>"
					);
				},
				error: function( error ){
				}
			});

	});
	
	
	$(".contentP").on("click", "#prevAuto", function(){
		$(".preview").hide();
		$(".contentP").empty();
		$(".preview").show();
		
		
		
		a = auto.Result[0];
			$(".contentP").append(
				"<div class='headerContainerDocument'>" +
					"<span>Превозно средство А</span>" +
				"</div>"
			);
			for(var key in a){
				if( key != "Id" && key != "CreateDate" && key != "AttachFile" && key != "Circumstances" && key != "IsGuilty" && key != "ValidTo" && key != "ValidFrom" && key != "LeaderBornDate" && key != "LeaderCertificateValidTo"){
					$(".contentP").append(
						"<div class='inputRowWrapper'>" +
							"<label>"+ translate[key] +": </label>" +
							"<span>"+ a[key] +"</span>" +
						"</div>"
					);
				}
				else if(key == "ValidTo" || key == "ValidFrom" || key == "LeaderBornDate" || key == "LeaderCertificateValidTo"){
							$(".contentP").append(
								"<div class='inputRowWrapper'>" +
									"<label>"+ translate[key] +": </label>" +
									"<span>"+ a[key].split("T")[0] +"</span>" +
								"</div>"
							);
				}
			}
			attach="images/Auto/"+a.LeaderFullName.split(' ')[0] +a.PolicyNumber+".jpg";
			$(".contentP").append(
				"<div class='inputRowWrapper'>" +
					"<label>Прикачена снимка на ПТП: </label>" +
					
					"<button id='prevPic' data-attach='"+ attach +"'>Изображение</button>"+
				"</div>"
			);
			
			url = servicePart + "Clients/GetCircumstancesById?list="+ a.Circumstances;
	
			$.ajax({
				url: url,
				headers:{SessionId: userInfo.sessionId},
				success: function(result){
					var a = result.Result;
					$(".contentP").append(
						"<div class='headerContainerDocument'>" +
							"<span>Обстоятелства:</span>" +
						"</div>"
					);
					for(var key in a){
						$(".contentP").append(
							"<div class='inputRowWrapper'>" +
								"<span> -"+ a[key] +"</span>" +
							"</div>"
						 );
								
					}
					
					$(".contentP").append(
						"<div class='inputRowWrapper'>" +
							"<button id='nextAuto'>Следваща страница</button>"+
						"</div>"
					);
				},
				error: function( error ){
				}
			});
		
	});
	
	
	function getAutoData(e){
		
		$(".contentP").empty();
			
			var url = servicePart + "Clients/GetAutoPolicyById?id="+e.target.nextSibling.nextSibling.value;
			var attach="";
			
			$.ajax({
				url: url,
				headers:{SessionId: userInfo.sessionId},
				success: function(result){
					auto = result;
					var a = result.Result[0];
					$(".contentP").append(
						"<div class='headerContainerDocument'>" +
							"<span>Превозно средство А</span>" +
						"</div>"
					);
					for(var key in a){
						if( key != "Id" && key != "CreateDate" && key != "AttachFile" && key != "Circumstances" && key != "IsGuilty" && key != "ValidTo" && key != "ValidFrom" && key != "LeaderBornDate" && key != "LeaderCertificateValidTo"){
							$(".contentP").append(
								"<div class='inputRowWrapper'>" +
									"<label>"+ translate[key] +": </label>" +
									"<span>"+ a[key] +"</span>" +
								"</div>"
							);
						}
						else if(key == "ValidTo" || key == "ValidFrom" || key == "LeaderBornDate" || key == "LeaderCertificateValidTo"){
							$(".contentP").append(
								"<div class='inputRowWrapper'>" +
									"<label>"+ translate[key] +": </label>" +
									"<span>"+ a[key].split("T")[0] +"</span>" +
								"</div>"
							);
						}
					}
					attach="images/Auto/"+a.LeaderFullName.split(' ')[0] +a.PolicyNumber+".jpg";
					$(".contentP").append(
						"<div class='inputRowWrapper'>" +
							"<label>Прикачена снимка на ПТП: </label>" +
							
							"<button id='prevPic' data-attach='"+ attach +"'>Изображение</button>"+
						"</div>"
					);
					
					url = servicePart + "Clients/GetCircumstancesById?list="+ a.Circumstances;
			
					$.ajax({
						url: url,
						headers:{SessionId: userInfo.sessionId},
						success: function(result){
							var a = result.Result;
							$(".contentP").append(
								"<div class='headerContainerDocument'>" +
									"<span>Обстоятелства:</span>" +
								"</div>"
							);
							for(var key in a){
								$(".contentP").append(
									"<div class='inputRowWrapper'>" +
										"<span> -"+ a[key] +"</span>" +
									"</div>"
							     );
										
							}
							
							$(".contentP").append(
								"<div class='inputRowWrapper'>" +
									"<button id='nextAuto'>Следваща страница</button>"+
								"</div>"
							);
							
						},
						error: function( error ){
						}
					});
					
					
					
				},
				error: function( error ){
				}
			});

		
		$(".preview").show();
		
	}
	 
	
		$(".health, .auto, .estate").on('click', ".sendDocument", function(e){
			if(userInfo.userId > 4){
				var body="Изпратено искане за одобрение с номер на искането "+e.target.nextSibling.value;
				var url = servicePart + "Clients/SendMail?to=simeon.prisadov93@gmail.com&subject=одобрение на искане&body="+body;
				
				$.ajax({
					url: url,
					success: function(result){
						$( "#dialog" ).dialog({resizable:false});
						$( "#dialog" ).text( "Вие успешно изпратихте вашето искане за удобрение!" );
						loadHTML("documents");
						
					},
					error: function( error ){
						$( "#dialog" ).dialog({resizable:false});
						$( "#dialog" ).text( "Възникна грешка и искането ви не можа да бъде изпратено!" );
					}
				});
			}
			else if(userInfo.userId < 5){
				var body="Вашето искане с номер "+e.target.nextSibling.value+" е удобрено!";
				var url = servicePart + "Clients/SendMail?to=simeon.prisadov93@gmail.com&subject=одобрено&body="+body;
				
				$.ajax({
					url: url,
					success: function(result){
						$( "#dialog" ).dialog({resizable:false});
						$( "#dialog" ).text( "Вие успешно върнахте имейл на ищеца!" );
						loadHTML("documents");
						
					},
					error: function( error ){
						$( "#dialog" ).dialog({resizable:false});
						$( "#dialog" ).text( "Възникна грешка и имейла ви не можа да бъде изпратен!" );
					}
				});
			}
		});
		
	
	 
});