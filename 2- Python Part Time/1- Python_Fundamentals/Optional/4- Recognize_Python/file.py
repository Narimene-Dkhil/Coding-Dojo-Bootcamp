num1 = 42 #Variable declaration, integer
num2 = 2.3 #Variable declaration, float/ decimal
boolean = True #variable declaration, boolean
string = 'Hello World' #Variable declaration, string literal
pizza_toppings = ['Pepperoni', 'Sausage', 'Jalepenos', 'Cheese', 'Olives'] #Variable declaration, list
person = {'name': 'John', 'location': 'Salt Lake', 'age': 37, 'is_balding': False} #Variable declaration, dictionary
fruit = ('blueberry', 'strawberry', 'banana') # Variable declaration, Tuple
print(type(fruit)) #print type, string 
print(pizza_toppings[1]) #print value of idex 1 in a list 
pizza_toppings.append('Mushrooms') #adding value to a list
print(person['name']) #print dictionary value ( of the key "name")
person['name'] = 'George' #dictionary change value 
person['eye_color'] = 'blue' #dictionary change value 
print(fruit[2]) # print tuple value (of index 2)

if num1 > 45: 
    print("It's greater")
else:
    print("It's lower")  #print conditional if, else

if len(string) < 5:
    print("It's a short word!")
elif len(string) > 15:
    print("It's a long word!") 
else:
    print("Just right!") #print conditional if, elif, else 

for x in range(5):
    print(x)  #print loop for x from 0 to 5
for x in range(2,5):
    print(x) #print loop for x from 2 to 5
for x in range(2,10,3):
    print(x) #print loop for x from 2 to 10, increment by 3 
x = 0 
while(x < 5):
    print(x)
    x += 1 #print loop while, x equald 0 and while x less than 5 print x and x increment by 1

pizza_toppings.pop() #list delete value at end
pizza_toppings.pop(1) # list delet value at index 1

print(person) #print dictionary
person.pop('eye_color') #delete value from dictionary ( eye color key)
print(person) #print dictionary

for topping in pizza_toppings: 
    if topping == 'Pepperoni':
        continue
    print('After 1st if statement')
    if topping == 'Olives':
        break   #loop in list , if condition continue, if condition stop the loop

def print_hello_ten_times(): 
    for num in range(10):
        print('Hello')  # function declaration and loop strats from 0 to 10 

print_hello_ten_times() #call function

def print_hello_x_times(x): #declaration of variable x in function 
    for num in range(x):
        print('Hello')

print_hello_x_times(4) #function call with parameter 4 

def print_hello_x_or_ten_times(x = 10): #function call with default parameter 
    for num in range(x):
        print('Hello')

print_hello_x_or_ten_times() #function call to 10
print_hello_x_or_ten_times(4) #function call to 4 


"""
Bonus section
"""


num3 = 72
print(num3) 

fruit[0] = 'cranberry' #Immutable tuple
print(person['favorite_team']) #Undefined variable and dictionary key error:
print(pizza_toppings[7]) #List index error
print(boolean)
fruit.append('raspberry')#Immutable tuple
fruit.pop(1)#Immutable tuple
