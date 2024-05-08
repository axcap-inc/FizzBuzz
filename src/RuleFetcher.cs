using System.Text.Json;

namespace FizzBuzz;

internal record Rule(string Code, params int[] Divisors)
{
    public bool AppliesTo(int divident) =>
        Divisors.All(divisor => divident % divisor == 0);
}

internal static class RuleFetcher
{
    private static readonly HttpClient Client = new();

    public static async Task<IEnumerable<Rule>> FetchStaticRulesAsync()
    {
        var baseRules = await FetchRulesAsync("https://epinova-fizzbuzz.azurewebsites.net/api/static-rules");
        var extendedRules = ExtendWithCombinedRule(baseRules);
        var sorted = extendedRules.OrderByDescending(rule => rule.Divisors.Length);
        return sorted;
    }
    
    public static async Task<IEnumerable<Rule>> FetchDynamicRulesAsync()
    {
        var baseRules = await FetchRulesAsync("https://epinova-fizzbuzz.azurewebsites.net/api/dynamic-rules");
        var extendedRules = ExtendWithCombinedRule(baseRules);
        var sorted = extendedRules.OrderByDescending(rule => rule.Divisors.Length);
        return sorted;
    }

    public static async Task<IEnumerable<Rule>> FetchRulesAsync(string Url)
    {
        var response = await Client.GetAsync(Url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var rules = JsonSerializer.Deserialize<IEnumerable<EpinovaRuleDto>>(json);

        return rules?.Select(x => new Rule(x.Word, [x.Number])) ?? [];
    }

    private static List<Rule> ExtendWithCombinedRule(IEnumerable<Rule> baseRules)
    {
        var extendedRules = baseRules.ToList();
        var combinedRule = new Rule(
            Code: $"{extendedRules[0].Code} {extendedRules[1].Code}",
            Divisors: [extendedRules[0].Divisors[0], extendedRules[1].Divisors[0]]);
        extendedRules.Add(combinedRule);

        return extendedRules;
    }

    private class EpinovaRuleDto
    {
        public required int Number { get; init; }
        public required string Word { get; init; }
    }
}
