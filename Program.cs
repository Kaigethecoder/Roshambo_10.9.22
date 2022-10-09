public class Program
{
    public static void Main(string[] args)
    {  
        Validator valid = new Validator();
        Player user = new HumanPlayer();
        Player opponent = null;
        bool game = true;
        Console.WriteLine("Let's play Rock, Paper, Scissors!");
        valid.SeeRules();
        while (game)
        {
            user.Name = user.GetName();
            opponent = valid.GetOtherPlayerType();
            user.roshambo = user.GetRoshambo();
            opponent.roshambo = opponent.GetRoshambo();
            Console.WriteLine(valid.DisplayUserChoices(user, opponent) + valid.DisplayResults(user, opponent));
            Console.WriteLine($"\nWould you like to play again {user.Name}?");
            string response = valid.ValidateResponse();
            game = valid.PlayAgain(response, user);
        }
    }
    public class Validator
    {
        public string DisplayUserChoices(Player user, Player opponent)
        {
            return $"\n{user.Name} chose {user.roshambo} and {opponent.Name} chose {opponent.roshambo}";
        }
        public void SeeRules()
        {
            Console.WriteLine("\nDo you know the rules?");
            string response = ValidateResponse();
            if (response == "Y")
            {
                Console.WriteLine("\nGreat!");
            }
            else
            {
                Console.WriteLine("\nThe game is simple...");
                Console.WriteLine("Rock crushes scissors, scissors cut paper and paper covers rock!");
            }
        }
        public bool PlayAgain(string response, Player user)
        {
            bool game = true;
            if (response == "Y")
            {
                game = true;
                Console.WriteLine("\nGreat!");
            }
            else
            {
                game = false;
                Console.WriteLine($"\nCome back to play again soon {user.Name}!");
            }
            return game;
        }
        public string DisplayResults(Player user, Player opponent)
        {
            string result = "";
            string userWins = $"\n{user.Name} wins!";
            string opponentWins = $"\n{opponent.Name} wins!";
            if (user.roshambo == opponent.roshambo)
            {
                result = "\nDraw!";
            }
            else if (user.roshambo == Player.Roshambo.Rock)
            {
                if (opponent.roshambo == Player.Roshambo.Scissors)
                {
                    result = userWins;
                }
                else
                {
                    result = opponentWins;
                }
            }
            else if (user.roshambo == Player.Roshambo.Paper)
            {
                if (opponent.roshambo == Player.Roshambo.Rock)
                {
                    result = userWins;
                }
                else
                {
                    result = opponentWins;
                }
            }
            else
            {
                if (opponent.roshambo == Player.Roshambo.Paper)
                {
                    result = userWins;
                }
                else
                {
                    result = opponentWins;
                }
            }
            return result;
        }
        public string ValidateResponse()
        {
            string validResponse = "";
            bool valid = false;
            while (valid == false)
            {
                Console.WriteLine("Please enter y for yes and n for no.");
                string response = Console.ReadLine();
                if (response.Equals("y", StringComparison.CurrentCultureIgnoreCase))
                {
                    validResponse = response.ToUpper();
                    valid = true;
                }
                else if (response.Equals("n", StringComparison.CurrentCultureIgnoreCase))
                {
                    validResponse = response.ToUpper();
                    valid = true;
                }
                else
                {
                    valid = false;
                    Console.WriteLine("\nI'm sorry, I didn't catch that.");
                }
            }
            return validResponse;
        }
        public Player.Roshambo ValidUserChoice()
        {
            bool valid = false;
            int weapon = 0;
            var userChoice = new Player.Roshambo();
            Console.WriteLine("\nChoose your weapon!");
            while(valid == false)
            {
                Console.WriteLine("\nEnter 0 for Rock, 1 for Paper or 2 for Scissors.");
                string weaponChoice = Console.ReadLine();
                bool isNum = int.TryParse(weaponChoice, out weapon);
                if (isNum)
                {
                    if (weapon < 0 || weapon > 2)
                    {
                        valid = false;
                        Console.WriteLine("\nSorry, I didn't catch that.");
                    }
                    else
                    {
                        valid = true;
                        if(weapon == 0)
                        {
                            userChoice = Player.Roshambo.Rock;
                        }
                        else if (weapon == 1)
                        {
                            userChoice = Player.Roshambo.Paper;
                        }
                        else
                        {
                            userChoice = Player.Roshambo.Scissors;
                        }
                    }
                }
                else
                {
                    valid = false;
                    Console.WriteLine("\nSorry, I didn't catch that.");
                }
            }
            return userChoice;
        }
        public int GetRandomValue()
        {
            var random = new Random();
            return random.Next(0, 3);
        }
        public Player PickRandomPlayerType()
        {
            Player opponent = null;
            int randomValue = GetRandomValue();
            if (randomValue == 0)
            {
                opponent = new RockPlayer();
            }
            else if (randomValue == 1)
            {
                opponent = new RandomPlayer();
            }
            else
            {
                opponent = new HumanPlayer();
            }
            return opponent;
        }
        public Player GetOtherPlayerType()
        {
            bool validPlayer = false;
            Player opponent = null;
            while (validPlayer == false)
            {
                Console.WriteLine("\nWho would you like to battle?");
                string response = Console.ReadLine().ToLower();
                if (response.Contains("rock"))
                {
                    validPlayer = true;
                    opponent = new RockPlayer();
                }
                else if (response.Contains("random"))
                {
                    validPlayer = true;
                    opponent = new RandomPlayer();
                }
                else if (response.Contains("human"))
                {
                    validPlayer = true;
                    opponent = new HumanPlayer();
                }
                else if (response.Contains("any"))
                {
                    validPlayer = true;
                    opponent = PickRandomPlayerType();
                }
                else
                {
                    validPlayer = false;
                    Console.WriteLine("\nSorry, you can only play against a Rock Player, Random Player or Human Player." +
                        " If unsure, say any.");
                }
            }
            opponent.Name = opponent.GetName();
            return opponent;
        }
    }
    public abstract class Player
    {
        public enum Roshambo
        {
            Rock,
            Paper,
            Scissors
        }
        Roshambo value;
        public string Name { get; set; }
        public Roshambo roshambo { get; set; }
        public Player(string newName, Roshambo newRoshambo)
        {
            Name = newName;
            roshambo = newRoshambo;
        }
        public Player()
        {

        }
        public abstract Roshambo GetRoshambo();
        public abstract string GetName();
    }
    public class RockPlayer : Player
    {
        public RockPlayer(string newName, Roshambo newRoshambo)
        {
            Name = newName;
            roshambo = newRoshambo;
        }
        public RockPlayer()
        {

        }
        public override Roshambo GetRoshambo()
        {
            return Roshambo.Rock;
        }
        public override string GetName()
        {
            return "Rock Player";
        }
    }
    public class RandomPlayer : Player
    {
        public RandomPlayer(string newName, Roshambo newRoshambo)
        {
            Name = newName;
            roshambo = newRoshambo;
        }
        public RandomPlayer()
        {

        }
        public override Roshambo GetRoshambo()
        {
            Validator valid = new Validator();
            int randomValue = valid.GetRandomValue();
            if(randomValue == 0)
            {
                return Roshambo.Rock;
            }
            else if (randomValue == 1)
            {
                return Roshambo.Paper;
            }
            else
            {
                return Roshambo.Scissors;
            }
        }
        public override string GetName()
        {
            return "Random Player";
        }
    }
    public class HumanPlayer : Player
    {
        public HumanPlayer(string newName, Roshambo newRoshambo)
        {
            Name = newName;
            roshambo = newRoshambo;
        }
        public HumanPlayer()
        {

        }
        public override Roshambo GetRoshambo()
        {
            Validator valid = new Validator();
            return valid.ValidUserChoice();
        }
        public override string GetName()
        {
            string playerName = "";
            Console.WriteLine("\nPlease enter your name.");
            playerName = Console.ReadLine();
            return playerName;
        }
    }
}