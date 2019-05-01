import *  as ajaxHandling from './ajaxHandling.js'
export {CorrectURLShouldGet10, BadURLShouldFail, dummy}

function dummy () {
    };

function CorrectURLShouldGet10(){
    return ajaxHandling.ajaxRequest(dummy,dummy, "https://api.github.com/users/hadley/orgs");
}
function BadURLShouldFail(func){
    return ajaxHandling.ajaxRequest(dummy,func, "https://api.github.com/users/hadley/o");
}
