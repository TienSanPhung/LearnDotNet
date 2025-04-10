namespace CollectionL;

class Program
{
    static void Main(string[] args)
    {
        var list = new List<string>();
        ReadList(list);
        Print(list);
        SortList(list);
        Print(list);
    }

    private static void SortList(List<string> list)
    {
        for(int i =0; i < list.Count - 1; i++)
        {
            for (int j = i + 1; j < list.Count ; j++)
            {
                if (list[i].CompareTo(list[j]) > 0)
                {
                    var temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
        }
        
    }

    private static void Print(List<string> list)
    {
        Console.WriteLine("--------------------------------");
        foreach (var n in list)
        {
            Console.WriteLine(n);    
        }
    }

    private static void ReadList(List<string> list)
    {
        string? s;
        do
        {
            s = Console.ReadLine();
            if (!string.IsNullOrEmpty(s))
            {
                list.Add(s);
            }
        }while(!string.IsNullOrEmpty(s));
        
    }
}