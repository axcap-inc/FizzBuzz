using FizzBuzz;
using System.Text.Json;

static void PrintResults(IEnumerable<int> numbers, IEnumerable<Rule> rules)
{
    foreach (var number in numbers)
    {
        bool anyRuleApplied = false;
        foreach (var rule in rules)
        {
            if (rule.AppliesTo(number))
            {
                anyRuleApplied = true;
                Console.WriteLine(rule.Code);
            }
        }

        if (!anyRuleApplied) Console.WriteLine(number);
    }
}

var staticRules = await RuleFetcher.FetchStaticRulesAsync();
Console.WriteLine($"Current rules: {JsonSerializer.Serialize(staticRules)}");
Console.Write("Press any key to continue: "); Console.ReadKey();

PrintResults(Enumerable.Range(1, 100), staticRules);

//var dynamicRules = await RuleFetcher.FetchDynamicRulesAsync();
//PrintResults(Enumerable.Range(1, 100), dynamicRules);
