class Program
{
    public static void PushString(ref Dictionary<int, List<string>> map, ref string Text)
    {
        if (map.ContainsKey(Text.Length))
        {
            map[Text.Length].Add(Text);
        }
        else
        {
            map[Text.Length] = new List<string>();
            map[Text.Length].Add(Text);
        }
        Text = string.Empty;
    }

    public static bool IsOnlyLatter(string Test)
    {
        foreach (var item in Test)
        {
            if (char.IsDigit(item))
                return false;
        }
        return true;
    }


    // unfortunately I did not understand if words with numbers in "" are allowed, wenn not, than we dont need "public static string FindWords(ref Dictionary<int, List<string>> map, string Text)"
    public static string FindWords(ref Dictionary<int, List<string>> map, string Text)
    {
        string Text1 = string.Empty;
        string Text2 = string.Empty;
        foreach (var item in Text)
        {
            if (char.IsLetter(item) || char.IsDigit(item))
            {
                Text2 += item;
            }
            else if (IsOnlyLatter(Text2))
            {
                if (Text1 == string.Empty)
                {
                    Text1 = Text2;

                }
                else
                {
                    Text1 += " " + Text2;
                }
                Text2 = string.Empty;
            }
            else
            {
                Text2 = string.Empty;
            }
        }
        Text1 += " " + Text2;
        return Text1;
    }

    public static void Aufgabe_Exocad(ref Dictionary<int, List<string>> map, string Text)
    {
        string Text2 = string.Empty;

        for (int i = 0; i < Text.Length; i++)
        {
            if (Text[i] == '\"' || Text[i] == '\'')
            {
                i++;
                while (Text[i] != '\"' && Text[i] != '\'')
                {
                    Text2 += Text[i];
                    i++;
                }
                //unfortunately I did not understand if words with numbers in "" are allowed, wenn not, than we dont need "public static string FindWords(ref Dictionary<int, List<string>> map, string Text)"
                //Text2 = FindWords(ref map, Text2);

                PushString(ref map, ref Text2);
            }
            else if (char.IsLetter(Text[i]) || char.IsDigit(Text[i]))
            {
                Text2 += Text[i];
            }
            else if (IsOnlyLatter(Text2))
            {
                PushString(ref map, ref Text2);
            }
            else if(i == Text.Length - 1 && IsOnlyLatter(Text2))
            {
                PushString(ref map, ref Text2);
            }
            else
            {
                Text2 = string.Empty;
            }
        }
    }
    public static void Print(Dictionary<int, List<string>> map) 
    {
        Console.WriteLine($"this text has {map.Count} words");
        foreach (var item in map)
        {
            if (item.Key > 0)
            {
                Console.WriteLine($"words with {item.Key} letter occured {item.Value.Count} times: words=({string.Join(", ", item.Value)})");
            }
            else
            {
                Console.WriteLine($"words with {item.Key} letter not occured");
            }
        }
    }


    static void Main(string[] args)
    {
        Dictionary<int, List<string>> map = new Dictionary<int, List<string>> ();
        Console.WriteLine("Input Text: ");
        string Text = Console.ReadLine() ?? string.Empty;
        Aufgabe_Exocad(ref map, Text);
        map = map.OrderBy(key => key.Key).ToDictionary(key => key.Key, value => value.Value) ;
        Print(map);
    }

   
}