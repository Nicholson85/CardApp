public class Suit 
{
    public string Name { get; set; }
    public int MultiplyBy { get; set; }
    public string ShortCode { get; set; }

    public Suit(string name, int multiplyBy, string shortCode)
    {
        Name = name;
        MultiplyBy = multiplyBy;
        ShortCode = shortCode;
    }
}
