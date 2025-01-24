using System;
using System.IO;
using System.Text;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        bool isStandardInputRedirected = Console.IsInputRedirected;

        string standardInput = string.Empty;
        string file = string.Empty;

        if (isStandardInputRedirected)
        {
            standardInput = Console.In.ReadToEnd();
        }
        else if (args.Length > 0)
        {
            file = args.Last();
            if (!File.Exists(file))
            {
                Console.WriteLine("File does not exist");
                return;
            }
            args = args.SkipLast(1).ToArray();
        }
        else
        {
            Console.WriteLine("No input provided");
            return;
        }

        if (args.Length == 0)
        {
            args = new string[] { "-c", "-l", "-w"};
        }

        StringBuilder stringBuilder = new StringBuilder();

        foreach (string arg in args)
        {
            string content = isStandardInputRedirected ? standardInput : File.ReadAllText(file);

            switch (arg)
            {
                case "-c": 
                    stringBuilder.Append(isStandardInputRedirected
                        ? Encoding.UTF8.GetByteCount(standardInput)
                        : File.ReadAllBytes(file).Length);
                    break;

                case "-l": 
                    stringBuilder.Append(isStandardInputRedirected
                        ? standardInput.Split(new[] { '\n' }).Length
                        : File.ReadAllLines(file).Length);
                    break;

                case "-w":
                    stringBuilder.Append(content.Split(
                        new[] { ' ', '\t', '\n', '\r' },
                        StringSplitOptions.RemoveEmptyEntries).Length);
                    break;

                case "-m": 
                    stringBuilder.Append(content.Length);
                    break;

                default:
                    stringBuilder.Append("Invalid argument");
                    break;
            }
            stringBuilder.Append(" ");
        }

        Console.WriteLine($"{stringBuilder.ToString().TrimEnd()} {(isStandardInputRedirected ? "" : file)}");
    }
}
