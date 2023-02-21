namespace Sensei.Data;

// See https://github.com/kiidax/Meisuu/blob/master/Meisuu/JapaneseKansuuji.cs
public static class JapaneseKansuuji
{
    public const ulong UseArabicNumbers = 1 << 0;
    public const ulong UseDaijiNumbers = 1 << 1;

    private const string SuujiChars = "一二三四五六七八九";
    private const string SmallKuraiChars = "十百千";
    private static readonly decimal[] Pow10Values;
    private static readonly decimal[] Pow10000Values;
    private const string DaijiSuujiChars = "壱弐参";
    private const string DaijiSmallKuraiChars = "拾";
    private const string LargeKuraiChars = "万億兆京垓杼穣";
    private const char ZeroChar = '零';

    static JapaneseKansuuji()
    {
        Pow10Values = new decimal[3];
        decimal v = 1;
        for (int i = 0; i < Pow10Values.Length; i++)
        {
            v *= 10;
            Pow10Values[i] = v;
        }
        Pow10000Values = new decimal[7];
        v = 1;
        for (int i = 0; i < Pow10000Values.Length; i++)
        {
            v *= 10000;
            Pow10000Values[i] = v;
        }
    }

    /// <summary>
    /// Converts the Japanese Kansuuji representation of a number to decimal equivalent.
    /// </summary>
    /// <remarks>
    /// decimal.MaxValue is 79228162514264337593543950335 or about 7穣9千𥝱.
    /// Any greater or equal value than 1溝 throws an FormatException.
    /// Otherwise any greater value than decimal.MaxValue throws an OverflowException.
    /// Use of arabic characters like "9億" is not supported at the moment.
    /// Use of 大字 like "弐億" is not supported at the moment.
    /// </remarks>
    /// <param name="s">A string containing a number to convert.</param>
    /// <param name="style">The OR-ed styles of Kansuuji.</param>
    /// <returns>The result of conversion.</returns>
    /// <exception cref="ArgumentException">s is null</exception>
    /// <exception cref="FormatException">s is not in the correct format.</exception>
    /// <exception cref="OverflowException">s represents a number greater than decimal.MaxValue.</exception>
    public static decimal Parse(string s, ulong style)
    {
        decimal result;
        int endIndex;
        if (!TryParseInternal(s, style, out endIndex, out result)) throw new FormatException();
        if (s.Length != endIndex) throw new FormatException();
        return result;
    }

    /// <summary>
    /// Converts the Japanese Kansuuji representation of a number to decimal equivalent.
    /// </summary>
    /// <param name="s">A string containing a number to convert.</param>
    /// <param name="result">The result of conversion.</param>
    /// <returns>true if s was converted successfully; otherwise, false.</returns>
    public static bool TryParse(string s, ulong style, out decimal result)
    {
        int endIndex;
        if (!TryParse(s, style, out endIndex, out result)) return false;
        if (endIndex != s.Length) return false;
        return true;
    }

    /// <summary>
    /// Converts the Japanese Kansuuji representation of a number to decimal equivalent.
    /// </summary>
    /// <param name="s">A string containing a number to convert.</param>
    /// <param name="style">The OR-ed styles of Kansuuji.</param>
    /// <param name="endIndex"></param>
    /// <param name="result">The result of conversion.</param>
    /// <returns>true if s was converted successfully; otherwise, false.</returns>
    public static bool TryParse(string s, ulong style, out int endIndex, out decimal result)
    {
        try
        {
            return TryParseInternal(s, style, out endIndex, out result);
        }
        catch (OverflowException)
        {
            endIndex = 0;
            result = 0;
            return false;
        }
    }

    public static bool TryParseInternal(string s, ulong style, out int endIndex, out decimal result)
    {
        if (s == null) throw new ArgumentNullException();
        if ((style & UseArabicNumbers) != 0) throw new NotSupportedException();
        if ((style & UseDaijiNumbers) != 0) throw new NotSupportedException();
        endIndex = 0;
        result = 0;
        if (s.Length > 0 && s[0] == ZeroChar)
        {
            endIndex = 1;
            return true;
        }
        decimal underKuraiValue = 0;
        decimal smallKuraiValue = 0;
        decimal largeKuraiValue = 0;
        int i;
        for (i = 0; i < s.Length; i++)
        {
            char ch = s[i];
            int index = SuujiChars.IndexOf(ch);
            if (index != -1)
            {
                if (underKuraiValue != 0) return false; // We have already had a suuji char.
                underKuraiValue = (decimal)index + 1;
                continue;
            }
            index = SmallKuraiChars.IndexOf(ch);
            if (index != -1)
            {
                if (underKuraiValue == 0) underKuraiValue = 1; // If we haven't have a suuji char, then it is one.
                if (smallKuraiValue != 0 && smallKuraiValue < Pow10Values[index]) return false; // We already have bigger small-kurai.
                smallKuraiValue += Pow10Values[index] * underKuraiValue;
                underKuraiValue = 0;
                continue;
            }
            index = LargeKuraiChars.IndexOf(ch);
            if (index != -1)
            {
                smallKuraiValue += underKuraiValue;
                underKuraiValue = 0;
                if (smallKuraiValue == 0) return false;
                largeKuraiValue += Pow10000Values[index] * smallKuraiValue;
                smallKuraiValue = 0;
                continue;
            }
            break;
        }

        if (i == 0) return false;
        smallKuraiValue += underKuraiValue;
        largeKuraiValue += smallKuraiValue;
        result = largeKuraiValue;
        endIndex = i;
        return true;
    }
}