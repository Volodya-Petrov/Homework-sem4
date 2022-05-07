module TestForLambdaInterpreter

open Program
open NUnit.Framework
open FsUnit

[<Test>]
let TestBetaReductionWithLambdaAbstraction () =
    let termForTest = LambdaAbstraction(1, Application(Variable(1), Application(Variable(1), Variable(1))))
    let term = Application(LambdaAbstraction(1, Variable(2)), Application(termForTest, termForTest))
    betaReduction term |> should equal (Variable(2))
    
[<Test>]
let TestAfterApplicationLambdaAbstraction () =
    let term = (Application(Application(LambdaAbstraction(1, Variable(1)), LambdaAbstraction(1, Application(Variable(1), Variable(1)))), Variable(2)))
    betaReduction term |> should equal (Application(Variable(2), Variable(2)))

[<Test>]
let TestBetaReductionForVariable () =
    betaReduction (Variable(1)) |> should equal (Variable(1))
    
[<Test>]
let TestWithRenaming () =
    let termForSubstitution = LambdaAbstraction(1, Application(Variable(1), Variable(2)))
    let termInAnswer = Application(Variable(3), Application(Variable(1), Variable(2)))
    substitution termForSubstitution (Application(Variable(1), Variable(2))) 2 |> should equal (LambdaAbstraction(3, termInAnswer))