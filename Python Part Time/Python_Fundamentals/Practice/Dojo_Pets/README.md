# Assignment: Dojo Pets
For this assignment, you'll be asked to create a Ninja class and a Pet class. Your Ninjas will be able to have a pet - and you can even practice using inheritance by creating sub-classes of pets, if you're ready to stretch yourself!

## Ninja Class

**Attributes**

- first_name
- last_name
- pet
- treats
- pet_food

**Methods**

- walk()
- feed()
- bathe()

```
 class Ninja:
    # implement __init__( first_name , last_name , treats , pet_food , pet )
        	
    
    # implement the following methods:
    # walk() - walks the ninja's pet invoking the pet play() method
    # feed() - feeds the ninja's pet invoking the pet eat() method
    # bathe() - cleans the ninja's pet invoking the pet noise() methodcopy
``` 

## Pet Class

**Attributes**

- name
- type
- tricks
- health
- energy

**Methods**

- sleep()
- eat()
- play()
- noise()

```
class Pet:
    # implement __init__( name , type , tricks ):
    # implement the following methods:
    # sleep() - increases the pets energy by 25
    # eat() - increases the pet's energy by 5 & health by 10
    # play() - increases the pet's health by 5
    # noise() - prints out the pet's sound
```

![Pets](pets.gif)

## Requirements:
- Create a Ninja class with the ninja attributes listed above.
- Create a Pet class with the pet attributes listed above.
- Implement walk(), feed(), bathe() on the ninja class.
- Implement sleep(), eat(), play(), noise() methods on the pet class.
- Make an instance of a Ninja and assign them an instance of a pet to the pet attribute.
- Have the Ninja feed, walk , and bathe their pet.
- **NINJA BONUS:** Use modules to separate out the classes into different files.
- **SENSEI BONUS:** Use Inheritance to create sub classes of pets.
- Compress or zip up assignment and upload it.

