namespace FizzBuzz;

internal record Rule(string Code, params int[] Devisors)
{
    public bool Applies(int divident) =>
        Devisors.All(devisor => divident % devisor == 0);
}
