using System;
using System.Collections.Generic;

namespace App.Topics.LinkedList.T2_LinkedList
{
    public static class LinkedListTasks
    {
        public static LinkedList<int> RemoveDuplicates(LinkedList<int> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (list.Count == 0)
                return new LinkedList<int>();

            HashSet<int> seen = new HashSet<int>();
            LinkedList<int> result = new LinkedList<int>();

            foreach (int value in list)
            {
                if (!seen.Contains(value))
                {
                    seen.Add(value);
                    result.AddLast(value);
                }
            }

            return result;
        }
    }
}