using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public sealed class DoubleLinkedList<T> : IEnumerable<T>
    {
        private DoubleNode<T> head;
        private int count;
        public int Count { get { return count; } }
        public bool isEmpty { get { return (count == 0); } }

        // Add item to end Linked List
        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException("This is not supported parameter");

            DoubleNode<T> newNode = new DoubleNode<T>(value);
          
            if (head == null)
            {              
                head = newNode;
                newNode.list = this;
            }
            else
            {
                DoubleNode<T> node = head;
                while (node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = newNode;
                newNode.Prev = node;
                newNode.list = this; // you can check  Which owns this Node?
            }                      // It can be used  after return result of Contain method
            count++;
        }

        //to check   whether value exists in list
        public DoubleNode<T> Contains(T value)
        {
            if (value == null)
                throw new ArgumentNullException("This is not supported parameter");

            DoubleNode<T> node = head;
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

            DoubleNode<T> prev = null;
            for (DoubleNode<T> node = head; node != null; node = node.Next)
            {
                if (node.Value.Equals(Value))
                {
                    if (prev == null)
                    {
                        node.Prev = null;
                        head = node.Next;
                    }
                    else if (node.Next == null)
                    {
                        node.Prev.Next = null;
                    }
                    else
                    {
                        node.Next.Prev = node.Prev;
                        node.Prev.Next = node.Next;
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

            DoubleNode<T> node = head;
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
            DoubleNode<T> node = head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        // implement interface IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

    }
}
