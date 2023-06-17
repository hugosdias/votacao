using System.IO;// See https://aka.ms/new-console-template for more information


Console.Write("Enter file full path: ");
string path = Console.ReadLine();

try
{
    using StreamReader sr = File.OpenText(path);

    Dictionary<string, int> dictionary = new();

    while (!sr.EndOfStream)
    {
        string[] votingRecord = sr.ReadLine().Split(',');
        string candidate = votingRecord[0];
        int votes = int.Parse(votingRecord[1]);

        if(dictionary.ContainsKey(candidate))
        {
            dictionary[candidate] += votes;
        }
        else
        {
            dictionary[candidate] = votes;
        }
    }
    foreach (var item in dictionary)
    {
        Console.WriteLine($"{item.Key} : {item.Value}");
    }
}
catch (IOException e)
{
    Console.WriteLine("An error ocurred");
    Console.WriteLine(e.Message);
}