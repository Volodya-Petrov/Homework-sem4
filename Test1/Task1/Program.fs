open System

let findMin list =
    if List.isEmpty list then
        raise (System.ArgumentException("Список пуст"))
    else
        List.fold (fun acc x -> if x < acc then x else acc) (List.head list) list

// For more information see https://aka.ms/fsharp-console-apps
printfn "Min Element is %d" (List.min [])