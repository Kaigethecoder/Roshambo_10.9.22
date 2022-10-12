# Roshambo_10.9.22
> Roshambo is a fun game created in Visual Studio 6.0 using a C# Console App.

## Project Description
> The Roshambo project allows the user to play a simple game of Rock, Paper, Scissors.
- First: you are shown the rules if needed.
- Second: Create your player.
- Third: Choose your opponent.
- Fourth: Pick your weapon.
- Finally: Repeat as many times as you like.

## Breakdown of Classes
> Validator
- Validates input
- Displays results
- Generates computer Roshambo values and player types
> Abstract Class Player
- declates enum for Roshambo value(Rock, Paper and Scissors)
- declares properties for Player(string Name, Roshambo roshambo)
- No argument constructor
- Two abstract Methods
> Child Class RockPlayer
- Inherits from Player Class
- Always generates Roshambo value "Rock"
- Name is "Rock Player"
> Child Class RandomPlayer
- Inherits from Player Class
- Randomly generates Roshambo value
- Name is "Random Player"
> Child Class HumanPlayer
-Inherits from Player Class
- Allows user to pick Roshambo value
- Allows user to enter name

## Breakdown of Methods
> Validator
- public string DisplayUserChoices(Player user, Player opponent) Objective: return player names and their roshambo values for the round.
- public void SeeRules() Objective: Asks if you know the rules and if not explains how to play.
- public bool PlayAgain(string response, Player user) Objective: Determine if the user wishes to continue playing.
- public string DisplayResults(Player user, Player opponent) Objective: Display who won the round.
- public string ValidateResponse() Objective: Get a valid yes or no response. "Y" for yes or "N" for no.  Not case sensitive.
- public Player.Roshambo ValidUserChoice() Objective: Get valid user input for Roshambo value.
- public int GetRandomValue() Objective: Get Random value to implement for other methods.
- public Player PickRandomPlayerType() Objective: Randomly select an opponent for the user.
- public Player GetOtherPlayerType() Objective: Get valid opponent for the user.
> Player
- public abstract Roshambo GetRoshambo();  Objective: Ensure child classes get a Roshambo value.
- public abstract string GetName(); Objective: Ensure child classes get a name.
> RockPlayer : Player
- public override Roshambo GetRoshambo() Objective: Override abstract method and set Roshambo value to rock.
- public override string GetName() Objective: Override abstract method and set name to "Rock Player".
> RandomPlayer : Player
- public override Roshambo GetRoshambo() Objective: Override abstract method and generate random Roshambo value.
- public override string GetName() Objective: Override abstract method and set name to "Random Player".
> HumanPlayer : Player
- public override Roshambo GetRoshambo() Objective: Override abstract method and allow user to get a valid Roshambo value.
- public override string GetName() Objective: Override abstract method and get a valid name from the user.

## Stretch Goals
At a later date I may come back to this and clean up the methods and classes a bit while keeping track of the wins of each player.

## Skills Demonstrated
- C#
- OOP
- User Input
- Conditionals
- Design Patterns
- Polymorphism
- Inheritance
- Enums
- Validation
