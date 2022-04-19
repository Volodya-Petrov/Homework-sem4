module Program

open WorkFlow

let converter = CalculateNumbersBuilder()

let result = converter {
    let! x = "f"
    let! y = "2"
    return x + y
}

let rounder = CalculateWithRoundBuilder(3)
let result2 = rounder {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    }

// For more information see https://aka.ms/fsharp-console-apps
printfn "%f" result2