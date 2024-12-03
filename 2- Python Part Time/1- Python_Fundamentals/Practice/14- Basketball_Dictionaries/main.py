# class Player:
#     def __init__(self, name, age, position, team):
#         self.name = name
#         self.age = age
#         self.position = position
#         self.team = team
# Update the constructor to accept a dictionary with a single player's information instead of 
# individual arguments for the attributes.

class Player:
    def __init__(self, player_data):
        self.name = player_data ["name"]
        self.age = player_data ["age"]
        self.position = player_data ["position"]
        self.team = player_data ["team"]

# Challenge 2: Create instances using individual player dictionaries.
# Given these variables, create Player instances for each of the following dictionaries. 
# Be sure to instantiate these outside the class definition, in the outer scope.

kevin = {
    "name": "Kevin Durant", 
    "age":34, 
    "position": "small forward", 
    "team": "Brooklyn Nets"
}
jason = {
    "name": "Jason Tatum", 
    "age":24, 
    "position": "small forward", 
    "team": "Boston Celtics"
}
kyrie = {
    "name": "Kyrie Irving", 
    "age":32, "position": "Point Guard", 
    "team": "Brooklyn Nets"
}
# Create Player instances

player_kevin = Player(kevin)
player_jason = Player(jason)
player_kyrie = Player(kyrie) 
print(player_kevin) 
print(player_jason)
print(player_kyrie) 

# Challenge 3: Make a list of Player instances from a list of dictionaries
# Finally, given the example list of players at the top of this module (the one with many players) 
# write a for loop that will populate an empty list with Player objects from the original list of dictionaries.

# # ... (class definition and large list of players here)

#  Write your for loop here to populate the new_team variable with Player objects.
#     copy

players = [
    {
    "name": "Kevin Durant", 
    "age":34, 
    "position": "small forward", 
    "team": "Brooklyn Nets"
    },
    {
    "name": "Jason Tatum", 
    "age":24, 
    "position": "small forward", 
    "team": "Boston Celtics"
    },
    {
    "name": "Kyrie Irving", 
    "age":32, "position": "Point Guard", 
    "team": "Brooklyn Nets"
    },
    {
    "name": "Damian Lillard", 
    "age":33, "position": "Point Guard", 
    "team": "Portland Trailblazers"
    },
    {
    "name": "Joel Embiid", 
    "age":32, "position": "Power Foward", 
    "team": "Philidelphia 76ers"
    },
    {
    "name": "", 
    "age":16, 
    "position": "P", 
    "team": "en"
    }
]
    
new_team = [] 

for player_data in players:
    new_player = Player(player_data)
    new_team.append(new_player)


# NINJA BONUS: Add a get_team(cls, team_list) @class method
# Add an @class method called get_team(cls, team_list) that, given a list of dictionaries populates and 
# returns a new list of Player objects. Be sure to test your method!

@classmethod

def get_team(cls, team_list):
    team = []
    for player_data in team_list:
        new_player = cls(player_data)
        team.append(new_player)
    return team

# Print the new_team
print("New Team:")
for player in new_team:
    print(f"Name: {player.name}, Age: {player.age}, Position: {player.position}, Team: {player.team}")