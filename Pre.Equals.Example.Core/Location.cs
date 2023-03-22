namespace Pre.Equals.Example.Core;

public class Location
{
    public int Row { get; private set; }
    public int Column { get; private set; }
    public Location()
    {
        Row = 0;
        Column = 0;
    }

    public void MoveLeft(int amount)
    {
        Row += amount;
    }

    public void MoveUp(int amount)
    {
        Column += amount;
    }

    public override string ToString()
    {
        return $"{Row} = {Column}";
    }
}