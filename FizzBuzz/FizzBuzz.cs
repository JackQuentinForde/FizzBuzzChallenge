namespace FizzBuzz
{
    public class FizzBuzz
    {
        public FizzBuzz() { }

        public void Run(int[] numbers)
        {
            foreach (int number in numbers) 
            {
                Console.WriteLine(number);
            }
        }
    }
}