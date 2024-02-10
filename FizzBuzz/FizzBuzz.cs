using FizzBuzz.FizzBuzzRules;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        private readonly IFizzBuzzRule[] rules;

        public FizzBuzz(IFizzBuzzRule[] rules)
        {
            this.rules = rules;
        }

        public void Run(int[] numbers)
        {
            foreach (int number in numbers)
            {
                string output = GetOutput(number);
                Console.WriteLine(output);
            }
        }

        private string GetOutput(int number)
        {
            foreach (var rule in rules)
            {
                if (rule.IsMatch(number))
                {
                    return rule.GetOutput();
                }
            }
            return number.ToString();
        }
    }
}