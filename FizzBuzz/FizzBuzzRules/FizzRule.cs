using FizzBuzz.FizzBuzzRules;

public class FizzRule : IFizzBuzzRule
{
    public bool IsMatch(int number)
    {
        return number % 3 == 0;
    }

    public string GetOutput()
    {
        return "Fizz";
    }
}