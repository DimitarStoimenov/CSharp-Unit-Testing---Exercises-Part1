namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void DatabaseSchouldAddExactlyNumbers()
        {
            Database database = new Database();

            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }
            
            Assert.Throws<InvalidOperationException>(() =>  database.Add(1));

        }
        [TestCase(16)]
        [TestCase(2)]
        public void ConstructorShouldAddElementsUntillLessthan16(int numbs)
        {
            int[] numbers = Enumerable.Range(1, numbs).ToArray();
            Database database = new Database(numbers);

            Assert.AreEqual(numbs, database.Count);

        }

        [Test]
        public void CheckIfDatabaseIsEmpty()
        {
           
          
            Database database = new Database();

            Assert.AreEqual(database.Count, 0);

        }

        [Test]

        public void ThrowExeptionIfIsNull()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]

        public void CheckIfFetchMethodeReturnsEqualArray()
        {
           
            Database database = new Database(1, 2, 3);

           
            int[] expected = new int[] { 1, 2, 3 };

            Assert.AreEqual(database.Fetch(), expected);


        }
    }
}
