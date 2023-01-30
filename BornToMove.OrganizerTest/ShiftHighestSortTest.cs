using NUnit.Framework;
using Organizer;

namespace BornToMove.OrganizerTest
{
    public class ShiftHighestSortTest
    {
        [Test]
        public void TestSort_ArgumentNull()
        {
            // 1
            var shs = new ShiftHighestSort<int>();
            var comparer = Comparer<int>.Default;

            // 2 + 3
            Assert.Throws<ArgumentNullException>(
                () => shs.Sort(null, comparer)
            );
        }

        [Test]
        public void TestSort_Empty()
        {
            // Arrage
            var input = new List<int> { };
            var comparer = Comparer<int>.Default;
            var shs = new ShiftHighestSort<int>();

            // Act
            var results = shs.Sort(input, comparer);

            // Assert
            Assert.IsEmpty(results);
        }

        [Test]
        public void TestSort_OneElement()
        {
            // Arrange
            var input = new List<int>() { 5 };
            var expected = new List<int>() { 5 };
            var comparer = Comparer<int>.Default;
            var shs = new ShiftHighestSort<int>();

            // Act
            var result = shs.Sort(input, comparer);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestSort_TwoElements()
        {
            // Arrange
            var input = new List<int>() { 7, 2 };
            var expected = new List<int>() { 2, 7 };
            var comparer = Comparer<int>.Default;
            var shs = new ShiftHighestSort<int>();

            // Act
            var result = shs.Sort(input, comparer);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestSort_Equal()
        {
            // Arrange
            var input = new List<int>() { 4, 4, 4 };
            var expected = new List<int>() { 4, 4, 4 };
            var comparer = Comparer<int>.Default;
            var shs = new ShiftHighestSort<int>();

            // Act
            var result = shs.Sort(input, comparer);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestSort_UnsortedArray()
        {
            // Arrange
            var input = new List<int>() { 24, 52, 12, 5, 1, 600, 10 };
            var expected = new List<int>() { 1, 5, 10, 12, 24, 52, 600 };
            var comparer = Comparer<int>.Default;
            var shs = new ShiftHighestSort<int>();

            // Act
            var result = shs.Sort(input, comparer);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}