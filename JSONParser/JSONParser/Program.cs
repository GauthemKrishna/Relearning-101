namespace JSONParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if !DEBUG
            if(!(args.Length > 0))
            {
                Console.WriteLine("Please specify file");
                return;
            }
            var file = args.Last();
#else
            var file = @"C:\Users\gauth\OneDrive\Documents\Projects\Relearning-101\JSONParser\tests\step2\valid2.json";
#endif
            var text = string.Empty;
            if(File.Exists(file))
            {
                text = File.ReadAllText(file).Trim();
            }

            if (!text.StartsWith("{") || !text.EndsWith("}"))
            {
                Console.WriteLine("Invalid JSON");
                return;
            }

            Console.WriteLine("Valid JSON");
            text = text.Remove(0, 1);
            text = text.Remove(text.Length-1, 1);

            List<string> items = new List<string>();
            items.AddRange(text.Split(',').Select(x=> x.Trim()));
            List<object> json = new List<object>;
            foreach(string item in items)
            {
                objectitem.Replace("\"", string.Empty)
            }
        }
    }
}