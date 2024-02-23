

var username = document.querySelector("#username");

var requestSpan = document.querySelector("#requests");
var connectionSpan = document.querySelector("#connections");

function edit() {
    username.innerText = "Juliet Doe"; 
}

function accept(id) {
    var element = document.querySelector(id);
    element.remove();
    requestSpan.innerText--;
    connectionSpan.innerText++;
}

function ignore(id) {
    var element = document.querySelector(id);
    element.remove();
    requestSpan.innerText--;
}

console.log("load page");