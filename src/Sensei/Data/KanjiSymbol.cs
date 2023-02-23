namespace Sensei.Data;

public class KanjiSymbol
{
    public KanjiSymbol(string symbol)
    {
        Symbol = symbol;
    }

    public string Symbol { get; set; }
    public string English { get; set; }
    public string French { get; set; }
    public string Kunyomi { get; set; }
    public string Onyomi { get; set; }
    public int StrokeCount { get; set; }

    //public override string ToString()
    //{
    //    var result = $"{Symbol} {Meaning}";

    //    return result;
    //}
}