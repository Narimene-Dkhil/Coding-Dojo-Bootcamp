from pet import Pet
from ninja import Ninja

# Create instances
my_pet = Pet(name="Rose", type="Dog", tricks=["Sit", "Jump"])
my_ninja = Ninja(first_name="Jane", last_name="Doe", treats=5, pet_food="DogFood", pet=my_pet)

# Ninja actions
my_ninja.feed().walk().bathe()

# Bonus: Using Inheritance
class Cat(Pet):
    def __init__(self, name, tricks):
        super().__init__(name=name, type="Cat", tricks=tricks)

# Create an instance of a ninja with a cat
my_cat = Cat(name="Micha", tricks=["Jump", "Meow"])
my_ninja_with_cat = Ninja(first_name="Jane", last_name="Doe", treats=3, pet_food="CatFood", pet=my_cat)

# Ninja with cat actions
my_ninja_with_cat.feed().walk().bathe()
