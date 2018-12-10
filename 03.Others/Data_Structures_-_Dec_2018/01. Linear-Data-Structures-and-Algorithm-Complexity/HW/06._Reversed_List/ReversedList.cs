using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._Reversed_List
{
    public class ReversedList<T> : IEnumerable<T>
    {
        private const int InitalCapacity = 2;
        private const int ResizeMultiple = 2;
        private T[] collecion;

        public ReversedList()
        {
            this.collecion = new T[InitalCapacity];
        }

        public void Add(T item)
        {
            if (this.collecion.Length == this.Count)
            {
                this.Resize(this.Count * ResizeMultiple);
            }
            this.collecion[this.Count++] = item;
        }
             
        public int Capacity => this.collecion.Length;

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                this.Validate(index);
                return this.collection[this.ReversedIndex(index)];
            }

            set
            {
                this.Validate(index);
                this.collection[this.ReversedIndex(index)] = value;
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        private void Resize(int newCapacity)
        {
            var resizedCollection = new T[newCapacity];
            Array.Copy(this.collecion, resizedCollection, this.Count);
            this.collecion = resizedCollection;
        }
    }
}
