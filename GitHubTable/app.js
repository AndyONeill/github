var gitHubUrl ="https://api.github.com/users/hadley/orgs";

$(document).ready(function() { 
    $('#getNewURL').on('submit', function(e) { 
        e.preventDefault();  //prevent form from submitting
        gitHubUrl = $('#urlInput').val();
        AjaxCall();
    });
});

$(document).ready(function(){
	AjaxCall();
});

function AjaxCall(){
    jQuery.support.cors = true;
    $.ajax({
        type: "GET",
        url: gitHubUrl,
        contentType: "application/json; charset=utf-8", 
        dataType: 'json',
        success: function (response) {
            $("#repoTable tbody").empty();
            $.each(response, function(i,r){ 
                function WrapWithCell(content){
                    return "<td>" + content + "</td>"
                };   
                
                function WrapWithAnchor(url){
                    return "<a href='" + url + "'> <div class='fullSize'>" + url + "</div></a>"
                };

                $('#repoTable').append(
                        "<tr>"
                        + WrapWithCell(r.login)
                        + WrapWithCell(r.id)
                        + WrapWithCell(WrapWithAnchor(r.repos_url))
                        + WrapWithCell(WrapWithAnchor(r.issues_url))
                        +"</tr>" )
                    })
            },
        error: function (jqXHR, exception) {
            $("#repoTable tbody").empty();
            console.log(jqXHR);
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connected.\n Please check Network connection or try later.';
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
})};
