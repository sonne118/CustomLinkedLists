using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public sealed class DoubleNode<T>
    {
        public T Value { get; set; }

        public DoubleLinkedList<T> list { get; set; }
        public DoubleNode<T> Next { get; set; }
        public DoubleNode<T> Prev { get; set; }

        public DoubleNode(T v)
        {
            Value = v;
            Next = null;
            Prev = null;
        }

    }
}
