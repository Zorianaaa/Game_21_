public class Deck
{
    private List<Card> cards;
    private static readonly string[] Suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
    private static readonly string[] Ranks = { "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
    private static readonly int[] Values = { 6, 7, 8, 9, 10, 2, 3, 4, 11 };

    public Deck()
    {
        cards = new List<Card>();
        GenerateDeck();
        ShuffleDeck();
        FindAces();
        MoveSpadesToFront();
    }

    private void GenerateDeck()
    {
        for (int i = 0; i < Suits.Length; i++)
        {
            for (int j = 0; j < Ranks.Length; j++)
            {
                cards.Add(new Card(Suits[i], Ranks[j], Values[j]));
            }
        }
    }

    private void ShuffleDeck()
    {
        Random rng = new Random();
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }
    }

    public List<int> FindAces()
    {
        List<int> acePositions = new List<int>();
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].Rank == "Ace")
            {
                acePositions.Add(i);
            }
        }
        return acePositions;
    }

    public void MoveSpadesToFront()
    {
        int spadeIndex = 0;
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].Suit == "Spades")
            {
                Card temp = cards[spadeIndex];
                cards[spadeIndex] = cards[i];
                cards[i] = temp;
                spadeIndex++;
            }
        }
    }

    public Card DrawCard()
    {
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }

    public List<Card> GetCards()
    {
        return cards;
    }
}

