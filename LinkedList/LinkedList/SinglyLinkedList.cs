using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public sealed class SinglyLinkedList<T> : IEnumerable<T>
    {
        private SinglyNode<T> head;
        private int count;
        public int Count { get { return count; } }
        public bool isEmpty { get { return (count == 0); } }

        // Add item to end Linked List
        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException("This is not supported parameter");

            SinglyNode<T> _SinglyNode = new SinglyNode<T>(value);

            if (head == null)
            {
                head = _SinglyNode;
                _SinglyNode.list = this;
            }
            else
            {
                SinglyNode<T> SinglyNode = head;
                while (SinglyNode.Next != null)
                {
                    SinglyNode = SinglyNode.Next;
                }
                SinglyNode.Next = _SinglyNode;
                _SinglyNode.list = this;
            }
            count++;
        }

        //to check  whether value have in list
        public SinglyNode<T> Contains(T value)
        {
            if (value == null)
                throw new ArgumentNullException("This is not supported parameter");

            SinglyNode<T> SinglyNode = head;
            while (SinglyNode != null)
            {
                if (SinglyNode.Value.Equals(value))
                    return SinglyNode;
                SinglyNode = SinglyNode.Next;
            }
            return null;
        }


        // remove item of linked list
        public bool Remove(T Value)
        {
            if (Value == null)
                throw new ArgumentNullException("This is not supported parameter");

            if (isEmpty) return false;

            SinglyNode<T> prev = null;
            for (SinglyNode<T> SinglyNode = head; SinglyNode != null; SinglyNode = SinglyNode.Next)
            {
                if (SinglyNode.Value.Equals(Value))
                {
                    if (prev == null)
                    {
                        head = SinglyNode.Next;
                    }
                    else
                    {
                        prev.Next = SinglyNode.Next;
                    }
                    count--;
                    return true;
                }
                prev = SinglyNode;
            }
            return false;
        }

        // return array of values of linked list
        public T[] ValueArray()
        {
            if (count == 0)
                return Array.Empty<T>();

            SinglyNode<T> SinglyNode = head;
            T[] array = new T[count];
            int k = 0;
            while (SinglyNode != null)
            {
                if (SinglyNode.Value != null)
                    array[k] = SinglyNode.Value;
                SinglyNode = SinglyNode.Next;
                k++;
            }
            return array;
        }

        // for interation when  we use foreach; realize interface IEnumerable
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            SinglyNode<T> SinglyNode = head;
            while (SinglyNode != null)
            {
                yield return SinglyNode.Value;
                SinglyNode = SinglyNode.Next;
            }
        }

        // realize interface IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

    }
}
