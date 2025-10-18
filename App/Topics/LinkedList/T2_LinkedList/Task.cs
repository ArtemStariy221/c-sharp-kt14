using System;
using System.Collections.Generic;

namespace App.Topics.LinkedList.T2_LinkedList
{
    public static class LinkedListTasks
    {
        public static System.Collections.Generic.LinkedList<int> RemoveDuplicates(System.Collections.Generic.LinkedList<int> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (list.Count <= 1)
            {
                return new LinkedList<int>(list);
            }

            HashSet<int> seen = new HashSet<int>();
            LinkedList<int> result = new LinkedList<int>();


            foreach (int value in list)
            {
                if (seen.Add(value))
                {
                    result.AddLast(value);
                }
            }

            return result;
        }
    }
}