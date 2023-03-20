namespace Sensei.Data;

public class KanjiResult
{
    public KanjiResult(string literal, int? jlpt, int strokeCount, string kun, string on, string[] meanings)
    {
        Literal = literal;
        JLPT = jlpt;
        StrokeCount = strokeCount;
        Kun = kun;
        On = on;
        Meanings = meanings;
    }

    public string Literal { get; set; }
    public int? JLPT { get; set; }
    public int? Frequency { get; set; }
    public int StrokeCount { get; set; }
    public string Kun { get; set; }
    public string On { get; set; }
    public string[] Meanings { get; set; }
    public string French
    {
        get
        {
            return string.Join(", ", Meanings);
        }
    }
}