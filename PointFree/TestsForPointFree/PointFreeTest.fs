module TestsForPointFree

open NUnit.Framework
open FsCheck
open Program

[<Test>]
let CheckFunctionsForEquivalenceTest () =
    let equivalenceFunction x l =
        let pointFree = pointFree'2 ()
        withoutPointFree x l = pointFree x l
    Check.QuickThrowOnFailure equivalenceFunction