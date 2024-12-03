# Chaining Methods
In the last assignment, your code might have looked something like this:
```
user1.display_info()
user1.enroll()
user1.spend_points(50)
user1.display_info()
user2.enroll()
user2.spend_points(80)
user2.display_info()
```
This takes up a lot of space and we're repeating our call to user1 and user2 many times. 

## Short-cut!
There is a way to call on user1 just once and keep attaching new method calls to the end of the previous one, like so:
```
user1.display_info().enroll().spend_points(50).display_info()
user2.enroll().spend_points(80).display_info()
```

This is called **chaining**. In order for this to work, each method must return *self*. By returning self, if we recall how functions work, each method call will now be equal to the instance that called it.

For example if `user1.spend_points(50)` returns its own instance (user1 ), then we can call one of that instance's methods after that call, like `user1.spend_points(50).display_info()`.
```
class User:
    # .. constructor
    
    def display_info(self):
        # your code
    
    	# new return statement, returns this same object
        return self
```

The practice of having OOP return its own instance is pretty common and is done in other programming languages, though the variable name in some languages is not `self`, but instead `this`.

**Note:** This only works with methods that do not need to return anything. If your method needs to return something other than self, it is not possible to chain the method.

## Requirements:
- Update your previous assignment so that each instance's methods are chained