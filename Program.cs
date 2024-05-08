using FizzBuzz;

static void PrintResults(IEnumerable<int> numbers, IEnumerable<Rule> rules)
{
    foreach (var number in numbers)
    {
        var rule = rules.FirstOrDefault(rule => rule.Applies(number));
        if (rule is not null)
            Console.WriteLine(rule.Code);
        else
            Console.WriteLine(number);
    }
}

var FizzRule = new Rule("Fizz", 3);
var BuzzRule = new Rule("Buzz", 5);
var FizzBuzzRule = new Rule("Fizz Buzz", 3, 5);
PrintResults(Enumerable.Range(1, 100), [FizzBuzzRule, FizzRule, BuzzRule]); // Viktig med rekkefølgen på reglene i listen

var JazzRule = new Rule("Jazz", 9);
var FuzzRule = new Rule("Fuzz", 4);
var JazzFuzzRule = new Rule("Fuzz", 4, 9);
PrintResults(Enumerable.Range(1, 100).Reverse(), [JazzFuzzRule, JazzRule, FuzzRule]);  // Viktig med rekkefølgem på reglene i listen