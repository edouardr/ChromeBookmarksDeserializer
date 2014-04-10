namespace ChromeBookmarksDeserializer.CommandLineOptions
{
    using CommandLine;
    using CommandLine.Text;

    // Define a class to receive parsed values
    class Options
    {
        [Option('r', "read", Required = true,
          HelpText = "Input file to be processed.")]
        public string InputFile { get; set; }

        [Option('w', "write", Required = true,
          HelpText = "Output file to be generated.")]
        public string OutputFile { get; set; }

        [Option('v', "verbose", DefaultValue = true,
          HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
