
var count = 3;
var h3 = document.querySelector('h3');
var countElement = document.querySelector("h3");

console.log(countElement);

function add1 (){
    count++;
    countElement.innerText = count + "Like(s)";
    console.log(count);
}