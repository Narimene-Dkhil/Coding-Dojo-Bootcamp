class User():
    def __init__(self, first_name, last_name, email, age):
        self.first_name = first_name
        self.last_name = last_name
        self.email = email
        self.age = age
        
        self.is_rewards_member = False
        self.gold_card_points = 0
        
    def display_info(self):  #Have this method print all of the users' details on separate lines.
        print(f"First name is: {self.first_name}")
        print(f"Last name is: {self.last_name}")
        print(f"Email is: {self.email}")
        print(f"Age is: {self.age}")
        print(f"Rewards Member: {self.is_rewards_member}")
        print(f"Gold Card Points: {self.gold_card_points}")
        
    def enroll(self): #Have this method change the user's member status to True and set their gold card points to 200.
        
        if  self.is_rewards_member:
            print("User already a member.")
            return False
        else:
            self.is_rewards_member = True
            self.gold_card_points = 200 
            print("Enrolled successfully")
            return True 
        
    def spend_points(self, amount): #have this method decrease the user's points by the amount specified.
        if self.gold_card_points < amount:
            print("Not enough points to spend.")
        else:
            self.gold_card_points -= amount
            print(f"{amount} points spent successfully. Remaining points: {self.gold_card_points}")
            
my_user = User("Jane", "Doe", "jdoe@email.com", 30) 
my_user.display_info()
my_user.enroll()
my_user.display_info() 
my_user.spend_points(50)
my_user.display_info()

    
        
    