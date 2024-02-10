using FizzBuzz.FizzBuzzRules;

namespace FizzBuzz.Tests
{
    public class Tests
    {
        private readonly IFizzBuzzRule[] rules = { new FizzBuzzRule(), new FizzRule(), new BuzzRule() };

        [Test]
        [TestCase(new int[] { 3 }, 1)]
        [TestCase(new int[] { 3, 5 }, 1)]
        [TestCase(new int[] { 3, 5, 6 }, 2)]
        [TestCase(new int[] { 1, 3, 4 }, 1)]
        [TestCase(new int[] { 3, 9, 15, 5, 10, 11 }, 2)]
        [TestCase(new int[] { 3, 6, 9, 12, 61, 73, 36, 60 }, 5)]
        public void Outputs_Fizz_When_Numbers_Are_Divisible_By_3(int[] numbers, int expectedFizzCount)
        {
            // Arrange
            var sut = new FizzBuzz(rules);
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
        [TestCase(new int[] { 5, 10, 20, 100, 3, 6, 36, 25, 35, 50, 60 }, 7)]
        public void Outputs_Buzz_When_Numbers_Are_Divisible_By_5(int[] numbers, int expectedBuzzCount)
        {
            // Arrange
            var sut = new FizzBuzz(rules);
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
        [TestCase(new int[] { 15 }, 1)]
        [TestCase(new int[] { 30 }, 1)]
        [TestCase(new int[] { 30, 15, 60 }, 3)]
        [TestCase(new int[] { 30, 20, 15, 36, 9, 25, 60 }, 3)]
        public void Outputs_FizzBuzz_When_Numbers_Are_Divisible_By_3_And_5(int[] numbers, int expectedFizzBuzzCount)
        {
            // Arrange
            var sut = new FizzBuzz(rules);
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            sut.Run(numbers);
            var output = stringWriter.ToString();

            // Assert
            int fizzBuzzCount = CountSubstringOccurrences(output, "FizzBuzz");
            Assert.That(fizzBuzzCount, Is.EqualTo(expectedFizzBuzzCount));
        }

        [Test]
        [TestCase(new int[] { 5 }, new int[] { })]
        [TestCase(new int[] { 3 }, new int[] { })]
        [TestCase(new int[] { 5, 3 }, new int[] { })]
        [TestCase(new int[] { 3, 5, 6 }, new int[] { })]
        [TestCase(new int[] { 1, 3, 4, 5 }, new int[] { 1, 4 })]
        [TestCase(new int[] { 3, 9, 15, 5, 10, 11, 13, 28 }, new int[] { 11, 13, 28 })]
        [TestCase(new int[] { 3, 6, 9, 12, 61, 73, 36, 60 }, new int[] { 61, 73 })]
        public void Outputs_Number_When_Numbers_Are_Not_Divisible_By_3_Or_5(int[] numbers, int[] expectedNumbers)
        {
            // Arrange
            var sut = new FizzBuzz(rules);
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

        [Test]
        public void Outputs_Expected_Result_When_Input_Is_1_To_100()
        {
            // Arrange
            var sut = new FizzBuzz(rules);
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var numbers = Enumerable.Range(1, 100).ToArray();
            var expectedResult = "1\r\n2\r\nFizz\r\n4\r\nBuzz\r\nFizz\r\n7\r\n8\r\nFizz\r\nBuzz\r\n11\r\nFizz\r\n13\r\n14\r\nFizzBuzz\r\n16\r\n17\r\nFizz\r\n19\r\nBuzz\r\nFizz\r\n22\r\n23\r\nFizz\r\nBuzz\r\n26\r\nFizz\r\n28\r\n29\r\nFizzBuzz\r\n31\r\n32\r\nFizz\r\n34\r\nBuzz\r\nFizz\r\n37\r\n38\r\nFizz\r\nBuzz\r\n41\r\nFizz\r\n43\r\n44\r\nFizzBuzz\r\n46\r\n47\r\nFizz\r\n49\r\nBuzz\r\nFizz\r\n52\r\n53\r\nFizz\r\nBuzz\r\n56\r\nFizz\r\n58\r\n59\r\nFizzBuzz\r\n61\r\n62\r\nFizz\r\n64\r\nBuzz\r\nFizz\r\n67\r\n68\r\nFizz\r\nBuzz\r\n71\r\nFizz\r\n73\r\n74\r\nFizzBuzz\r\n76\r\n77\r\nFizz\r\n79\r\nBuzz\r\nFizz\r\n82\r\n83\r\nFizz\r\nBuzz\r\n86\r\nFizz\r\n88\r\n89\r\nFizzBuzz\r\n91\r\n92\r\nFizz\r\n94\r\nBuzz\r\nFizz\r\n97\r\n98\r\nFizz\r\nBuzz\r\n";

            // Act
            sut.Run(numbers);
            var output = stringWriter.ToString();

            // Assert
            Assert.That(output, Is.EqualTo(expectedResult));
        }

        private int CountSubstringOccurrences(string text, string substring)
        {
            int count = 0;
            int index = 0;
            while ((index = text.IndexOf(substring, index)) != -1)
            {
                if (IsWholeWord(text, index, substring.Length))
                {
                    count++;
                }
                index += substring.Length;
            }
            return count;
        }

        private bool IsWholeWord(string text, int startIndex, int length)
        {
            // Check if substring is part of a larger word
            if ((startIndex == 0 || !char.IsLetterOrDigit(text[startIndex - 1])) &&
                (startIndex + length == text.Length || !char.IsLetterOrDigit(text[startIndex + length])))
            {
                return true;
            }
            return false;
        }
    }
}