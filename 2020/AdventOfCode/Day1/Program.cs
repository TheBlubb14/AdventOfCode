using System;
using System.IO;
using System.Linq;

const int search = 2020;
const int parts = 2;

var foundNumbers = new int[parts];

var expenses = File.ReadAllText("input.txt").Split(Environment.NewLine).Select(x => Convert.ToInt32(x)).OrderByDescending(x => x);
foreach (var item in expenses)
{
    var difference = search - item;
    if (difference > 0 && expenses.Any(x => x == difference))
    {
        Console.WriteLine($"Found {item} and {difference}. Product is {item * difference}");
        break;
    }
}

foreach (var item in expenses)
{
    foreach (var item2 in expenses.Skip(1))
    {
        foreach (var item3 in expenses.Skip(2))
        {
            if (item + item2 + item3 == search)
            {
                Console.WriteLine($"Found {item}, {item2} and {item3}. Product is {item * item2 * item3}");
                return;
            }
        }
    }
}