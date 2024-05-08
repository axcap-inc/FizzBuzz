using FizzBuzz;

static void PrintResults(IEnumerable<int> numbers, IEnumerable<Rule> rules)
{
    foreach (var i in numbers)
    {
        bool anyRuleApplied = false;
        foreach (var rule in rules)
        {
            if (rule.Applies(i))
            {
                anyRuleApplied = true;
                Console.WriteLine(rule.Code);
            }
        }

        if (!anyRuleApplied) Console.WriteLine(i);
    }
}

var staticRules = await RuleFetcher.FetchStaticRulesAsync();
PrintResults(Enumerable.Range(1, 100), staticRules);

var dynamicRules = await RuleFetcher.FetchDynamicRulesAsync();
PrintResults(Enumerable.Range(1, 100), dynamicRules);
