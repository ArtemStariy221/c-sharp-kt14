using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace App.Topics.Collections.T1_Collections
{
    public static class CollectionsTasks
    {
        public static ArrayList FilterUniqueStringsNonGeneric(IEnumerable source)
        {
            ArrayList result = new ArrayList();
            HashSet<string> seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var item in source)
            {
                if (item is string str)
                {
                    string trimmed = str.Trim();

                    // ѕропускаем пустые строки после Trim()
                    if (string.IsNullOrEmpty(trimmed))
                        continue;

                    // ѕровер€ем, встречалась ли уже така€ строка (case-insensitive)
                    if (!seen.Contains(trimmed))
                    {
                        seen.Add(trimmed);
                        result.Add(trimmed);
                    }
                }
            }

            return result;
        }

        public static List<string> FilterUniqueStringsGeneric(IEnumerable<string> source)
        {
            List<string> result = new List<string>();
            HashSet<string> seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (string str in source)
            {
                string trimmed = str.Trim();

                // ѕропускаем пустые строки после Trim()
                if (string.IsNullOrEmpty(trimmed))
                    continue;

                // ѕровер€ем, встречалась ли уже така€ строка (case-insensitive)
                if (!seen.Contains(trimmed))
                {
                    seen.Add(trimmed);
                    result.Add(trimmed);
                }
            }

            return result;
        }
    }
}