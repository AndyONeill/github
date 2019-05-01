import *  as ajaxHandling from './ajaxHandling.js'

let gitHubUrl ="https://api.github.com/users/hadley/orgs";

$(document).ready(function() { 
    $('#getNewURL').on('submit', function(e) { 
        e.preventDefault();  // prevent form from submitting
        gitHubUrl = $('#urlInput').val();
        ajaxHandling.ajaxRequest(ajaxHandling.ajaxOK, ajaxHandling.ajaxFail, gitHubUrl);
    });
});

$(document).ready(function(){
    jQuery.support.cors = true;
    ajaxHandling.ajaxRequest(ajaxHandling.ajaxOK, ajaxHandling.ajaxFail,  gitHubUrl);
});
