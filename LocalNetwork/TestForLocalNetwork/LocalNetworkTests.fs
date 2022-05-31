module TestForLocalNetwork

open LocalNetwork
open NUnit.Framework
open FsUnit
open Foq

[<SetUp>]
let Setup () =
    ()

[<Test>]
let TestForNetworkWithProbability0 () =
    let linux = OS("Linux", 0f)
    let windows = OS("Windows", 0f)
    let comp1 = Computer(linux)
    let comp2 = Computer(linux)
    let comp3 = Computer(windows)
    let matrix = [ [true; true; false]; [true; true; true]; [false; true; true] ]
    let network = Network(array2D matrix, [| comp1; comp2; comp3;|])
    network.RunInfection() |> should equal Seq.empty
    for comp in network.Computers do
        comp.Infected |> should equal false
    
[<Test>]        
let TestForNetworkWithProbability1 () =
    let linux = OS("Linux", 1f)
    let windows = OS("Windows", 1f)
    let comp1 = Computer(linux)
    comp1.Infected <- true
    let comp2 = Computer(linux)
    let comp3 = Computer(windows)
    let matrix = [ [true; true; false]; [true; true; true]; [false; true; true] ]
    let network = Network(array2D matrix, [| comp1; comp2; comp3;|])
    let answers = [| "Компьютер 0 заразил компьютер 1"; "Компьютер 1 заразил компьютер 2" |]
    let result = Seq.toArray ( network.RunInfection ())
    result |> should equal answers

[<Test>]
let TestWithMock () =
    let randomizer () = 0.7f 
    let linux = OS("Linux", 0.8f)
    let windows = OS("Windows", 0.5f)
    let comp1 = Computer(linux)
    comp1.Infected <- true
    let comp2 = Computer(linux)
    let comp3 = Computer(windows)
    let matrix = [ [true; true; false]; [true; true; true]; [false; true; true] ]
    let network = Network(array2D matrix, [| comp1; comp2; comp3;|], randomizer)
    network.RunInfectionOneStep () |> should equal "Компьютер 0 заразил компьютер 1"
    network.RunInfectionOneStep () |> should equal "Компьютеру 1 не удалось заразить компьютер 2"