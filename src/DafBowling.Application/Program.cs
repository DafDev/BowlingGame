using DafBowling.Domain;

Console.WriteLine("****************************************");
Console.WriteLine("\tWelcome to the Game");
Console.WriteLine("****************************************");
var randomizer = new Random();
var game = new Game();
for (int i = 0; i < 9; i++)
{
    Console.WriteLine($"--------Frame n°{i + 1}--------");
    var firstRoll = randomizer.Next(0, 11);
    game.Roll(firstRoll);
    Console.WriteLine($"The player took down {firstRoll} pins on first roll");

    if (game.Strike())
    {
        Console.WriteLine("********** Strike *************");
        continue;
    }

    var secondRoll = randomizer.Next(0, 11 - firstRoll);
    game.Roll(secondRoll);
    Console.WriteLine($"The player took down {secondRoll} pins on second roll");
    //Console.WriteLine($"Current score is {game.Score()}");
    if (game.Spare())
        Console.WriteLine("********** Spare *************");
}
// Last frame is a bit special with extra roll possible
Console.WriteLine($"--------Frame n°10--------");
var firstRollOfLastFrame = randomizer.Next(0, 11);
game.Roll(firstRollOfLastFrame);
Console.WriteLine($"The player took down {firstRollOfLastFrame} pins on first roll");

if (game.Strike())
    Console.WriteLine("********** Strike *************");
else
{
    var secondRollOfLastFrame = randomizer.Next(0, 11 - firstRollOfLastFrame);
    game.Roll(secondRollOfLastFrame);
    Console.WriteLine($"The player took down {secondRollOfLastFrame} pins on second roll");
    if (game.Spare())
        Console.WriteLine("********** Spare *************");
}

if (game.Strike() || game.Spare())
{
    Console.WriteLine("******   Extra Roll!!!  ********");
    var extraRoll = randomizer.Next(0, 11);
    game.Roll(randomizer.Next(0, 11));
    Console.WriteLine($"The player took down {extraRoll} pins on extra roll"); 
}


Console.WriteLine("****************************************");
Console.WriteLine($"\tGame Over! Final Socre: {game.Score()}");
Console.WriteLine("****************************************");