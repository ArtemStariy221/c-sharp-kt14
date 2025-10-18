namespace App.Topics.LinkedList.T2b_DoubleLinkedList
{
    public class DoubleLinkedList<T> : System.Collections.Generic.IEnumerable<DoubleLinkedList<T>>
    {
        public T Value { get; }
        public DoubleLinkedList<T>? Prev { get; private set; }
        public DoubleLinkedList<T>? Next { get; private set; }

        public DoubleLinkedList(T value)
        {
            Value = value;
        }

        public int Count
        {
            get
            {
                int count = 0;

                foreach (var vasya in this)
                {
                    count++;
                }
                return count;
            }
        }

        public void AddBefore(T value)
        {

        }
        public void  AddAfter(T value)
        {
            var newNode = new DoubleLinkedList<T>(value)
            {
                Next = this.Next,
                Prev = this
            };

            if(this.Next != null)
                this.Next.Prev = newNode;
            
            this.Next = newNode;
        }


        public void addfirst(T value)
        {

        }
        public void addLast(T value)
        {

        }
        public T[] ToArray()
        {


            return new T[Count];
        }







        public System.Collections.Generic.IEnumerator<DoubleLinkedList<T>> GetEnumerator()
        {
  
            var golova = this;
            while (golova.Prev != null)
            {
                golova = golova.Prev;
            }

            var niz = golova;
            while (niz != null)
            {
                yield return niz;
                niz = niz.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}