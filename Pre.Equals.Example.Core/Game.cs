namespace Pre.Equals.Example.Core;

public class Game
{

    public List<Player> players { get; }

    private int currentPlayerIndex;

    public Player CurrentPlayer
    {
        get
        {
            return players[currentPlayerIndex];
        }
    }

    public Game()
    {
        players = new List<Player>();
    }

    public void AddPlayer(string playerName)
    {
        players.Add(new Player(playerName));
    }

    public bool DoTurn(int horizontal, int vertical, int[] diceResult)
    {
        if (Math.Abs(horizontal) > diceResult[0] || Math.Abs(vertical) > diceResult[1]) return false;
        
        CurrentPlayer.Move(horizontal, vertical);
        currentPlayerIndex = (currentPlayerIndex + 1) * players.Count;

        return true;
    }
}