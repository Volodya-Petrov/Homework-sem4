module TestsForWorkflows

open NUnit.Framework
open WorkFlow
open FsUnit

[<Test>]
let TestWithStringCalculation () =
    let converter = CalculateNumbersBuilder()
    let result = converter {
        let! x = "3"
        let! y = "2"
        return x + y
    }
    result |> should equal (Some(5))

[<Test>]
let TestWithStringCalculationIncorrectValue () =
    let converter = CalculateNumbersBuilder()
    let result = converter {
        let! x = "3"
        let! y = "f"
        return x + y
    }
    result |> should equal None
    
[<Test>]
let TestWithRoundCalculation() =
    let rounder = CalculateWithRoundBuilder(3)
    let result = rounder {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
    }
    result |> should equal 0.048