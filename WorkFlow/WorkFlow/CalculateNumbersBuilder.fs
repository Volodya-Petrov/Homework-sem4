namespace WorkFlow

open System

type CalculateNumbersBuilder() =
    let convertStrToInt (s:string) =
        match Int32.TryParse s with
        | false, _ -> None
        | _, x -> Some(x)
    
    member this.Bind(x, f) =
        let parsed = convertStrToInt x
        match parsed with
        | None -> None
        | Some(value) -> f value
    
    member this.Return(x) = Some(x)
        