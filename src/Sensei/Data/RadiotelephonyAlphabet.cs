namespace Sensei.Data;

public class RadiotelephonyAlphabet
{
    // Name no "syllab"
    public static readonly List<Spelling> Kana = new List<Spelling>()
    {
         new Spelling("a", "朝日", "Asahi", "Morning sun"),
         new Spelling("i", "朝日", "Iroha", "Japanese poem"),
         new Spelling("u", "上野", "Ueno", "District in Tokyo"),
         new Spelling("e", "英語", "Eigo", "English"),
         new Spelling("o", "大阪", "Ōsaka", "Ōsaka city"),
         new Spelling("ka", "為替", "Kawase", "Trade"),
         new Spelling("ki", "切手", "Kitte", "Postage stamp"),
         new Spelling("ku", "クラブ", "Kurabu", "Club"),
         new Spelling("ke", "景色", "Keshiki", "Landscape"),
         new Spelling("ko", "子供", "Kodomo", "Child"),
         new Spelling("sa", "桜", "Sakura", "Cherry blossom"),
         new Spelling("shi", "新聞", "Shinbun ", "Newspaper"),
         new Spelling("su", "すずめ", "Suzume", "Eurasian tree sparrow"),
         new Spelling("se", "世界", "Sekai", "World"),
         new Spelling("so", "そろばん", "Soroban ", "Abacus"),
         new Spelling("ta", "煙草", "Tabako", "Tobacco"),
         new Spelling("chi", "千鳥", "Chidori", "Plover"),
         new Spelling("tsu", "つるかめ", "Tsurukame", "Turtle"),
         new Spelling("te", "手紙", "Tegami", "Letter"),
         new Spelling("to", "東京", "Tōkyō", "Tōkyō (eastern capital)"),
         new Spelling("na", "名古", "Nagoya", "Nagoya city"),
         new Spelling("ni", "日本", "Nippon", "Japan (country of the rising sun)"),
         new Spelling("nu", "沼津", "Numazu", "Numazu city"),
         new Spelling("ne", "ねずみ", "Nezumi", "Mouse"),
         new Spelling("no", "野原", "Nohara", "Plain"),
         new Spelling("ha", "はがき", "Hagaki", "Postcard"),
         new Spelling("hi", "飛行機", "Hikōki", "Aircraft"),
         new Spelling("fu", "富士山", "Fujisan", "Mount Fuji"),
         new Spelling("he", "平和", "Heiwa", "Peace"),
         new Spelling("ho", "保険", "Hoken", "Insurance"),
         new Spelling("ma", "マッチ", "Matchi", "Match"),
         new Spelling("mi", "三笠", "Mikasa", "Mikasa city"),
         new Spelling("mu", "無線", "Musen", "Radio"),
         new Spelling("me", "明治", "Meiji", "Meiji era"),
         new Spelling("mo", "もみじ", "Momiji", "Maple"),
         new Spelling("ya", "大和", "Yamato", "Yamato period"),
         new Spelling("yu", "弓矢", "Yumiya", "Bow and arrow"),
         new Spelling("yo", "吉野", "Yoshino", "Yoshino city"),
         new Spelling("ra", "ラジオ", "Rajio", "Radio"),
         new Spelling("ri", "りんご", "Ringo", "Apple"),
         new Spelling("ru", "留守居", "Rusui", "Caretaker"),
         new Spelling("re", "れんげ", "Renge", "Lotus flower"),
         new Spelling("ro", "ローマ", "Rōma", "Rome"),
         new Spelling("wa", "わらび", "Warabi", "Bracken"),
         new Spelling("wi", "ゐど", "(W)ido", "Well"),
         new Spelling("wo", "尾張", "(W)owari", "Owari Province"),
         new Spelling("n", "おしまい", "Oshimai", "The End")
    };

    // Sūji no
    public static readonly List<Spelling> Numerals = new List<Spelling>()
    {
         new Spelling("0", "まる", "maru", "Circle"),
         new Spelling("1", "ひと", "hito", "People"),
         new Spelling("2", "に", "ni", "At"),
         new Spelling("3", "さん", "san", "Honorific title"),
         new Spelling("4", "よん", "yon", "Four"),
         new Spelling("5", "ご", "go", "Go game"),
         new Spelling("6", "ろく", "roku", "Six"),
         new Spelling("7", "なな", "nana", "Seven"),
         new Spelling("8", "はち", "hachi", "Bee"),
         new Spelling("9", "きゅう", "kyū", "Nine")
    };
}