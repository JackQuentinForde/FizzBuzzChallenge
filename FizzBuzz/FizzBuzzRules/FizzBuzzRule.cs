using FizzBuzz.FizzBuzzRules;

public class FizzBuzzRule : IFizzBuzzRule
{
    public bool IsMatch(int number)
    {
        return number % 3 == 0 && number % 5 == 0;
    }

    public string GetOutput()
    {
        return "FizzBuzz";
    }
}