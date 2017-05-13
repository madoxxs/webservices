$(document).ready(function(){
	
	var p = getCookie("page") || "home";
	
	loadHTML(p);
	
	$('.nav, .mobileNav').on("click", ".leftMenu li a, .rightMenu li a", function( e ){

		var page = e.target.attributes['data-page'].value;
		
		if( ( userInfo.sessionId == "" || userInfo.sessionId == undefined ) && page != "login" && page != "registration" && page!="home"){
			page = "login";
		}
		
		loadHTML( page );
	});
	
	var logged = checkCookie('logged');
	
	if( logged ){
		
		var data = getCookie('logged');
		data = data.split("_");
		
		data.forEach(function(v, i){
			if( i == data.length - 1 ){
				return false;
			}
			var x = v.split("=");
			userInfo[x[0]] = x[1];
		})
		
		$(".rightMenu").empty();

		$(".rightMenu").append("<li><a href='#' id='user' data-page='userInfo'>"+ userInfo.userName +"</a></li>")
		$(".rightMenu").append("<li><a href='#' id='logout'  data-page='home'>Logout</a><li>")
		$(".rightMenu li:last-child").remove();
	}
	
	$('#calendar').calendar({
		startYear: "2017",
	});
	
	var d = new Date();
	var n = d.getMonth() + 1;
	var day = d.getDate();
	
	$(".month-container:nth-child(" + n + ")").css({
		display:"block"
	});
	
	$(".month-container:nth-child(5) .day").each(function(i, v){
		if( $(v).text() == day ){
			$(v).css({ 
				"background-color":"#083747",
				"border-radius":"5px",
				"color":"#fff"
			}) 
		}   
	});	
	
	$(".nextMonth").click(function( e ){
				
		if( n == 12 ){
			return false;
		}
		
		$(".month-container:nth-child("+ n +")").css({
			display:"none"
		});
		
		n++;
		$(".month-container:nth-child("+ n +")").css({
			display:"block"
		});
	});
	
	$(".previous").click(function( e ){
				
		if( n == 1 ){
			return false;
		}
		
		$(".month-container:nth-child("+ n +")").css({
			display:"none"
		});
		
		n--;
		$(".month-container:nth-child("+ n +")").css({
			display:"block"
		});
	});
	
	$(".openMenu").click(function(e){					
		$(".mobileNav").css({
			"left":"0px"
		});
	});
	
	$(".close").click(function(e){
		$(".mobileNav").css({
			"left":"-300px"
		});
	});
	
});

function loadHTML( page ){
	setCookie("page", page, 1);
	var url = path + page + ".html";
	
	if(page=="health"){
			$(".wrapper").css("background-image","url('images/background/health.jpg')");
		}
	else if(page=="estate"){
			$(".wrapper").css("background-image","url('images/background/estate.jpg')");
		}
	else if(page=="documents"){
			$(".wrapper").css("background-image","url('images/background/document.png')");
		}
		else{
			$(".wrapper").css("background-image","none");
		}
	$.ajax({
		url: url,
		success: function(result){
			$(".wrapper").empty();
			$(".wrapper").append(result);
		},
		error: function( error ){
			console.log(error);
		}
	});
		
}

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays*24*60*60*1000));
    var expires = "expires="+ d.toUTCString();
    document.cookie = cname + "=" + cvalue + "; " + expires;
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for(var i = 0; i <ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0)==' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length,c.length);
        }
    }
    return "";
}

function checkCookie() {
    var username=getCookie("logged");
    if (username!="") {
        return true;
    }else{
		return false;
	}
}

function ValidateEmail(mail)   
{  
 if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail))  
  {  
    return (true)  
  }  
    alert("You have entered an invalid email address!")  
    return (false)  
}

var handleFileSelect = function(evt) {

    var files = evt.target.files;
    var file = files[0];
	
    if (files && file) {
        var reader = new FileReader();

        reader.onload = function(readerEvt) {
			
            var binaryString = readerEvt.target.result;
			base64Code = btoa(binaryString);
        };

        reader.readAsBinaryString(file);
    }
};

function TryParseInt(str,defaultValue) {
     var retValue = defaultValue;
     if(str !== null) {
         if(str.length > 0) {
             if (!isNaN(str)) {
                 retValue = parseInt(str);
             }
         }
     }
     return retValue;
}

function capitalizeFirstLetter(str) {
    return str.substr(0, 1).toUpperCase() + str.substr(1);
}