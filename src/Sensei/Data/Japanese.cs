using System.Globalization;
using MyNihongo.KanaConverter;
using WanaKanaNet;

namespace Sensei.Data;

public static class Japanese
{
    public static string CultureName = "ja-JP";
    public static CultureInfo CultureInfo = new CultureInfo(CultureName) { DateTimeFormat = { Calendar = new JapaneseCalendar() } };

    public static string ConvertToJapanese(DateTime date)
    {
        var result = string.Empty;
        var year = date.Year;
        var month = date.Month;
        var day = date.Day;
        var hour = date.Hour;
        var minute = date.Minute;
        var second = date.Second;

        if (year > 0)
            result += $"{year}年";

        if (month > 0)
            result += $"{month}月";

        if (day > 0)
            result += $"{day}日";

        if (hour > 0)
            result += $"{hour}時";

        if (minute > 0)
            result += $"{minute}分";

        if (second > 0)
            result += $"{second}秒";

        return result;
    }

    public static int GetJapaneseYear(DateTime d)
    {
        var calendar = new JapaneseCalendar();

        return calendar.GetYear(d);
    }

    public static string GetJapaneseDate(DateTime date)
    {
        string result = string.Empty;
        var calendar = new JapaneseCalendar();
        result = date.ToString("ggyy年MM月dd日", CultureInfo);

        return result;
    }

    public static string[] SplitSounds(string romaji)
    {
        var sounds = new List<string>();
        // ToHiragana, then split and finally each syllab back ToRomaji
        var hiragana = WanaKana.ToHiragana(romaji);
        var syllabs = hiragana.ToCharArray();
        foreach (var syllab in syllabs)
        {
            var sound = syllab.ToString().ToRomaji();
            sounds.Add(sound);
        }

        return sounds.ToArray();
    }
}