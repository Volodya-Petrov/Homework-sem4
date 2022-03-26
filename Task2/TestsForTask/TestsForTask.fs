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
let mapTreeTest () =
    let tree = Tree(5, Tree(2, Tip(4), Tip(3)), Tip(6))
    mapTree (fun x -> x + 1) tree |> should equal (Tree(6, Tree(3, Tip(5), Tip(4)), Tip(7)))
    
[<Test>]
let ParseTreeTest () =
    let tree1 = ParseTree(Value(3), ParseTree(Value(4), Value(5), (*)), (+))
    let tree2 = ParseTree(ParseTree(Value(4), Value(5), (*)), ParseTree(Value(4), Value(5), (*)), (+))
    let tree3 = ParseTree(ParseTree(Value(4), Value(5), (*)), Value(3), (+))
    calculateParseTree tree1 |> should equal 23
    calculateParseTree tree2 |> should equal 40
    calculateParseTree tree3 |> should equal 23
    

[<Test>]
let primeNumsTest () =
    let first5PrimeNums = [ for i in 0 .. 4 -> Seq.item i (generatePrimeNums()) ]

    first5PrimeNums |> should equal [ 2; 3; 5; 7; 11]
    

    
         