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

            SinglyNode<T> newNode = new SinglyNode<T>(value);

            if (head == null)
            {
                head = newNode;
                newNode.list = this;
            }
            else
            {
                SinglyNode<T> node = head;
                while (node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = newNode;
                newNode.list = this;
            }
            count++;
        }

        //to check  whether value have in list
        public SinglyNode<T> Contains(T value)
        {
            if (value == null)
                throw new ArgumentNullException("This is not supported parameter");

            SinglyNode<T> node = head;
            while (node != null)
            {
                if (node.Value.Equals(value))
                    return node;
                node = node.Next;
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
            for (SinglyNode<T> node = head; node != null; node = node.Next)
            {
                if (node.Value.Equals(Value))
                {
                    if (prev == null)
                    {
                        head = node.Next;
                    }
                    else
                    {
                        prev.Next = node.Next;
                    }
                    count--;
                    return true;
                }
                prev = node;
            }
            return false;
        }

        // return array of values of linked list
        public T[] ValueArray()
        {
            if (count == 0)
                return Array.Empty<T>();

            SinglyNode<T> node = head;
            T[] array = new T[count];
            int k = 0;
            while (node != null)
            {
                array[k] = node.Value;
                node = node.Next;
                k++;
            }
            return array;
        }

        // for interation when  we use foreach; realize interface IEnumerable
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            SinglyNode<T> node = head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        // realize interface IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

    }
}
