namespace Sensei.Data;

public class RadicalSymbol
{
    public RadicalSymbol(string symbol, string meaning)
    {
        Symbol = symbol;
        Meaning = meaning;
    }

    public RadicalSymbol(string symbol, string meaning, int strokeCount)
        : this(symbol, meaning)
    {
        StrokeCount = strokeCount;
    }

    public RadicalSymbol(string symbol, string meaning, int strokeCount, string modifiedRadicals)
        : this(symbol, meaning, strokeCount)
    {
        ModifiedRadicals = modifiedRadicals;
    }

    public string Symbol { get; set; }
    public string Meaning { get; set; }
    public string ModifiedRadicals { get; set; }
    public int StrokeCount { get; set; }

    public override string ToString()
    {
        var result = $"{Symbol} {Meaning}";
        if (!string.IsNullOrEmpty(ModifiedRadicals))
        {
            result += $" ({ModifiedRadicals})";
        }
        return result;
    }
}