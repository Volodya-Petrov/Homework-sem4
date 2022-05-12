type Tree<'a> =
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Empty

let treeFilter tree filter =
    let rec recursiveFilter tree acc =
        match tree with
        | Empty -> acc
        | Tree(value, left, right) ->
            let result acc = recursiveFilter right (recursiveFilter left acc)
            match filter value with
            | true -> 
                 result (value :: acc)
            | false -> result acc
    recursiveFilter tree []
                
        
let tree = Tree(4, Tree(3, Empty, Empty), Tree(5, Empty, Tree(6, Empty, Empty)))
// For more information see https://aka.ms/fsharp-console-apps
printfn "%A" (treeFilter tree (fun x -> x > 3))