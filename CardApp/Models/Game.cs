public class Game 
{
    public List<Suit> Suits { get; set; }

    public List<Value> Values { get; set; }

    private static List<string> _usedCards = new List<string>();

    public const string JOKER_CODE = "JK";

    public Game() {

        var suits = new List<Suit>{
            new Suit(name: "Club", multiplyBy: 1, shortCode: "C"),
            new Suit(name: "Diamond", multiplyBy: 2, shortCode: "D"),
            new Suit(name: "Heart", multiplyBy: 3, shortCode: "H"),
            new Suit(name: "Spade", multiplyBy: 4, shortCode: "S"), 
        };

        var values = new List<Value> {
            new Value(name: "2", amount: 2),
            new Value(name: "3", amount: 3),
            new Value(name: "4", amount: 4),
            new Value(name: "5", amount: 5),
            new Value(name: "6", amount: 6),
            new Value(name: "7", amount: 7),
            new Value(name: "8", amount: 8),
            new Value(name: "9", amount: 9),
            new Value(name: "T", amount: 10),
            new Value(name: "J", amount: 11),
            new Value(name: "Q", amount: 12),
            new Value(name: "K", amount: 13),
            new Value(name: "A", amount: 14),
        };

        Suits = suits;
        Values = values;
    }

    public int CalculateScore(string inputString) {

        ClearList();
        
        if (!InputHelper.IsValidInputString(inputString)) {
            throw new Exception("Invalid input string");
        }

        var splitInput = inputString.Split(",");
        int runningTotal = 0;
        
        foreach (var card in splitInput)
        {
            if (HasCardBeenUsed(card)) {
                throw new Exception("Cards cannot be duplicated");
            }

            if (card == JOKER_CODE && CountJokers() == 2) {
                throw new Exception("A hand cannot contain more than two Jokers");
            }

            AddCardToList(card);

            if (card != JOKER_CODE) {

                var selectedValue = Values.Where(p => p.Name == card[0].ToString()).FirstOrDefault();

                var selectedSuit = Suits.Where(p => p.ShortCode == card[1].ToString()).FirstOrDefault();

                if (selectedSuit == null || selectedValue == null){
                    throw new Exception("Card not recognised");
                }

                runningTotal+= selectedValue.Amount * selectedSuit.MultiplyBy;
            }
        }

        if (CountJokers() > 0) {
            runningTotal *= CountJokers() * 2;
        }

        return runningTotal;
    }

    public int CountJokers() {
        return _usedCards.FindAll(p => p == JOKER_CODE).Count();
    }

    public bool HasCardBeenUsed(string characterCode) {
        if (characterCode == JOKER_CODE) {
            return false;
        }

        if (_usedCards.Contains(characterCode)) {
            return true;
        }else{
            return false;
        }
    }

    public static void AddCardToList(string card) {
        _usedCards.Add(card);
    }

    public static void ClearList() {
        _usedCards.Clear();
    }
}