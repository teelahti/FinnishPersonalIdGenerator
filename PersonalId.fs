module PersonalId

open System

type PersonalId(d : DateTime, result) =
    new(d:DateTime) = PersonalId(d, String.Empty) 
    member x.SeedDate = d
    member x.Result = result
    member x.Append(s) = new PersonalId(x.SeedDate, x.Result + s)

let divider = function
    | year when year < 1900 -> "+"
    | year when year < 2000 -> "-"
    | _ -> "A"

// This does not include all the alphabets, only the ones that are in the personal ID spec.
let suffixes = "0123456789ABCDEFHJKLMNPRSTUVWXY".ToCharArray()

let hash (x : string) = 
    let remainder = x.Substring(0, 6) + x.Substring(7) |> Int32.Parse |> (%) <| 31

    // If remainder is less than 10, return it as is. 
    // Otherwise return from predefined char map.
    if remainder < 10 then
        remainder |> Convert.ToString |> Char.Parse
    else
        suffixes.[remainder]

