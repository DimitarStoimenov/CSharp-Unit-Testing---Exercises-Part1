namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
       
        [Test]

        public void ConstructorEmptyCollectionSchOuldReturnZero()
        {
            Database db = new Database();

            Assert.AreEqual(0, db.Count);
        }

        [Test]

        public void ConstructorMoreThan16ArgumentExeption()
        {
            Person[] persons = new Person[17];

            Assert.Throws<ArgumentException>(() => new Database(persons));
        }

        [Test]

        public void ConstructorOnePersonShoulReturnOne()
        {
            Database db = new Database(new Person(1, "A"));

            Assert.AreEqual(1, db.Count);
        }

        [Test]

        public void ConstructorOnePersonIsAddedCorrectly()
        {
            Person per = new Person(1, "A");
            Database db = new Database(per);

            Person actual = db.FindById(1);

            Assert.AreEqual(per, actual);
        }

        [Test]

        public void ConstructorOnePersonIsAddedCorrectlyProperties()
        {
            Person per = new Person(1, "A");
            Database db = new Database(per);

            Person actual = db.FindById(1);

            Assert.AreEqual(per, actual);
            Assert.AreEqual("A", actual.UserName);
        }

        [Test]

        public void ConstructorAddPersonWithExsistingUNShouldThrowIOP()
        {
            Person per1 = new Person(1, "A");
            Person per2 = new Person(2, "A");

            Assert.Throws<InvalidOperationException>(() => new Database(per1, per2));
        }

        [Test]

        public void ConstructorAddPersonWithExsistingIDShouldThrowIOP()
        {
            Person per1 = new Person(1, "A");
            Person per2 = new Person(1, "B");

            Assert.Throws<InvalidOperationException>(() => new Database(per1, per2));
        }


        [Test]

        public void ConstructorMoreThan16InvalidOperationExeption()
        {
            Person[] persons = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                persons[i] = new Person(i + 1, $"A{i}");
            }
            Database db = new Database(persons);
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(100, "AAA")));
        }

        [Test]

        public void ExsistingUserNameShouldThrowInvalid()
        {
            Database db = new Database();

            db.Add(new Person(1, "A"));

            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(2, "A")));
        }

        [Test]

        public void ExsistingIdShouldThrowInvalid()
        {
            Database db = new Database();

            db.Add(new Person(1, "A"));

            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(1, "B")));
        }

        [Test]

        public void AddmethodSchouldIncrementCount()
        {
           
            Database db = new Database();
            Person per = new Person(1, "A");

            db.Add(per);
            

            Assert.AreEqual(1, db.Count);
            
        }

        [Test]

        public void AddmethodSchouldAddOnePersonCorrectlyPropperties()
        {

            Database db = new Database();
            Person per1 = new Person(1, "A");
            

            db.Add(per1);
            
            Person actual = db.FindById(1);


            Assert.AreEqual(1, actual.Id);
            Assert.AreEqual("A", actual.UserName);

        }

        [Test]

        public void AddMethodSchouldAddThreeCorrectlyPropperties()
        {

            Database db = new Database();
            Person per1 = new Person(1, "A");
            Person per2 = new Person(2, "B");
            Person per3 = new Person(3, "C");

            db.Add(per1);
            db.Add(per2);
            db.Add(per3);
            Person actual = db.FindById(2);


            Assert.AreEqual(2, actual.Id);
            Assert.AreEqual("B", actual.UserName);

        }


        [Test]

        public void SchouldThrowInvOpEx()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]

        public void SchouldReturnZero()
        {
            Database db = new Database();
            db.Add(new Person(1, "A"));
            db.Remove();
            int exp = 0;
            int real = db.Count;

            Assert.AreEqual(exp, real);
               
        }

       
        [TestCase(null)]
        [TestCase("")]

        public void EmptyUserNameSchoudThrowInvalNullEx(string name)
        {
            Database db = new Database();


            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(name));

        }

        [Test]

        public void EmptyCollectionShoulThrowInvalidOperaEx()
        {
            Database db = new Database();


            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("AA"));

        }


        [Test]

        public void NotEmptyCollectionWithinvalidUserNameShoulThrowInvalidOperaEx()
        {
            Database db = new Database();
            db.Add(new Person(12, "B"));

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("A"));

        }

        [Test]

        public void NotEmptyCollectionWithValidUserNameShoulReturnNAme()
        {
            Database db = new Database();

            db.Add(new Person(12, "A"));

            Person actual = db.FindByUsername("A");
            Assert.AreEqual(12, actual.Id);
            Assert.AreEqual("A", actual.UserName);

        }


        [Test]

        public void FindByNegativeID()
        {
            Database db = new Database();

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
        }

        [Test]

        public void FindByIdEmptyCollectionWithInvalidIdSchouldThrowIOP()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() => db.FindById(1));
        }

        [Test]

        public void FindByIdNonEmptyCollectionWithInvalidIdSchouldThrowIOP()
        {
            Database db = new Database();
            db.Add(new Person(1, "B"));
            Assert.Throws<InvalidOperationException>(() => db.FindById(2));
        }

      
    }


}

