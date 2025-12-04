using System.Reflection;
Adventofcode2025Main.Runday(4);

static class Adventofcode2025Main
{
    const string defaultBasePath = @"Inputs\";
    const string defaultFileNamePrefix = @"day";
    static string basePath = defaultBasePath;
    static string fileNamePrefix = defaultFileNamePrefix;

    public static void Menu()
    {
        string? response = "c";

        while (response?.ToLower() != "e")
        {
            if (response != null && response.ToLower() == "r")
            {
                Console.WriteLine("Enter a specific day to run or press enter to run all days:");
                int dayResponse = Convert.ToInt32(Console.ReadLine());
                Runday(dayResponse > 25 ? 0 : dayResponse);
                return;
            }
            else if (response != null && response.ToLower() == "b")
            {
                Console.WriteLine("enter new base path:");
                string? newBasePath = Console.ReadLine();
                if (newBasePath != null && newBasePath != "")
                {
                    if (!newBasePath.EndsWith(@"\"))
                    {
                        newBasePath += @"\";
                    }
                    basePath = newBasePath;
                }
                Console.WriteLine($"new base path: {basePath}");
            }
            else if (response != null && response.ToLower() == "f")
            {
                Console.WriteLine("enter new file name prefix:");
                string? newFileNamePrefix = Console.ReadLine();
                if (newFileNamePrefix != null)
                {
                    fileNamePrefix = newFileNamePrefix;
                }
                Console.WriteLine($"new file name prafix : {fileNamePrefix}");
            }
            else if (response != null && response.ToLower() == "p")
            {
                Console.WriteLine($"default file path for puzzle inputs is basepath: {defaultBasePath} file name prefix: {defaultFileNamePrefix} number of puzzle day" + "X.txt");
                Console.WriteLine("Total default path: ");
                Console.WriteLine($"{defaultBasePath}{defaultFileNamePrefix}X.txt");
                Console.WriteLine($"Current base path: {basePath}");
                Console.WriteLine($"Current file name prefix: {fileNamePrefix}");
                Console.WriteLine("Total current path: ");
                Console.WriteLine($"{basePath}{fileNamePrefix}X.txt");
            }
            else if (response != null && response.ToLower() == "c")
            {
                Console.Clear();
                Console.WriteLine("change nothing and run (r)");
                Console.WriteLine("change base path (b)");
                Console.WriteLine("change file name prefix (f)");
                Console.WriteLine("View default path and current path (p)");
                Console.WriteLine("clear screen (c)");
                Console.WriteLine("end (e)");
            }

            response = Console.ReadLine();
        }
    }

    public static void Runday(int day)
    {
        if (day > 0)
        {
            Runday(day.ToString());
        }
        else if (day == 0)
        {
            for (day = 1; day < 26; day++)
            {
                Runday(day.ToString());
            }
        }
    }

    public static void Runday(string day)
    {
        Type? type = Type.GetType($"Adventofcode2025.Days.Day{day}");
        for (int part = 1; part < 3; part++)
        {
            string name = $"Part{part}";
            MethodInfo? method = type?.GetMethod(name);
            if(method != null)
            {
                var input = File.ReadLines($"{basePath}{fileNamePrefix}{day}.txt");
                object? result = method?.Invoke(null, new object[] { input });
                Console.WriteLine($"day {day} part {part}: {result}");
            }
            else
            {
                Console.WriteLine($"day {day} part {part}: not found");
            }
        }
    }
}



