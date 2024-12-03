class BankAccount:
    
    def __init__(self, int_rate=0.1, balance=0):
        self.int_rate = int_rate
        self.balance = balance
        
    def deposit(self, amount):
        self.balance += amount
        return self 
        
    def withdraw(self, amount):
        if self.balance < amount:
            print(f"Insufficient funds: Charging a $5 fee")
            self.balance -= 5
        else:
            self.balance -= amount
        return self 
    
    def display_account_info(self):
        print(f"Your current balance is: ${self.balance}")
        return self
        
    def yield_interest(self):
        if self.balance >= 0:
            self.balance += self.balance * self.int_rate
        return self 
    

account1 = BankAccount(0.1, 100)
account1.deposit(50).deposit(30).deposit(20).withdraw(30).display_account_info().yield_interest().display_account_info()

account2 = BankAccount(0.1, 200) 
account2.deposit(100).deposit(50).withdraw(30).withdraw(20).withdraw(10).withdraw(5).display_account_info().yield_interest().display_account_info() 