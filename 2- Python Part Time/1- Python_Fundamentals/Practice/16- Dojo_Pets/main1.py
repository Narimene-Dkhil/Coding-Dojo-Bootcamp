# This is the assignement in one document, you will find the assignement 
# in three different documents named maine.py, pet.py, ninja.py 

# Ninja Class
# Attributes: 
# first_name
# last_name
# pet
# treats
# pet_food
# Methods:
# walk()
# feed()
# bathe()
# implement __init__( first_name , last_name , treats , pet_food , pet )
    # implement the following methods:
    # walk() - walks the ninja's pet invoking the pet play() method
    # feed() - feeds the ninja's pet invoking the pet eat() method
    # bathe() - cleans the ninja's pet invoking the pet noise() method
class Ninja:
    def __init__(self, first_name, last_name, pet, treats, pet_food):
    
        self.first_name = first_name
        self.last_name = last_name
        self.pet = pet 
        self.treats = treats
        self.pet_food = pet_food
        
    def walk(self):
        self.pet.walk(self)
        return self 
    def feed(self):
        self.pet.feed(self)
        return self
    
    def bathe(self):
        self.pet.bathe(self)
        return self 

    
class Pet:
    
    def __init__(self, name, type, tricks, health, energy):
        self.name = name
        self.type = type
        self.tricks = tricks
        self.health = health
        self.energy = energy
#or we can set self.healt=100 as a default and self.energy=50 as a default value 
        
    def sleep(self):
        self.energy +=25 
        return self 
    
    def eat(self):
        self.energy += 5
        self.health += 10
        return self
    
    def play(self):
        self.health += 5
        return self 
    
    def noise(self):
        print(f"{self.name} makes a sound!")
        return self 
    
# Pet Class
# Attributes:
# name
# type
# tricks
# health
# energy
# Methods:
# sleep()
# eat()
# play()
#noise()
# implement __init__( name , type , tricks ):
# implement the following methods:
    # sleep() - increases the pets energy by 25
    # eat() - increases the pet's energy by 5 & health by 10
    # play() - increases the pet's health by 5
    # noise() - prints out the pet's sound