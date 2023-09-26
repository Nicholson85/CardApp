internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter your cards:");
        
        string cardInput = Console.ReadLine();

        if (cardInput != null) {
            var cardGame = new Game();
            
            Console.WriteLine("Score: " + cardGame.CalculateScore(cardInput));
        }
    }
}