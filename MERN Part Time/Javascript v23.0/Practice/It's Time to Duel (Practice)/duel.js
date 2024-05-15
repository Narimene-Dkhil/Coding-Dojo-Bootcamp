class UnitCard {
    constructor(name, cost, power, resilience) {
        this.name = name;
        this.cost = cost;
        this.power = power;
        this.resilience = resilience;
    }
}

class EffectCard {
    constructor(name, cost, text, stat, magnitude) {
        this.name = name;
        this.cost = cost;
        this.text = text;
        this.stat = stat;
        this.magnitude = magnitude;
    }

    play(target) {
        if(this.stat == "resilience") {
            target.resilience += this.magnitude;
        } else if(this.stat == "power") {
            target.power += this.magnitude;
        }
    }
}

// Turn 1
let redBeltNinja = new UnitCard("Red Belt Ninja", 3, 3, 4);
let hardAlgorithm = new EffectCard("Hard Algorithm", 2, "increase target's resilience by 3", "resilience", 3);
hardAlgorithm.play(redBeltNinja);

// Turn 2
let blackBeltNinja = new UnitCard("Black Belt Ninja", 4, 5, 4);
let unhandledPromiseRejection = new EffectCard("Unhandled Promise Rejection", 1, "reduce target's resilience by 2", "resilience", -2);
unhandledPromiseRejection.play(redBeltNinja);

// Turn 3
let pairProgramming = new EffectCard("Pair Programming", 3, "increase target's power by 2", "power", 2);
pairProgramming.play(redBeltNinja);

// Red Belt Ninja attacks Black Belt Ninja
blackBeltNinja.resilience -= redBeltNinja.power;
