module Main

open System
open Options
open Generator
open CommandLine

[<EntryPoint>]
let main argv = 
    let result = CommandLine.Parser.Default.ParseArguments<options>(argv)
    
    // TODO: Return a non-zero return code in NotParsed scenario
    match result with
    | :? Parsed<options> as parsed -> generate parsed.Value
    | :? NotParsed<options> as notParsed -> printf "%A" notParsed.Errors
    | _ -> failwith "Invalid command line parser result"

    0 // exit
