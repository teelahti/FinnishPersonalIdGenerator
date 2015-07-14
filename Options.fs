module Options

open CommandLine

type options = {
  [<Option('c', "count", Required = true, HelpText = "Count of personal IDs created.")>] count : int;
  [<Option('s', "start", Default = 1988, HelpText = "Starting year for generated IDs.")>] startYear : int;  
  [<Option('e', "end", Default = 2010, HelpText = "Ending year (inclusive) for generated IDs.")>] endYear : int;
  [<Option(Default = true, HelpText = "Use high suffix range to decrease change of creating a real personal id.")>] useHighSuffix : bool;
}

