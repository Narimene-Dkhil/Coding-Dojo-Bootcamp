# class Player:
#     def __init__(self, name, age, position, team):
#         self.name = name
#         self.age = age
#         self.position = position
#         self.team = team

# Challenge 1: Update the Constructor
class Player:
    def __init__(self, player_data):
        self.name = player_data["name"]
        self.age = player_data["age"]
        self.position = player_data["position"]
        self.team = player_data["team"]

# Challenge 2: Create instances using individual player dictionaries.
Kevin = {
    "name": "Kevin Durant", 
    "age":34, 
	"position": "small forward", 
    "team": "Brooklyn Nets"
}
    
Jason = {
    "name": "Jason Tatum", 
    "age":24, 
    "position": "small forward", 
    "team": "Boston Celtics"
}

Kyrie = {
    "name": "Kyrie Irving", 
    "age":32, 
    "position": "Point Guard", 
    "team": "Brooklyn Nets"
}

# Create Player instances
player_kevin = Player(Kevin)
player_jason = Player(Jason)
player_kyrie = Player(Kyrie)
print(player_jason)
print(player_kevin)
print(player_kyrie)

# Challenge 3: Make a list of Player instances from a list of dictionaries

players_list = [
    {
        "name": "Kevin Durant",
        "age": 34,
        "position": "small forward",
        "team": "Brooklyn Nets"
    },
    {
        "name": "Jason Tatum",
        "age": 24,
        "position": "small forward",
        "team": "Boston Celtics"
    },
    {
        "name": "Kyrie Irving",
        "age": 32,
        "position": "Point Guard",
        "team": "Brooklyn Nets"
    },
]

new_team = []

for player_data in players_list:
    new_player = Player(player_data)
    new_team.append(new_player)
    
# NINJA BONUS: Add a get_team(cls, team_list) @class method

@classmethod 
def get_team(cls, team_list):
    team = []
    for player_data in team_list:
        new_player = cls(player_data)
        team.append(new_player)
    return team



