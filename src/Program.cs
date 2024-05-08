using FizzBuzz;
using System.Text.Json;

static void PrintResults(IEnumerable<int> numbers, IEnumerable<Rule> rules)
{
    foreach (var number in numbers)
    {
        var rule = rules.FirstOrDefault(rule => rule.AppliesTo(number));
        if (rule is not null)
            Console.WriteLine(rule.Code);
        else
            Console.WriteLine(number);
    }
}

var staticRules = await RuleFetcher.FetchStaticRulesAsync();
Console.WriteLine($"Current rules: {JsonSerializer.Serialize(staticRules)}");
Console.Write("Press any key to continue: "); Console.ReadKey();
PrintResults(Enumerable.Range(1, 100), staticRules);

var dynamicRules = await RuleFetcher.FetchDynamicRulesAsync();
Console.WriteLine($"Current rules: {JsonSerializer.Serialize(dynamicRules)}");
Console.Write("Press any key to continue: "); Console.ReadKey();
PrintResults(Enumerable.Range(1, 100), dynamicRules);
