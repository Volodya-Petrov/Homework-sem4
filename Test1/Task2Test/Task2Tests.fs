module Task2Test

open NUnit.Framework
open FsUnit
open Program

[<Test>]
let TestOnCorrectness () =
    let tree = Tree(4, Tree(3, Empty, Empty), Tree(5, Empty, Tree(6, Empty, Empty)))
    treeFilter tree (fun x -> x > 3) |> should equal [6; 5; 4]

[<Test>]
let TestOnCorrectnessWithEmptyList () =
    let tree = Tree (1, Tree(2, Empty, Empty), Tree(3, Empty, Empty))
    (treeFilter tree (fun x -> x > 3)).Length |> should equal 0
