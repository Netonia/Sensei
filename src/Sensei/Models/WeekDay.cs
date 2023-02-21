namespace Sensei.Models;

public class WeekDay
{
    public WeekDay(string day, string japanese, string romanisation, string element)
    {
        Day = day;
        Japanese = japanese;
        Romanisation = romanisation;
        Element = element;
    }

    public string Day { get; set; }
    public string Japanese { get; set; }
    public string Romanisation { get; set; }
    public string Element { get; set; }
}