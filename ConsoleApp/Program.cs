class Program
{
    static void Main(string[] args)
    {
        new FizzBuzz.FizzBuzz().Run(Enumerable.Range(1, 100).ToArray());
    }
}