module TestsForPointFree

open PointFree
open NUnit.Framework
open FsCheck

[<Test>]
let CheckFunctionsForEquivalenceTest () =
    let equivalenceFunction x l =
        withoutPointFree x l = pointFree'2 x l
    Check.QuickThrowOnFailure equivalenceFunction