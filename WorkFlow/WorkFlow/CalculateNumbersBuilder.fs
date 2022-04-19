namespace WorkFlow

open System

type CalculateNumbersBuilder() =
    let convertStrToInt (s:string) =
        let mutable x = int16 0
        match Int16.TryParse(s, &x) with
        | false -> None
        | _ -> Some(int x)
    
    member this.Bind(x, f) =
        let parsed = convertStrToInt x
        match parsed with
        | None -> None
        | Some(value) -> f value
    
    member this.Return(x) = Some(x)
        