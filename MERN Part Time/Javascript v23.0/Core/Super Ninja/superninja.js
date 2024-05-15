
class Ninja {
    constructor(name) {
        this.name = name;
        this.health=90;
        this.speed=3;
        this.strength=3;
    }

    sayName() {
        console.log(this.name);
        return this;
    }

    showStats() {
        console.log(`Name: ${this.name}, Health: ${this.health}, Speed: ${this.speed}, Strength: ${this.strength}`);
        return this;
    }

    drinkSake () {
        console.log(`${this.name} drank sake.`);
        this.health += 10;
        return this;
    }
}
//Super Ninja

class Sensei extends Ninja {
    constructor(name) {
        super(name);
        this.health = 200;
        this.speed = 10;
        this.strength = 10;
        this.wisdom = 10;
    }

    speakWisdom() {
        super.drinkSake();
        console.log("What one programmer can do in one month, two programmers can do in two months.");
        return this;
    }
}


// example output
const superSensei = new Sensei("Master Splinter");
superSensei.speakWisdom();
// -> "What one programmer can do in one month, two programmers can do in two months."
superSensei.showStats();
// -> "Name: Master Splinter, Health: 210, Speed: 10, Strength: 10"
