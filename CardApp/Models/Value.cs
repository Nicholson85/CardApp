
public class Value {
    public string Name { get; set; }
    public int Amount { get; set; }
    public Value(string name, int amount)
    {
        Name = name;
        Amount = amount;
    }
}