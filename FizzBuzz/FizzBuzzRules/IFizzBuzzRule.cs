namespace FizzBuzz.FizzBuzzRules
{
    public interface IFizzBuzzRule
    {
        bool IsMatch(int number);
        string GetOutput();
    }
}
