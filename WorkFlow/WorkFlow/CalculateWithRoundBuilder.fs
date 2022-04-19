namespace WorkFlow

open System

type CalculateWithRoundBuilder(accuracy:int) =
    let accuracy = accuracy
    
    member this.Bind(x:float, f) =
        f (Math.Round(x, accuracy))
        
    member this.Return(x:float) = Math.Round(x, accuracy)