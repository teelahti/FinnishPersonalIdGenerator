module Main

open System
open Options
open Generator
open CommandLine

[<EntryPoint>]
let main argv = 
    let result = CommandLine.Parser.Default.ParseArguments<options>(argv)
    
    // TODO: Return non-zero return code when parsing fails
    match result with
    | :? Parsed<options> as parsed -> generate parsed.Value
    | :? NotParsed<options> as notParsed -> printf "%A" notParsed.Errors
    | _ -> ()

    0 // exit
