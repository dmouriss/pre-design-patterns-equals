// See https://aka.ms/new-console-template for more information

using Pre.Equals.Example.Core;

const int NumberOfRounds = 4;

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
 * PLAY ROUNDS
*/

for (int i = 0; i < NumberOfRounds; i++)
{
    var diceResult = Dice.RollDice();
    Console.WriteLine($"{game.CurrentPlayer} gooide een {diceResult[0]} en een {diceResult[1]}");
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
    if (!validTurn) Console.WriteLine("Ongeldig aantal stappen");
}

game.AddFinalPoints();

foreach (Player player in game.LeaderBoard)
{
    Console.WriteLine($"{player.Name}: {player.Score} punten");
}