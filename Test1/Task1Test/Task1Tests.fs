module Task1Test

open NUnit.Framework
open FsCheck
open Program
open FsUnit

[<Test>]
let TestEquivalenceForMinFunctions () =
    let funEqual (list: int list) =
        if List.isEmpty list then true else
        List.min list = findMin list
    Check.QuickThrowOnFailure funEqual
    
[<Test>]
let TestWithEmptyList () =
    (fun () -> findMin [] |> ignore) |> should throw typeof<System.ArgumentException>