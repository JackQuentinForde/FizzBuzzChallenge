using FizzBuzz.FizzBuzzRules;
using System.Reflection;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        private readonly List<IFizzBuzzRule> rules;

        public FizzBuzz()
        {
            rules = LoadRules();
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

        private List<IFizzBuzzRule> LoadRules()
        {
            var ruleTypes = Assembly.GetExecutingAssembly().GetTypes()
                                    .Where(t => t.GetInterfaces().Contains(typeof(IFizzBuzzRule)))
                                    .ToList();

            var rules = new List<IFizzBuzzRule>();

            // Load FizzBuzz rule first
            var fizzBuzzRuleType = ruleTypes.FirstOrDefault(t => t.Name == nameof(FizzBuzzRule));
            if (fizzBuzzRuleType != null)
            {
                var fizzBuzzRuleInstance = Activator.CreateInstance(fizzBuzzRuleType) as IFizzBuzzRule;
                if (fizzBuzzRuleInstance != null)
                {
                    rules.Add(fizzBuzzRuleInstance);
                    ruleTypes.Remove(fizzBuzzRuleType); // Remove FizzBuzz rule type from the list
                }
            }

            // Load other rules
            var otherRules = ruleTypes.Select(t => Activator.CreateInstance(t) as IFizzBuzzRule)
                                      .Where(r => r != null);

            rules.AddRange(otherRules);

            return rules;
        }

    }
}
