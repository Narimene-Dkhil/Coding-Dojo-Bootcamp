// Assignment: JavaScript Hoisting
// Objectives:
// Practice reading JavaScript the same way as the interpreter reads it.
// Rewrite the code the way it would be seen by the interpreter and predict the output. An example is shown here:

// // GIVEN
console.log(example);
var example = "I'm the example!";

// AFTER HOISTING BY THE INTERPRETER

// var example;
// console.log(example); // logs undefined
// example = "I'm the example!";



1
console.log(hello);                                   
var hello = 'world';                                 
//var hello;
//console.log(hello);  logs undefined (same as example above), the variable is not defined before console.log 
// hello = 'world'; 


2
var needle = 'haystack';
test();
function test(){
    var needle = 'magnet';
    console.log(needle);
}

// function test(){
//     var needle; 
//     needle = 'magnet'; 
//     console.log(needle);
// }
// var needle; 
// needle = 'haystack'; 
// test();

// logs magnet , This is because the test function defines a new variable needle within its scope, 
//which shadows the outer variable needle. So, when you log needle inside the test function, 
//it refers to the local variable needle defined within that function, not the outer one.



3
var brendan = 'super cool';
function print(){
    brendan = 'only okay';
    console.log(brendan);
}
console.log(brendan);


// function print(){
//     brendan = 'only okay'; // This will affect the global brendan variable when the function is called
//     console.log(brendan);
// }
// var brendan; 
// brendan = 'super cool'; 
// console.log(brendan);

// logs super cool, because the print() function is never invoked, 
//the reassignment of brendan inside the function does not occur.


4
var food = 'chicken';
console.log(food);
eat();
function eat(){
    food = 'half-chicken';
    console.log(food);
    var food = 'gone';
}

// function eat(){
//     var food; 
//     food = 'half-chicken';
//     console.log(food);
//     food = 'gone'; 
// }
// var food; 
// food = 'chicken'; 
// console.log(food);
// eat();

// logs chicken half-chicken , The global food variable remains 'half-chicken' after the eat() function is called.



5
mean();
console.log(food);
var mean = function() {
    food = "chicken";
    console.log(food);
    var food = "fish";
    console.log(food);
}
console.log(food);


// var mean; 
// mean(); // mean is undefined, TypeError
// console.log(food); // food is not defined, ReferenceError
// mean = function() {
//     var food; 
//     food = "chicken"; 
//     console.log(food);
//     food = "fish"; 
//     console.log(food);
// }
// console.log(food); // food is not defined in the global scope, so this will throw a ReferenceError

// logs TypeError , The food variable inside the mean() function is not accessible outside the mean() function. 


6
console.log(genre);
var genre = "disco";
rewind();
function rewind() {
    genre = "rock";
    console.log(genre);
    var genre = "r&b";
    console.log(genre);
}
console.log(genre);

// function rewind() {
//     var genre; 
//     genre = "rock"; 
//     console.log(genre);
//     genre = "r&b"; 
//     console.log(genre);
// }
// var genre; 
// console.log(genre);
// genre = "disco"; 
// rewind();
// console.log(genre); 

// logs undefined rock r&b disco , The global genre variable remains "disco" after the rewind() function is called 


7
dojo = "san jose";
console.log(dojo);
learn();
function learn() {
    dojo = "seattle";
    console.log(dojo);
    var dojo = "burbank";
    console.log(dojo);
}
console.log(dojo);


// function learn() {
//     var dojo; 
//     dojo = "seattle"; 
//     console.log(dojo);
//     dojo = "burbank"; 
//     console.log(dojo);
// }
// dojo = "san jose"; 
// console.log(dojo);
// learn();
// console.log(dojo); // The global dojo variable remains "san jose" after the learn() function is called

//logs san jose seattle burbank san jose 



8 - 
// Bonus ES6: const 

console.log(makeDojo("Chicago", 65));
console.log(makeDojo("Berkeley", 0));
function makeDojo(name, students){
    const dojo = {};
    dojo.name = name;
    dojo.students = students;
    if(dojo.students > 50){
        dojo.hiring = true;
    }
    else if(dojo.students <= 0){
        dojo = "closed for now";
    }
    return dojo;
}

// function makeDojo(name, students){
//     const dojo = {}; 
//     dojo.name = name; 
//     dojo.students = students; 
//     if(dojo.students > 50){
//         dojo.hiring = true; 
//     }
//     else if(dojo.students <= 0){
//         dojo = "closed for now";
//     }
//     return dojo; 
// } 
// console.log(makeDojo("Chicago", 65));
// console.log(makeDojo("Berkeley", 0));

// logs {name: 'Chicago', students: 65, hiring: true}    TypeError: Assignment to constant variable.
