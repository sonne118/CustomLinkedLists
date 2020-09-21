using LinkedList;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;


namespace LinkedList.Test
{
    public class SinglyLinkeListTest
    {
        private SinglyLinkedList<string> sLink;

        [SetUp]
        public void Setup()
        {
            sLink = new SinglyLinkedList<string>();
        }

        [Test]
        public void FirstStepAfterInitialize()
        {
            Assert.IsTrue(sLink.Count == 0);
            Assert.IsTrue(sLink.isEmpty);
        }

        [Test]
        public void TestAddMethod()
        {
            sLink.Add("Dmitro");
            Assert.IsTrue(sLink.Count == 1);
            sLink.Add("Ivan");
            Assert.IsTrue(sLink.Count == 2);
        }

        [Test]
        public void TestAddMethodError()
        {
            Assert.Catch<ArgumentNullException>(() => sLink.Add(null));
        }

        [Test]
        public void TestRemoveMethodError()
        {
            Assert.Catch<ArgumentNullException>(() => sLink.Remove(null));
        }

        [Test]
        public void TestContainsMethos()
        {
            sLink.Add("Piter");
            sLink.Add("Anna");
            SinglyNode<string> link1 = sLink.Contains("Piter");
            SinglyNode<string> link2 = sLink.Contains("Anna");
            Assert.IsTrue(link1.Value == "Piter");
            Assert.IsTrue(link2.Value == "Anna");
            Assert.IsTrue(link1.Next == link2);
        }

        [Test]
        public void TestValueArray()
        {
            sLink.Add("Mike");
            sLink.Add("Alex");

            CollectionAssert.IsNotEmpty(sLink.ValueArray());
            CollectionAssert.Contains(sLink.ValueArray(), "Mike");
            CollectionAssert.Contains(sLink.ValueArray(), "Alex");
        }


        [Test]
        public void TestContainsMethodError()
        {
            Assert.Catch<ArgumentNullException>(() => sLink.Contains(null));
        }


        [Test]
        public void TestRemoveEmpty()
        {
            sLink.Remove(String.Empty);
            Assert.IsFalse(sLink.Remove(String.Empty));
        }


        [Test]
        public void TestRemoveLastItem()
        {
            sLink.Add("Ivan");
            sLink.Add("Danila");
            sLink.Add("Alex");
            var beforeRemove = sLink.ValueArray();
            Assert.IsTrue(sLink.Remove("Alex"));
            var afterRemove = sLink.ValueArray();
            CollectionAssert.DoesNotContain(afterRemove, "Alex");
            CollectionAssert.Contains(afterRemove, "Ivan");
            CollectionAssert.Contains(afterRemove, "Danila");
            CollectionAssert.AreNotEquivalent(beforeRemove, afterRemove);
        }

        [Test]
        public void TestRemoveInnerItem()
        {
            sLink.Add("Ivan");
            sLink.Add("Danila");
            sLink.Add("Alex");
            var beforeRemove = sLink.ValueArray();
            Assert.IsTrue(sLink.Remove("Danila"));
            var afterRemove = sLink.ValueArray();
            CollectionAssert.DoesNotContain(afterRemove, "Danila");
            CollectionAssert.Contains(afterRemove, "Ivan");
            CollectionAssert.Contains(afterRemove, "Alex");
            CollectionAssert.AreNotEquivalent(beforeRemove, afterRemove);
        }

        [Test]
        public void TestRemoveFirstItem()
        {
            sLink.Add("Ivan");
            sLink.Add("Danila");
            sLink.Add("Alex");
            var beforeRemove = sLink.ValueArray();
            Assert.IsTrue(sLink.Remove("Ivan"));
            var afterRemove = sLink.ValueArray();
            CollectionAssert.DoesNotContain(afterRemove, "Ivan");
            CollectionAssert.Contains(afterRemove, "Danila");
            CollectionAssert.Contains(afterRemove, "Alex");
            CollectionAssert.AreNotEquivalent(beforeRemove, afterRemove);
        }

        [Test]
        public void TestRemoveFake()
        {
            var beforeRemove = sLink.ValueArray();
            Assert.IsFalse(sLink.Remove("Alex"));
            var afterRemove = sLink.ValueArray();
            CollectionAssert.AreEquivalent(beforeRemove, afterRemove);
        }
    }
}