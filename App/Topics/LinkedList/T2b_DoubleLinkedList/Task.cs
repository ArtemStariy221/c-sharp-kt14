namespace App.Topics.LinkedList.T2b_DoubleLinkedList
{
    public class DoubleLinkedList<T>
    {
        public T Value { get; }
        public DoubleLinkedList<T>? Prev { get; private set; }
        public DoubleLinkedList<T>? Next { get; private set; }

        public int Count
        {
            get
            {
                int count = 1;

                var left = Prev;
                while (left != null)
                {
                    count++;
                    left = left.Prev;
                }
                var right = Next;
                while (right != null)
                {
                    count++;
                    right = right.Next;
                }

                return count;
            }
        }

        public DoubleLinkedList(T value)
        {
            Value = value;
        }

        public void AddBefore(T value)
        {
            var newNode = new DoubleLinkedList<T>(value);
            newNode.Prev = Prev;
            newNode.Next = this;

            if (Prev != null)
            {
                Prev.Next = newNode;
            }
            Prev = newNode;
        }

        public void AddAfter(T value)
        {
            var newNode = new DoubleLinkedList<T>(value);

            newNode.Prev = this;
            newNode.Next = Next;

           
            if (Next != null)
            {
                Next.Prev = newNode;
            }
            Next = newNode;
        }

        public void AddFirst(T value)
        {
  
            var first = this;
            while (first.Prev != null)
            {
                first = first.Prev;
            }

            first.AddBefore(value);
        }

        public void AddLast(T value)
        {
  
            var last = this;
            while (last.Next != null)
            {
                last = last.Next;
            }

            last.AddAfter(value);
        }

        public T[] ToArray()
        {
            var first = this;
            while (first.Prev != null)
            {
                first = first.Prev;
            }
            var result = new System.Collections.Generic.List<T>();
            var current = first;
            while (current != null)
            {
                result.Add(current.Value);
                current = current.Next;
            }

            return result.ToArray();
        }
    }
}