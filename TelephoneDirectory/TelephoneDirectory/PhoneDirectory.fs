module PhoneDirectory

open System.IO
open Microsoft.FSharp.Core
open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

let addRecord directory name number =
    if (directory |> Seq.filter (fun (_, b) -> b = number) |> Seq.length) > 0
    then directory
    else Seq.append directory (seq {(name, number)})
    
let findPhone directory name =
    directory |> Seq.filter (fun (nameInDirectory, number) -> nameInDirectory = name) |> Seq.map (fun (_, number) -> number)
    
let findName directory phone =
    let names = directory |> Seq.filter (fun (name, number) -> number = phone) |> Seq.map (fun (name, _) -> name)
    if Seq.length names = 0 then
        None
    else
        Some(Seq.head names)
    
let readDataFromFile path =
    let reader =
        seq {
            use reader = new StreamReader(
                File.OpenRead(path)
            )
            while not reader.EndOfStream do
            yield reader.ReadLine() }
    reader
        |> Seq.filter(fun x -> x |> System.String.IsNullOrWhiteSpace |> not)
        |> Seq.map(fun x -> x.Split([|' '|], System.StringSplitOptions.RemoveEmptyEntries))
        |> Seq.map(fun x -> (x.[0], x.[1]))
        
let PrintData directory =
    directory |> Seq.iter (fun (name, number) -> printfn "%s - %s" name number)
    
let writeDataInFile (data:seq<string*string>) (path:string) =
    use writer = new StreamWriter(path)
    data
    |> Seq.map (fun (name, number) -> ($"{name} {number}"))
    |> Seq.iter writer.WriteLine