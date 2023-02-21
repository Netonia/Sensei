namespace Sensei.Data;

public static class RandomSampleExtensions
{
    public static IEnumerable<T> RandomSample<T>(this IEnumerable<T> source, int count, bool allowDuplicates)
    {
        if (source == null) throw new ArgumentNullException("source");

        return RandomSampleIterator<T>(source, count, -1, allowDuplicates);
    }

    public static IEnumerable<T> RandomSample<T>(this IEnumerable<T> source, int count, int seed, bool allowDuplicates)
    {
        if (source == null) throw new ArgumentNullException("source");

        return RandomSampleIterator<T>(source, count, seed, allowDuplicates);
    }

    static IEnumerable<T> RandomSampleIterator<T>(IEnumerable<T> source, int count, int seed, bool allowDuplicates)
    {
        // take a copy of the current list
        List<T> buffer = new List<T>(source);

        // create the "random" generator, time dependent or with the specified seed
        Random random;
        if (seed < 0)
        {
            random = new Random();
        }
        else
        {
            random = new Random(seed);
        }

        count = Math.Min(count, buffer.Count);

        if (count > 0)
        {
            // iterate count times and "randomly" return one of the  elements
            for (int i = 1; i <= count; i++)
            {
                // maximum index actually buffer.Count -1 because Random.Next will only return values LESS than specified.
                int randomIndex = random.Next(buffer.Count);
                yield return buffer[randomIndex];
                if (!allowDuplicates)
                {
                    // remove the element so it can't be selected a second time
                    buffer.RemoveAt(randomIndex);
                }
            }
        }
    }
}