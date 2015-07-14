module Generator

open System
open Extensions
open PersonalId
open Options

let random = new Random()

let generate options = 
    // Use pattern matching to check start < end

    // If useHighSuffix is given, then weight the tail of the 2..999 
    // personal id suffix range. This is count-dependent: if a very 
    // high count of personal id's is requested, then lower the start
    // of range by 100 for every 25k ids.
    let randSuffix = 
        let start = 900 - options.count/25000 * 100

        if options.useHighSuffix then (fun _ -> random.Next((if start < 2 then 2 else start), 999))
        else (fun _ -> random.Next(2, 999))

    let ``first tick of the year`` x = (new DateTime(x, 1, 1)).Ticks
    let ``last tick of the year`` x = ``first tick of the year``(x + 1) - 1L

    let generator = 
        let rangeStart = options.startYear |> ``first tick of the year``
        let rangeEnd = options.endYear |> ``last tick of the year``
        Seq.initInfinite (fun _ -> new PersonalId(new DateTime(random.NextLong(rangeStart, rangeEnd))))
    
    let appendDate (x : PersonalId) = x.SeedDate.ToString("ddMMyy") |> x.Append
    let appendDivider (x : PersonalId) = divider x.SeedDate.Year |> x.Append
    let appendSuffix (x : PersonalId) = randSuffix().ToString("000") |> x.Append
    let appendHash (x : PersonalId) = hash x.Result |> Convert.ToString |> x.Append

    let pipeline = appendDate >> appendDivider >> appendSuffix >> appendHash

    generator 
        |> Seq.map (pipeline) 
        |> Seq.take options.count 
        |> Seq.distinct  // This causes extra memory pressure on high counts
        |> Seq.iter (fun (x) -> printfn "%s" x.Result)