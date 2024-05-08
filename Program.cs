foreach (var i in Enumerable.Range(1, 100))
{
    if (i % 3 == 0 && i % 5 == 0)
        Console.WriteLine("Fizz Buzz");
    else if (i % 3 == 0)
        Console.WriteLine("Fizz");
    else if (i % 5 == 0)
        Console.WriteLine("Buzz");
    else Console.WriteLine(i);
}