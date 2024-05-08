using FizzBuzz;
using Xunit;

namespace FizzBuzzTests;

public class RulesUnitTests
{
    private static readonly IEnumerable<Rule> Rules = [new("Fizz Buzz", [3, 5]), new("Fizz", 3), new("Buzz", 5)];
    [Theory]
    [InlineData(1, null)]
    [InlineData(3, "Fizz")]
    [InlineData(5, "Buzz")]
    [InlineData(15, "Fizz Buzz")]
    public void Test1(int input, string expectedOutput)
    {
        var rule = Rules.FirstOrDefault(rule => rule.AppliesTo(input));

        Assert.Equal(rule?.Code, expectedOutput);
    }
}