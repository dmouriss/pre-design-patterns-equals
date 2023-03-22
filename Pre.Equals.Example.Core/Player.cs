namespace Pre.Equals.Example.Core;

public class Player
{ 
    public string Name { get; }
    public Location Location { get; }
    
    public int Score { get; private set; }
    public Player(string playerName)
    {
        Name = playerName;
        Location = new Location();
    }

    public void Move(int horizontal, int vertical)
    {
        Location.MoveLeft(horizontal);
        Location.MoveUp(vertical);
    }

    public void AddPoint()
    {
        Score += 1;
    }
    
    public override string ToString()
    {
        return Name;
    }
}