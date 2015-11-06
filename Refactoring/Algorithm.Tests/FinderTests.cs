using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithm.Test
{    
    [TestFixture]
    public class FinderTests
    {
        Person sue;
        Person greg;
        Person sarah;
        Person mike;

        [SetUp]
        public void Setup()
        {
            this.sue = new Person() { Name = "Sue", BirthDate = new DateTime(1950, 1, 1) };
            this.greg = new Person() { Name = "Greg", BirthDate = new DateTime(1952, 6, 1) };
            this.mike = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
            this.sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };  
        }

        [Test]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var list = new List<Person>();
           
            var result = Finder.Find(list, new ClosestSelector());

            Assert.Null(result.FirstPerson);
            Assert.Null(result.SecondPerson);
        }

        [Test]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var list = new List<Person>() { sue };

            var result = Finder.Find(list, new ClosestSelector());

            Assert.Null(result.FirstPerson);
            Assert.Null(result.SecondPerson);
        }

        [Test]
        public void Returns_Closest_Two_For_Two_People()
        {
            var list = new List<Person>() { sue, greg };

            var result = Finder.Find(list, new ClosestSelector());

            Assert.AreEqual(sue, result.FirstPerson);
            Assert.AreEqual(greg, result.SecondPerson);
        }

        [Test]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var list = new List<Person>() { greg, mike };
           
            var result = Finder.Find(list, new FurthestSelector());

            Assert.AreEqual(greg, result.FirstPerson);
            Assert.AreEqual(mike, result.SecondPerson);
        }

        [Test]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
           
            var result = Finder.Find(list, new FurthestSelector());

            Assert.AreEqual(sue, result.FirstPerson);
            Assert.AreEqual(sarah, result.SecondPerson);
        }

        [Test]
        public void Returns_Closest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };

            var result = Finder.Find(list, new ClosestSelector());

            Assert.AreEqual(sue, result.FirstPerson);
            Assert.AreEqual(greg, result.SecondPerson);
        }
    }
}