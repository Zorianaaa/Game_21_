public class Player
{
    public string Name { get; }
    public List<Card> Hand { get; }
    private int score;

    public Player(string name)
    {
        Name = name;
        Hand = new List<Card>();
        score = 0;
    }

    public void DrawCard(Deck deck)
    {
        Card card = deck.DrawCard();
        Hand.Add(card);
        score += card.Value;
    }

    public int GetScore()
    {
        return score;
    }

    public bool HasTwoAces()
    {
        int aceCount = 0;
        foreach (var card in Hand)
        {
            if (card.Rank == "Ace")
            {
                aceCount++;
            }
        }
        return aceCount >= 2;
    }

    public override string ToString()
    {
        string handDescription = "";
        foreach (var card in Hand)
        {
            handDescription += card.ToString() + ", ";
        }
        handDescription = handDescription.TrimEnd(',', ' ');

        return $"{Name}: {handDescription} (Score: {score})";
    }
}

