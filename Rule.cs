namespace FizzBuzz;

internal record Rule(string Code, params int[] Divisors)
{
    public bool Applies(int divident) =>
        Divisors.All(divisor => divident % divisor == 0);
}
