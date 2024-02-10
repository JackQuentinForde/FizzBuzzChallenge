namespace FizzBuzz
{
    public class FizzBuzz
    {
        public FizzBuzz() { }

        public void Run(int[] numbers)
        {
            foreach (int number in numbers) 
            {
                if (number == 3)
                    Console.WriteLine("Fizz");
            }
        }
    }
}