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

    public static Task<IEnumerable<Rule>> FetchStaticRulesAsync() => 
        FetchRulesAsync("https://epinova-fizzbuzz.azurewebsites.net/api/static-rules");
    
    public static Task<IEnumerable<Rule>> FetchDynamicRulesAsync() => 
        FetchRulesAsync("https://epinova-fizzbuzz.azurewebsites.net/api/dynamic-rules");

    public static async Task<IEnumerable<Rule>> FetchRulesAsync(string Url)
    {
        var response = await Client.GetAsync(Url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var rules = JsonSerializer.Deserialize<IEnumerable<EpinovaRuleDto>>(json);

        return rules?.Select(x => new Rule(x.Word, [x.Number])) ?? [];
    }

    private class EpinovaRuleDto
    {
        public required int Number { get; init; }
        public required string Word { get; init; }
    }
}
