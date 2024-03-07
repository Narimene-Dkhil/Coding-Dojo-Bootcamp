class BankAccount:
    
    def __init__(self, int_rate=0.2, balance=0):
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
        print(f"Your current balance is: {self.balance}")
        return self
        
    def yield_interest(self):
        if self.balance >= 0:
            self.balance += self.balance * self.int_rate
        return self 

class User:
    def __init__(self, name, email):
        self.name = name
        self.email = email
        self.account = BankAccount(int_rate=0.02, balance=0)

    def make_deposit(self, amount):
        self.account.deposit(amount)
        return self

    def make_withdrawal(self, amount):
        self.account.withdraw(amount)
        return self

    def display_user_balance(self):
        print(f"User: {self.name}, Email: {self.email}")
        self.account.display_account_info()
        return self
