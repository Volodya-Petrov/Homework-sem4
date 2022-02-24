
let factorial number =
    let rec factorialHelper acc i number =
        if i >= number then
            acc * i
        else
            factorialHelper (acc * i) (i + 1) number
    factorialHelper 1 1 number


let x = factorial 0 
printfn "%i" x      