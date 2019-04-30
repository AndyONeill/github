$(document).ready(function(){
    jQuery.support.cors = true;

$.ajax({
    type: "GET",
    url: "https://api.github.com/users/hadley/orgs",
    data: "{}",
    contentType: "application/json; charset=utf-8", 
    dataType: 'json',
    success: function (response) {
		$.each(response, function(i,r){ 
            console.log(r.login);
            $('#repoTable').append(
                     "<tr>"
                    +"<td>"+r.login+"</td>"
                    +"<td>"+r.id+"</td>"
                    +"<td><a href='"+r.repos_url+"'> <div class='fullSize'>"+r.repos_url+"</div></a></td>"
                    +"<td><a href='"+r.issues_url+"'> <div class='fullSize'>"+r.issues_url+"</div></a></td>"
                    +"</tr>" )
                })
        },
    error: function (jqXHR, exception) {
        console.log(jqXHR);
        var msg = '';
        if (jqXHR.status === 0) {
            msg = 'Not connect.\n Verify Network.';
        } else if (jqXHR.status == 404) {
            msg = 'Requested page not found. [404]';
        } else if (jqXHR.status == 500) {
            msg = 'Internal Server Error [500].';
        } else if (exception === 'parsererror') {
            msg = 'Requested JSON parse failed.';
        } else if (exception === 'timeout') {
            msg = 'Time out error.';
        } else if (exception === 'abort') {
            msg = 'Ajax request aborted.';
        } else {
            msg = 'Uncaught Error.\n' + jqXHR.responseText;
        }
        alert(msg);
    }	
	
    });
});