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

foreach (var j in Enumerable.Range(0, 100))
{
    var i = 100 - j;

    if (i % 4 == 0 && i % 9 == 0)
        Console.WriteLine("Jazz Fuzz");
    else if (i % 9 == 0)
        Console.WriteLine("Jazz");
    else if (i % 4 == 0)
        Console.WriteLine("Fuzz");
    else Console.WriteLine(i);
}