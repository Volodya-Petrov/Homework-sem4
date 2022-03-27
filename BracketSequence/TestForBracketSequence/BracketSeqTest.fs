module TestForBracketSequence

open NUnit.Framework
open FsUnit
open Program

[<Test>]
let testCorrectCase1 () =
    isBracketSequenceCorrect "()" |> should equal true
    
[<Test>]
let testCorrectCase2 () =
    isBracketSequenceCorrect "([{}])" |> should equal true

[<Test>]
let testCorrectCase3 () =
    isBracketSequenceCorrect "(){}[]" |> should equal true
    
[<Test>]
let testIncorrectCase1 () =
    isBracketSequenceCorrect "([{}]" |> should equal false
    
[<Test>]
let testIncorrectCase2 () =
    isBracketSequenceCorrect "([})" |> should equal false

[<Test>]
let testIncorrectCase3 () =
    isBracketSequenceCorrect "([{}]))" |> should equal false