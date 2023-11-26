string msg = "Hello, World! 123";

Dictionary<char, int> hashTable = new Dictionary<char, int>();

for (int i = 0; i < msg.Length; i++)
{
    if (char.IsLetterOrDigit(msg[i]))
    {
        if (hashTable.ContainsKey(msg[i]))
        {
            hashTable[msg[i]] ++;
        }
        else
        {
            hashTable.Add(msg[i],1);
        }
    }
}

foreach (var keyValuePair in hashTable)
{
    Console.WriteLine($"{keyValuePair.Key} - {keyValuePair.Value}");
}