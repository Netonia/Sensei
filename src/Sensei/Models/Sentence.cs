using WanaKanaNet;

namespace Sensei.Models;

public class Sentence
{
    public Sentence(string category, string meaning, string japanese)
    {
        Category = category;
        Meaning = meaning;
        Japanese = japanese;
        Romaji = WanaKana.ToRomaji(Japanese);
    }

    public string Category { get; set; }
    public string Meaning { get; set; }
    public string Japanese { get; set; }
    public string Romaji { get; set; }
}