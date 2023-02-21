using System.Text.RegularExpressions;

namespace Sensei.Data;

// https://github.com/sebpearce/kazu/blob/gh-pages/kazu.js
public class Numbers
{
    public static readonly int[] ArabicNumbers = new[]
    {
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9
    };

    public static readonly Dictionary<int, string> ArabicToRomaji = new Dictionary<int, string>()
    {
        {0, "rei"}, {1, "ichi"}, {2, "ni"}, {3, "san"}, {4, "yon"}, {5, "go"}, {6, "roku"}, {7, "nana"}, {8, "hachi"}, {9, "kyuu"},
        {10, "juu"}, {100, "hyaku"}, {1000, "sen"}, {10000, "man"}, {100000000, "oku"},
        {300, "sanbyaku"}, {600, "roppyaku"}, {800, "happyaku"}, {3000, "sanzen"}, {8000, "hassen"}
    };
    //{1000000000000, "chou"}, {10000000000000000, "kei"},

    public static readonly Dictionary<int, string> ArabicToHiragana = new Dictionary<int, string>()
    {
        {0, "れい"}, {1, "いち"}, {2, "に"}, {3, "さん"}, {4, "よん"}, {5, "ご"}, {6, "ろく"}, {7, "なな"}, {8, "はち"}, {9, "きゅう"},
        {10, "じゅう"}, {100, "ひゃく"}, {1000, "せん"}, {10000, "まん"}, {100000000, "おく"},
        {300, "さんびゃく"}, {600, "ろっぴゃく"}, {800, "はっぴゃく"}, {3000, "さんぜん"}, {8000, "はっせん"}
    };
    //{1000000000000, "ちょう"}, {10000000000000000, "けい"},

    public static readonly Dictionary<int, string> ArabicToKanji = new Dictionary<int, string>()
    {
        {0, "零"}, {1, "一"}, {2, "二"}, {3, "三"}, {4, "四"}, {5, "五"}, {6, "六"}, {7, "七"}, {8, "八"}, {9, "九"},
        {10, "十"}, {100, "百"}, {1000, "千"}, {10000, "万"}, {100000000, "億"},
        {300, "三百"}, {600, "六百"}, {800, "八百"}, {3000, "三千"}, {8000, "八千"}
    };

    private static double[] japanesePlaces = new[] {
      Math.Pow(10, 12), //chou
      Math.Pow(10, 8), //oku
      Math.Pow(10, 4), //man
      Math.Pow(10, 3), //sen
      Math.Pow(10, 2), //hyaku
      Math.Pow(10, 1), //juu
      Math.Pow(10, 0) //(units)
    };

    public static readonly Dictionary<int, string> ArabicToRomajiKun = new Dictionary<int, string>()
    {
        {1, "hito(tsu)"}, {2, "futa(tsu)"}, {3, "mit(tsu)"}, {4, "yot(tsu)"}, {5, "itsu(tsu)"}, {6, "mut(tsu)"}, {7, "nana(tsu) "}, {8, "yat(tsu)"}, {9, "kokono(tsu)"},
        {10, "tō"}, {100, "momo"}, {1000, "chi"}, {10000, "yorozu"}
    };

    public static readonly Dictionary<int, string> ArabicToKun = new Dictionary<int, string>()
    {
        {1, "ひと・つ"}, {2, "ふた・つ"}, {3, "みっ・つ"}, {4, "よん、よっ・つ"}, {5, "いつ・つ"}, {6, "むっ・つ"}, {7, "なな・つ"}, {8, "やっ・つ"}, {9, "ここの・つ"},
        {10, "とお"}, {100, "もも"}, {1000, "ち"}, {10000, "よろず"}
    };

    public static readonly Dictionary<int, string> ArabicToRomajiOn = new Dictionary<int, string>()
    {
        {0, "rei"}, {1, "ichi"}, {2, "ni"}, {3, "san"}, {4, "shi"}, {5, "go"}, {6, "roku"}, {7, "shichi"}, {8, "hachi"}, {9, "kyū"},
        {10, "jū"}, {100, "hyaku"}, {1000, "sen"}, {10000, "man"}, {100000000, "oku"}, {800, "happyaku"}
    };

    public static readonly Dictionary<int, string> ArabicToOn = new Dictionary<int, string>()
    {
        {0, "れい"}, {1, "いち"}, {2, "に"}, {3, "し"}, {4, "よん"}, {5, "ご"}, {6, "ろく"}, {7, "しち"}, {8, "はち"}, {9, "く"},
        {10, "じゅう"}, {100, "ひゃく"}, {1000, "せん"}, {10000, "まん"}, {100000000, "おく"},
        {800, "はっぴゃく"}
    };

    private static string[] kanjiList = new[] { "兆", "億", "万", "千", "百", "十" };

    private static string[] ones = new[] { "", "man", "oku", "chou" };

    public static string GenerateJapaneseDigits(int num, int lowestKanjiPlace)
    {
        var chk = num;
        var result = "";
        var factor = 0;

        if (num == 0)
        {
            return "0";
        }

        while (chk > 0)
        {
            // start with 兆 and iterate upward through the jap_places array
            for (var i = 0; i < japanesePlaces.Length; i++)
            {
                // e.g. if 700万 > 1万
                if (chk >= japanesePlaces[i])
                {
                    // find how many times bigger chk is than its next-highest place
                    factor = (int)Math.Floor(chk / japanesePlaces[i]);

                    // if we"re still above lowestKanjiLimit: the lowest number you"ll see a kanji used for – usually 10000 (万)...
                    if (chk >= lowestKanjiPlace)
                    {
                        // add the factor then the kanji
                        result += factor.ToString() + kanjiList[i];
                        // subtract the place value (e.g.1万) from number
                        chk -= (int)(factor * japanesePlaces[i]);
                        break;
                    }
                    else
                    {
                        // otherwise just add the rest
                        result += chk;
                        chk = 0;
                        break;
                    }
                }
            }
        }

        return result;
    }

    public static string GenerateRawReading(int number)
    {
        if (number == 0)
        {
            return "zero";
        }

        var reading = "";

        var s = number.ToString();

        s = Regex.Replace(s, @"/[\, ]", ""); // ignore commas

        if (!decimal.TryParse(s, out var _)) return "not a number";

        var x = s.Length;
        if (x > 16) return "too big";
        int[] n = s.Where(x => char.IsNumber(x)).Select(x => x - 48).ToArray();
        var check = false;
        var pos = 0;

        // cycle through each digit from the left
        for (var i = 0; i < x; i++)
        {
            pos = ((x - i) % 4); // pos = position (tens, hundreds, thousands, ones)

            // is it in the TENS position?
            if (pos == 2)
            {
                // if it's 1, add "juu"
                if (n[i] == 1)
                {
                    reading += "juu ";
                    check = true;
                }
                else if (n[i] != 0)
                {
                    reading += (ArabicToRomaji[n[i]] + " juu ");
                    check = true;
                }
            }

            // is it in the HUNDREDS position?
            if (pos == 3)
            {
                // if it's 1, add "hyaku"
                if (n[i] == 1)
                {
                    reading += "hyaku ";
                    check = true;
                }
                // if it's not 0, add the word
                else if (n[i] != 0)
                {
                    reading += (ArabicToRomaji[n[i]] + " hyaku ");
                    check = true;
                }
            }

            // is it in the THOUSANDS position?
            if (pos == 0)
            {
                // if it"s 1, add "issen"
                if (n[i] == 1)
                {
                    reading += "issen ";
                    check = true;
                }
                // if it's not 0, add the word
                else if (n[i] != 0)
                {
                    reading += (ArabicToRomaji[n[i]] + " sen ");
                    check = true;
                }
            }

            // is it in the ONES/MANS/OKUS/CHOUS position?
            if (pos == 1)
            {
                var type = (x - i - 1) / 4; // this will give 0, 1, 2 or 3 ("","万","億" or "兆")
                                            //if it"s not 0, add the corresponding word            
                if (n[i] != 0)
                {
                    check = true;
                    // if digit is a 1
                    if (n[i] == 1)
                    {
                        // if it's in "man" or "oku" position, write "ichi" first
                        if (type == 1 || type == 2)
                        {
                            reading += "ichi " + ones[type] + " ";
                            check = false;
                        }
                        //if it's "chou", write "itchou"
                        else if (type == 3)
                        {
                            reading += "itchou ";
                            check = false;
                        }
                        else
                        {
                            reading += "ichi"; //it must be 1
                            check = false;
                        }
                    }
                    // for other non-zero digits, add the digit and corresponding word depending on its position
                    else
                    {
                        reading += ArabicToRomaji[n[i]] + " " + ones[type] + " ";
                        check = false;
                    }
                }
                else if (check)
                {
                    // if digit is 0 and check = 1, i.e. if there are tens/hunds/thous to the left of this, just add the corresponding word without a digit preceding it
                    reading += ones[type] + " ";
                    check = false;
                }
            }
        }

        reading = reading.Trim();
        return reading;
    }

    public static string GenerateRomajiReading(string reading, int num)
    {
        // if input has 4 chars & first word is "issen", change to "sen"
        if (num < 2000)
        {
            reading = Regex.Replace(reading, @"^issen", "sen");
        }
        reading = Regex.Replace(reading, @"^sen man", "issen man");
        reading = Regex.Replace(reading, @"^sen oku", "issen oku");
        reading = Regex.Replace(reading, @"^sen chou", "issen chou");

        reading = Regex.Replace(reading, @"san hyaku", ArabicToRomaji[300]); // "sanbyaku");
        reading = Regex.Replace(reading, @"roku hyaku", ArabicToRomaji[600]); // "roppyaku");
        reading = Regex.Replace(reading, @"hachi hyaku", ArabicToRomaji[800]); // "happyaku");
        reading = Regex.Replace(reading, @"san sen", ArabicToRomaji[3000]); // "sanzen");
        reading = Regex.Replace(reading, @"hachi sen", ArabicToRomaji[8000]); // "hassen");
        reading = Regex.Replace(reading, @"juu chou", "jutchou");

        return reading.Trim();
    }

    public static string GenerateHiraganaReading(string reading, int num)
    {
        reading = Regex.Replace(reading, @"issen man", "いっせん まん");
        reading = Regex.Replace(reading, @"issen oku", "いっせん おく");
        reading = Regex.Replace(reading, @"issen chou", "いっせん ちょう");

        // if input is 1999 or less & first word is "issen", change to "sen"
        if (num < 2000)
        {
            reading = Regex.Replace(reading, @"issen", "せん");
        }

        reading = Regex.Replace(reading, @"issen", "いっせん");

        // rReplace weird readings
        reading = Regex.Replace(reading, @"san hyaku", ArabicToHiragana[300]); // "さんびゃく");
        reading = Regex.Replace(reading, @"roku hyaku", ArabicToHiragana[600]); // "ろっぴゃく");
        reading = Regex.Replace(reading, @"hachi hyaku", ArabicToHiragana[800]); // "はっぴゃく");
        reading = Regex.Replace(reading, @"san sen", ArabicToHiragana[3000]); // "さんぜん");
        reading = Regex.Replace(reading, @"hachi sen", ArabicToHiragana[8000]); // "はっせん");
        reading = Regex.Replace(reading, @"itchou", "いっちょう"); // 10 pow 12
        reading = Regex.Replace(reading, @"juu chou", "じゅっちょう"); // 10 pow 13

        // convert regular words to hiragana
        reading = Regex.Replace(reading, ArabicToRomaji[0], ArabicToHiragana[0]); // "れい");
        reading = Regex.Replace(reading, ArabicToRomaji[1], ArabicToHiragana[1]); // "いち");
        reading = Regex.Replace(reading, ArabicToRomaji[2], ArabicToHiragana[2]); // "に");
        reading = Regex.Replace(reading, ArabicToRomaji[3], ArabicToHiragana[3]); // "さん");
        reading = Regex.Replace(reading, ArabicToRomaji[4], ArabicToHiragana[4]); // "よん");
        reading = Regex.Replace(reading, ArabicToRomaji[5], ArabicToHiragana[5]); // "ご");
        reading = Regex.Replace(reading, ArabicToRomaji[6], ArabicToHiragana[6]); // "ろく");
        reading = Regex.Replace(reading, ArabicToRomaji[7], ArabicToHiragana[7]); // "なな");
        reading = Regex.Replace(reading, ArabicToRomaji[8], ArabicToHiragana[8]); // "はち");
        reading = Regex.Replace(reading, ArabicToRomaji[9], ArabicToHiragana[9]); // "きゅう");

        reading = Regex.Replace(reading, ArabicToRomaji[10], ArabicToHiragana[10]); // "じゅう");
        reading = Regex.Replace(reading, @"hyaku", ArabicToHiragana[100]); // "ひゃく");
        reading = Regex.Replace(reading, @"sen", ArabicToHiragana[1000]); // "せん");
        reading = Regex.Replace(reading, @"man", ArabicToHiragana[10000]); // "まん");
        reading = Regex.Replace(reading, @"oku", ArabicToHiragana[100000000]); // "おく");
        reading = Regex.Replace(reading, @"chou", "ちょう"); // 1000000000000

        return reading;
    }

    public static string GenerateTraditionalJapaneseReading(string reading, int num)
    {
        reading = Regex.Replace(reading, @"issen man", "一千万");
        reading = Regex.Replace(reading, @"issen oku", "一千億");
        reading = Regex.Replace(reading, @"issen chou", "一千兆");

        // if input is 1999 or less & first word is "issen", change to "sen"
        if (num < 2000)
        {
            reading = Regex.Replace(reading, @"^issen", "千");
        }
        reading = Regex.Replace(reading, @"issen", "一千");

        // reading = reading.Replace(/^sen man/g,"一千万");
        // reading = reading.Replace(/^sen oku/g,"一千億");
        // reading = reading.Replace(/^sen chou/g,"一千兆");

        reading = Regex.Replace(reading, ArabicToRomaji[0], ArabicToKanji[0]); // "零");
        reading = Regex.Replace(reading, ArabicToRomaji[1], ArabicToKanji[1]); // "一");
        reading = Regex.Replace(reading, ArabicToRomaji[2], ArabicToKanji[2]); // "二");
        reading = Regex.Replace(reading, ArabicToRomaji[3], ArabicToKanji[3]); // "三");
        reading = Regex.Replace(reading, ArabicToRomaji[4], ArabicToKanji[4]); // "四");
        reading = Regex.Replace(reading, ArabicToRomaji[5], ArabicToKanji[5]); // "五");
        reading = Regex.Replace(reading, ArabicToRomaji[6], ArabicToKanji[6]); // "六");
        reading = Regex.Replace(reading, ArabicToRomaji[7], ArabicToKanji[7]); // "七");
        reading = Regex.Replace(reading, ArabicToRomaji[8], ArabicToKanji[8]); // "八");
        reading = Regex.Replace(reading, ArabicToRomaji[9], ArabicToKanji[9]); // "九");
        reading = Regex.Replace(reading, ArabicToRomaji[10], ArabicToKanji[10]); // "十");
        reading = Regex.Replace(reading, @"hyaku", ArabicToKanji[100]); // "百");
        reading = Regex.Replace(reading, @"sen", ArabicToKanji[1000]); // "千");
        reading = Regex.Replace(reading, @"man", ArabicToKanji[10000]); // "万");
        reading = Regex.Replace(reading, @"oku", ArabicToKanji[100000000]); //  "億");
        reading = Regex.Replace(reading, @"chou", "兆"); // 10 pow 12
        reading = Regex.Replace(reading, @"itchou", "一兆"); // 10 pow 12

        reading = reading.Replace(" ", "");

        return reading;
    }
}