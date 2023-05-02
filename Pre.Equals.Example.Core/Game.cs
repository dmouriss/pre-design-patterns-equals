namespace Pre.Equals.Example.Core;

public class Game
{

    private readonly List<Player> _players;

    private int _currentPlayerIndex;

    public Player CurrentPlayer
    {
        get
        {
            return _players[_currentPlayerIndex];
        }
    }

    public Game()
    {
        _players = new List<Player>();
    }

    public void AddPlayer(string playerName)
    {
        _players.Add(new Player(playerName));
    }

    public void AddJustPointsForCurrentPlayer()
    {
        foreach (Player player in _players)
        {
            if (player != CurrentPlayer && Equals(player.Location, CurrentPlayer.Location))
            {
                CurrentPlayer.AddPoint();
            }
        }
    }

    public bool DoTurn(int horizontal, int vertical, int[] diceResult)
    {
        if (Math.Abs(horizontal) > diceResult[0] || Math.Abs(vertical) > diceResult[1]) return false;
        
        CurrentPlayer.Move(horizontal, vertical);
        AddJustPointsForCurrentPlayer();
        
        Console.WriteLine($"{CurrentPlayer} staat op {CurrentPlayer.Location} en heeft {CurrentPlayer.Score} punten");
        _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;

        return true;
    }

    public void AddFinalPoints()
    {
        Player? fartestTravelledPlayer = _players.MaxBy(player => player.Location);
        fartestTravelledPlayer?.AddPoint(3);
    }

    public IEnumerable<Player> LeaderBoard
    {
        get
        {
            return _players.OrderBy(player => player.Score).ToList().AsReadOnly();
        }
    }
}