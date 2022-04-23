namespace WorkFlow

open System

type CalculateWithRoundBuilder(accuracy:int) =
    do
        if accuracy < 0 then raise (System.ArgumentException("Передано отрицательное значение"))
    
    member this.Bind(x:float, f) =
        f (Math.Round(x, accuracy))
        
    member this.Return(x:float) = Math.Round(x, accuracy)