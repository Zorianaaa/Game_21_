namespace CardHomeWork3
{
    public class Game
    {
        private Deck deck;
        private Player player;
        private Player computer;
        private Player currentPlayer;

        public Game()
        {
            deck = new Deck();
            player = new Player("Player");
            computer = new Player("Computer");
        }

        public void Start()
        {
            Console.WriteLine("Вітаю в грі \"21\"!");
            Console.Write("Хто буде першим? (Player/Computer): ");
            string firstPlayer = Console.ReadLine().Trim();
            currentPlayer = firstPlayer.Equals("Player", StringComparison.OrdinalIgnoreCase) ? player : computer;

            InitialDraw(player);
            InitialDraw(computer);

            while (true)
            {
                DisplayHands();
                if (CheckWinConditions())
                {
                    break;
                }

                Console.Write($"{currentPlayer.Name}, Чи бажаєте взяти карту? (yes/no): ");
                if (Console.ReadLine().Trim().Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    currentPlayer.DrawCard(deck);
                }

                currentPlayer = currentPlayer == player ? computer : player;
            }

            DisplayHands();
            DetermineWinner();
        }

        private void InitialDraw(Player player)
        {
            player.DrawCard(deck);
            player.DrawCard(deck);
        }

        private void DisplayHands()
        {
            Console.WriteLine(player);
            Console.WriteLine(computer);
        }

        private bool CheckWinConditions()
        {
            if (player.GetScore() == 21 || player.HasTwoAces() || computer.GetScore() == 21 || computer.HasTwoAces())
            {
                return true;
            }

            if (player.GetScore() > 21 || computer.GetScore() > 21)
            {
                return true;
            }

            return false;
        }

        private void DetermineWinner()
        {
            if (player.GetScore() == 21 || player.HasTwoAces())
            {
                Console.WriteLine("Ви виграли!");
            }
            else if (computer.GetScore() == 21 || computer.HasTwoAces())
            {
                Console.WriteLine("Притовник виграв!");
            }
            else if (player.GetScore() > 21 && computer.GetScore() > 21)
            {
                if (player.GetScore() < computer.GetScore())
                {
                    Console.WriteLine("Ви виграли!");
                }
                else
                {
                    Console.WriteLine("Противник виграв!");
                }
            }
            else if (player.GetScore() > 21)
            {
                Console.WriteLine("Противник виграв!");
            }
            else if (computer.GetScore() > 21)
            {
                Console.WriteLine("Ви виграли!");
            }
            else
            {
                Console.WriteLine("Нічия...");
            }
        }
    }

}
