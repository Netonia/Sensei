namespace Sensei.Data;

public class Spelling
{
    public Spelling(string syllab, string japanese, string spell, string meaning)
    {
        Syllab = syllab;
        Japanese = japanese;
        Spell = spell;
        Meaning = meaning;
    }

    public string Syllab { get; set; }
    public string Japanese { get; set; }
    public string Spell { get; set; }
    public string Meaning { get; set; }
}