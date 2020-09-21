using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public sealed class SinglyNode<T>
    {
        public T Value { get; set; }
        public SinglyLinkedList<T> list { get; set; }
        public SinglyNode<T> Next { get; set; }

        public SinglyNode(T v)
        {
            Value = v;
            Next = null;
        }

    }
}
