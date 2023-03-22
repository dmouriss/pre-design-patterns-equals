// See https://aka.ms/new-console-template for more information

using Pre.Equals.Example.Core;

Game game = new Game();

/*
 * ADD PLAYERS
 */
Console.Write("Naam: ");
string? playerName = Console.ReadLine();

while (!string.IsNullOrEmpty(playerName))
{
    game.AddPlayer(playerName);
    Console.Write("Naam: ");
    playerName = Console.ReadLine();
}

/*
 * PLAY GAME
*/

while (true)
{
    var diceResult = Dice.RollDice();
    Console.WriteLine($"{game.CurrentPlayer} rolled a {diceResult[0]} and a {diceResult[1]}");
    bool validHorizontal;
    bool validVertical;
    int horizontal;
    int vertical;
    do
    {
        Console.Write($"Horizontale beweging (max {diceResult[0]}): ");
        validHorizontal = int.TryParse(Console.ReadLine(), out horizontal);
        Console.Write($"Verticale beweging (max {diceResult[1]}): ");
        validVertical = int.TryParse(Console.ReadLine(), out vertical);
    } while (!validHorizontal || !validVertical);

    bool validTurn = game.DoTurn(horizontal, vertical, diceResult);
    if (validTurn) Console.WriteLine($"{game.CurrentPlayer} staat op {game.CurrentPlayer.Location}");
    else Console.WriteLine("Ongeldig aantal stappen");
}