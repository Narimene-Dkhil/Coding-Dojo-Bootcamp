# It's Time to Duel


## Unit Cards

name	            cost	power	resilience
Red Belt Ninja	    3	    3	    4
Black Belt Ninja	4	    5	    4


## Effect Cards

name	                    cost	text	                        stat	        magnitude
Hard Algorithm	            2	increase target's resilience by 3	resilience	    +3
Unhandled Promise Rejection	1	reduce target's resilience by 2	    resilience	    -2
Pair Programming	        3	increase target's power by 2	    power	        +2


## Play out the following scenario

turn	action
1	    Make an instance of "Red Belt Ninja"
1	    Make an instance of "Hard Algorithm" and play it on "Red Belt Ninja"
2	    Make an instance "Black Belt Ninja"
2	    Make an instance of "Unhandled Promise Rejection" and play it on "Red Belt Ninja"
3	    Make an instance of "Pair Programming" and play it on "Red Belt Ninja"
3	    "Red Belt Ninja" uses the attack method on "Black Belt Ninja"

## Requirements:
- Make an instance of Unit called "Red Belt Ninja"
- Make an instance of Unit called "Black Belt Ninja"
- Make an instance of Effect called "Hard Algorithm"
- Make an instance of Effect called "Unhandled Promise Rejection"
- Make an instance of Effect called "Pair Programming"
- Play out the scenario described above