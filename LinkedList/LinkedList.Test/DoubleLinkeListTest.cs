using LinkedList;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;


namespace LinkedList.Test
{
    public class DoubleLinkeListTest
    {
        private DoubleLinkedList<string> dLink;

        [SetUp]
        public void Setup()
        {
            dLink = new DoubleLinkedList<string>();
        }

        [Test]
        public void FirstStepAfterInitialize()
        {
            Assert.IsTrue(dLink.Count == 0);
            Assert.IsTrue(dLink.isEmpty);
        }

        [Test]
        public void TestAddMethod()
        {
            dLink.Add("Dmitro");
            Assert.IsTrue(dLink.Count == 1);
            dLink.Add("Ivan");
            Assert.IsTrue(dLink.Count == 2);
        }

        [Test]
        public void TestAddMethodError()
        {
            Assert.Catch<ArgumentNullException>(() => dLink.Add(null));
        }

        [Test]
        public void TestRemoveMethodError()
        {
            Assert.Catch<ArgumentNullException>(() => dLink.Remove(null));
        }

        [Test]
        public void TestContainsMethos()
        {
            dLink.Add("Piter");
            dLink.Add("Anna");
            dLink.Add("Alex");
            DoubleNode<string> link1 = dLink.Contains("Piter");
            DoubleNode<string> link2 = dLink.Contains("Anna");
            DoubleNode<string> link3 = dLink.Contains("Alex");

            Assert.IsTrue(link1.Value == "Piter");
            Assert.IsTrue(link2.Value == "Anna");
            Assert.IsTrue(link3.Value == "Alex");

            Assert.IsTrue(link1.Prev == null);
            Assert.IsTrue(link1.Next == link2);
            Assert.IsTrue(link2.Prev == link1);
            Assert.IsTrue(link2.Next == link3);
            Assert.IsTrue(link3.Prev == link2);
            Assert.IsTrue(link3.Next == null);
        }

        [Test]
        public void TestValueArray()
        {
            dLink.Add("Mike");
            dLink.Add("Alex");

            CollectionAssert.IsNotEmpty(dLink.ValueArray());
            CollectionAssert.Contains(dLink.ValueArray(), "Mike");
            CollectionAssert.Contains(dLink.ValueArray(), "Alex");
        }


        [Test]
        public void TestContainsMethodError()
        {
            Assert.Catch<ArgumentNullException>(() => dLink.Contains(null));
        }


        [Test]
        public void TestRemoveEmpty()
        {
            dLink.Remove(String.Empty);
            Assert.IsFalse(dLink.Remove(String.Empty));
        }

        [Test]
        public void TestRemoveLastItem()
        {
            dLink.Add("Ivan");
            dLink.Add("Danila");
            dLink.Add("Alex");
            var beforeRemove = dLink.ValueArray();
            Assert.IsTrue(dLink.Remove("Alex"));
            var afterRemove = dLink.ValueArray();
            CollectionAssert.DoesNotContain(afterRemove, "Alex");
            CollectionAssert.Contains(afterRemove, "Ivan");
            CollectionAssert.Contains(afterRemove, "Danila");
            CollectionAssert.AreNotEquivalent(beforeRemove, afterRemove);
        }

        [Test]
        public void TestRemoveInnerItem()
        {
            dLink.Add("Ivan");
            dLink.Add("Danila");
            dLink.Add("Alex");
            var beforeRemove = dLink.ValueArray();
            Assert.IsTrue(dLink.Remove("Danila"));
            var afterRemove = dLink.ValueArray();
            CollectionAssert.DoesNotContain(afterRemove, "Danila");
            CollectionAssert.Contains(afterRemove, "Ivan");
            CollectionAssert.Contains(afterRemove, "Alex");
            CollectionAssert.AreNotEquivalent(beforeRemove, afterRemove);
        }

        [Test]
        public void TestRemoveFirstItem()
        {
            dLink.Add("Ivan");
            dLink.Add("Danila");
            dLink.Add("Alex");
            var beforeRemove = dLink.ValueArray();
            Assert.IsTrue(dLink.Remove("Ivan"));
            var afterRemove = dLink.ValueArray();
            CollectionAssert.DoesNotContain(afterRemove, "Ivan");
            CollectionAssert.Contains(afterRemove, "Danila");
            CollectionAssert.Contains(afterRemove, "Alex");
            CollectionAssert.AreNotEquivalent(beforeRemove, afterRemove);
        }

        [Test]
        public void TestRemoveFake()
        {
            var beforeRemove = dLink.ValueArray();
            Assert.IsFalse(dLink.Remove("Alex"));
            var afterRemove = dLink.ValueArray();
            CollectionAssert.AreEquivalent(beforeRemove, afterRemove);
        }
    }
}