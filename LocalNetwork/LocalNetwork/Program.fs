module Program
open LocalNetwork
// For more information see https://aka.ms/fsharp-console-apps
let linux = OS("Linux", 1f)
let windows = OS("Windows", 1f)
let comp1 = Computer(linux)
let comp2 = Computer(linux)
let comp3 = Computer(windows)
let comp4 = Computer(windows)
comp1.Infected <- true
let matrix = [ [true; true; false; true]; [true; true; true; false]; [false; true; true; true]; [true; false; true; true] ]
let network = Network(array2D matrix, [| comp1; comp2; comp3; comp4 |])
let result = network.RunInfectionOneStep ()
let result1 = network.RunInfectionOneStep ();
(network.RunInfection()) |> Seq.iter (fun x -> printfn "%s" x)
