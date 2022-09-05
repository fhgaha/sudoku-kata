using System.Collections.Generic;
using System.Linq;

namespace SudokuKata
{
    static class EnumerableExtensions
    {
        public static string Join(this IEnumerable<string> sequence, string separator) =>
            string.Join(separator, sequence.ToArray());
    }
}