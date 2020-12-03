using System;
using System.Diagnostics;
using System.IO;

int count = 0;

//
// Part 1
//
var lines = File.ReadAllLines("input.txt");
var s = Stopwatch.StartNew();
for (int i = 0; i < lines.Length; i++)
{
    var entries = lines[i].Split(' ');
    var e0 = entries[0].AsSpan();
    var e1 = entries[1].AsSpan();
    var e2 = entries[2].AsSpan();
    var seperator = e0.IndexOf('-');
    var min = Convert.ToInt32(e0[..seperator].ToString());
    var max = Convert.ToInt32(e0[(seperator + 1)..].ToString());
    var letter = e1[0];

    int letterCount = 0;
    foreach (var item in e2)
    {
        if (item == letter)
            letterCount++;
    }

    if (letterCount >= min && letterCount <= max)
        count++;
}
s.Stop();
Console.WriteLine($"Found {count} passwords and took {s.ElapsedMilliseconds}ms");

//
// Part 2
//
count = 0;
s = Stopwatch.StartNew();
for (int i = 0; i < lines.Length; i++)
{
    var entries = lines[i].Split(' ');
    var e0 = entries[0].AsSpan();
    var e1 = entries[1].AsSpan();
    var e2 = entries[2].AsSpan();
    var seperator = e0.IndexOf('-');
    var index1 = Convert.ToInt32(e0[..seperator].ToString());
    var index2 = Convert.ToInt32(e0[(seperator + 1)..].ToString());
    var letter = e1[0];

    if (e2[index1 - 1] == letter ^ e2[index2 - 1] == letter)
        count++;
}
s.Stop();
Console.WriteLine($"Found {count} passwords and took {s.ElapsedMilliseconds}ms");
