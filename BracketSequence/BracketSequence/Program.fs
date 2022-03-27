open Microsoft.FSharp.Core

let isBracketSequenceCorrect seq =
   let closeBracketToOpen char =
       match char with
       | ')' -> '('
       | ']' -> '['
       | '}' -> '{'
       | _ -> failwith "Unexpected token"
       
   let rec checkCorrectness seq i stack =
      if String.length seq = i then (true, List.length stack) else
      let char = seq[i]
      match char with
      | '(' | '[' | '{' as bracket -> checkCorrectness seq (i + 1) (bracket::stack)
      | ')' | ']' | '}' as bracket ->
        if List.length stack = 0 || not (List.head stack = (closeBracketToOpen bracket)) then (false, 0)
        else checkCorrectness seq (i + 1) (List.tail stack)
      | _ -> failwith "Unexpected token"
   
   let result, length = checkCorrectness seq 0 []
   result && length = 0
    

// For more information see https://aka.ms/fsharp-console-apps
printfn "%b" (isBracketSequenceCorrect "([[)])")