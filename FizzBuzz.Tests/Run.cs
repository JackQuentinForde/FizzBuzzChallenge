namespace FizzBuzz.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { 3 }, 1)]
        [TestCase(new int[] { 3, 5 }, 1)]
        [TestCase(new int[] { 3, 5, 6 }, 2)]
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