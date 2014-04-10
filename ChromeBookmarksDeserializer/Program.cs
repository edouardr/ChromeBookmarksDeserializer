namespace ChromeBookmarksDeserializer
{
    using System;
    using System.IO;
    using ChromeBookmarksDeserializer.CommandLineOptions;
    using ChromeBookmarksDeserializer.JsonModels;
    using Newtonsoft.Json;

    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (!CommandLine.Parser.Default.ParseArguments(args, options))
            {
                #if DEBUG
                    Console.WriteLine("Press enter to close...");
                    Console.ReadLine();
                #endif
                return;
            }

            BookmarkRoot bm;

            // Values are available here
            if (options.Verbose) Console.WriteLine("Starting convertion.");
            if (options.Verbose) Console.WriteLine("Source Filename: {0}", options.InputFile);

            if (!File.Exists(options.InputFile))
            {
                Console.WriteLine("{0} doesn't exists. Please provide an existing file.", options.InputFile);
                Console.ReadLine();
            }

            if (File.Exists(options.OutputFile))
            {
                Console.WriteLine("{0} already exists.", options.OutputFile);
                Console.ReadLine();
            }

            using (var r = new StreamReader(options.InputFile))
            {
                var json = r.ReadToEnd();
                bm = JsonConvert.DeserializeObject<BookmarkRoot>(json);
            }

            using (var r = new StreamWriter(options.OutputFile))
            {
                r.Write(bm.ToString());
            }
            Console.WriteLine("Convertion made.");

            Console.ReadLine();
        }
    }
}
