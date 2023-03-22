namespace Pre.Equals.Example.Core;

public class Dice
{
    private const int MaxDiceValue = 7;
    private static Random random = new Random();

    public static int[] RollDice()
    {
        return new int[] { random.Next(1, MaxDiceValue), random.Next(1, MaxDiceValue) };
    }
}