module TestsForTask

open NUnit.Framework
open FsCheck
open FsUnit
open Program



[<Test>]
let checkSumFunctionsForEquivalenceTest () =
    let checkSumFunctionsForEquivalence x =
        let firstEqualSecond = countEvenNumbers1 x = countEvenNumbers2 x
        let firstEqualThird = countEvenNumbers1 x = countEvenNumbers3 x
        match firstEqualSecond, firstEqualThird with
        | true, true -> true
        | _ -> false
    Check.QuickThrowOnFailure checkSumFunctionsForEquivalence
    
[<Test>]
let countEvenNumbersTest () =
    countEvenNumbers1 [1; 2; 3; 4; 5; 6; 7; 8] |> should equal 4
    
[<Test>]
let createNewTreeTest () =
    let rec traverseTree tree ls =
        match tree with
        | Tree(value, left, right) -> (traverseTree right ls) @ (value :: (traverseTree left ls)) 
        | Tip(value) ->  value :: ls
    
    let tree = Tree(5, Tree(2, Tip(4), Tip(3)), Tip(6))
    traverseTree tree [] |> should equal (List.rev [4; 2; 3; 5; 6])
    
[<Test>]
let ParseTreeTest () =
    let tree = ParseTree(Value(3), ParseTree(Value(4), Value(5), (*)), (+))
    calculateParseTree tree |> should equal 23
    

[<Test>]
let primeNumsTest () =
    let first5PrimeNums = [ for i in 0 .. 4 -> Seq.item i (generatePrimeNums()) ]

    first5PrimeNums |> should equal [ 2; 3; 5; 7; 11]
    

    
         