using System.Data.SqlTypes;

namespace FizzBuzz.Tests
{
    public class Tests
    {
        [Test]
        [TestCase(new int[] { 3 }, 1)]
        [TestCase(new int[] { 3, 5 }, 1)]
        [TestCase(new int[] { 3, 5, 6 }, 2)]
        [TestCase(new int[] { 1, 3, 4 }, 1)]
        [TestCase(new int[] { 3, 9, 15, 5, 10, 11 }, 3)]
        [TestCase(new int[] { 3, 6, 9, 12, 61, 73, 36, 60 }, 6)]
        public void Outputs_Fizz_When_Numbers_Are_Divisible_By_3(int[] numbers, int expectedFizzCount)
        {
            // Arrange
            var sut = new FizzBuzz();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            sut.Run(numbers);
            var output = stringWriter.ToString();

            // Assert
            int fizzCount = CountSubstringOccurrences(output, "Fizz");
            Assert.That(fizzCount, Is.EqualTo(expectedFizzCount));
        }

        [Test]
        [TestCase(new int[] { 5 }, 1)]
        [TestCase(new int[] { 10 }, 1)]
        [TestCase(new int[] { 5, 10 }, 2)]
        [TestCase(new int[] { 5, 10, 11, 13 }, 2)]
        [TestCase(new int[] { 5, 10, 20, 25, 35, 50 }, 6)]
        [TestCase(new int[] { 5, 10, 20, 100, 3, 6, 36, 25, 35, 50 }, 7)]
        public void Outputs_Buzz_When_Numbers_Are_Divisible_By_5(int[] numbers, int expectedBuzzCount)
        {
            // Arrange
            var sut = new FizzBuzz();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            sut.Run(numbers);
            var output = stringWriter.ToString();

            // Assert
            int buzzCount = CountSubstringOccurrences(output, "Buzz");
            Assert.That(buzzCount, Is.EqualTo(expectedBuzzCount));
        }

        [Test]
        [TestCase(new int[] { 5 }, new int[] { })]
        [TestCase(new int[] { 3 }, new int[] { })]
        [TestCase(new int[] { 5, 3 }, new int[] { })]
        [TestCase(new int[] { 3, 5, 6 }, new int[] { })]
        [TestCase(new int[] { 1, 3, 4, 5 }, new int[] { 1, 4 })]
        [TestCase(new int[] { 3, 9, 15, 5, 10, 11, 13, 28 }, new int[] { 11, 13, 28 })]
        [TestCase(new int[] { 3, 6, 9, 12, 61, 73, 36, 60 }, new int[] { 61, 73 })]
        public void Outputs_Number_When_Numbers_Are_Not_Divisible_By_3(int[] numbers, int[] expectedNumbers)
        {
            // Arrange
            var sut = new FizzBuzz();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            sut.Run(numbers);
            var output = stringWriter.ToString();

            // Assert
            foreach (int num in expectedNumbers)
            {
                Assert.That(output.Contains(num.ToString()), Is.True, $"Expected number {num} not found in output.");
            }
        }

        private int CountSubstringOccurrences(string text, string substring)
        {
            int count = 0;
            int index = 0;
            while ((index = text.IndexOf(substring, index)) != -1)
            {
                index += substring.Length;
                count++;
            }
            return count;
        }
    }
}