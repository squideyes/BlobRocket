using System.Collections.Generic;
using System.Linq;

namespace BlobRocket.Uploader.Generics
{
    public static class StringExtenders
    {
        public static List<string> ToWrappedLines(this string text, int maxWidth)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(text), nameof(text));
            Contract.Requires(maxWidth > 1 && maxWidth <= 80, nameof(maxWidth));

            var words = text.Split(' ');

            var lines = words.Skip(1).Aggregate(words.Take(1).ToList(),
                (line, word) =>
                {
                    if (line.Last().Length + word.Length >= maxWidth)
                        line.Add(word);
                    else
                        line[line.Count - 1] += " " + word;

                    return line;
                });

            return lines.Select(l=> l.Trim()).ToList();
        }
    }
}
