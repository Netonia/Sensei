namespace Sensei.Models;

public class ApiTranslation
{
    public IList<Translations> Translations { get; set; }

}

public partial class Translations
{
    public string Text { get; set; }

    public string To { get; set; }
}