# Super Ninja

## Sensei Class
Extend the Ninja class and create the Sensei class. A Sensei should have 200 Health, 10 speed, and 10 strength by default. In addition, a Sensei should have a new attribute called **wisdom**, and the default should be 10. Finally, add the `speakWisdom()` method. `speakWisdom()` should call the `drinkSake()` method from the Ninja class, before console.logging a wise message.

```
// example output
const superSensei = new Sensei("Master Splinter");
superSensei.speakWisdom();
// -> "What one programmer can do in one month, two programmers can do in two months."
superSensei.showStats();
// -> "Name: Master Splinter, Health: 210, Speed: 10, Strength: 10"
```

## Requirements:
- create a class Sensei that inherits from the Ninja class
- add an attribute: wisdom - default to 10
- create a method: speakWisdom()