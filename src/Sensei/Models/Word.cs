namespace Sensei.Models;

public class Word
{
    public Word(string category, string meaning, string kanji)
    {
        Category = category;
        Meaning = meaning;
        Japanese = kanji;
    }

    public Word(string category, string meaning, string kanji, string kana)
        : this(category, meaning, kanji)
    {
        Kana = kana;
    }

    public string Category { get; set; }
    public string Meaning { get; set; }
    public string Japanese { get; set; }
    public string Kana { get; set; }
    public string Romaji { get; set; }
}