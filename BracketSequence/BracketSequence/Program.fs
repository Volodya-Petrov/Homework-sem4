open Microsoft.FSharp.Core

let isBracketSequenceCorrect seq =
   let closeBracketToOpen char =
       match char with
       | ')' -> '('
       | ']' -> '['
       | '}' -> '{'
       | _ -> failwith "Unexpected token"
       
   let rec checkCorrectness seq i stack =
      if String.length seq = i then
          let length = List.length stack
          if length > 0 then false else true
      else
      let char = seq[i]
      match char with
      | '(' | '[' | '{' as bracket -> checkCorrectness seq (i + 1) (bracket::stack)
      | ')' | ']' | '}' as bracket ->
        match stack with
        | [] -> false
        | h::t-> if h <> (closeBracketToOpen bracket) then false else checkCorrectness seq (i + 1) t
      | _ -> failwith "Unexpected token"
   
   checkCorrectness seq 0 []
    

// For more information see https://aka.ms/fsharp-console-apps
printfn "%b" (isBracketSequenceCorrect "([[)])")