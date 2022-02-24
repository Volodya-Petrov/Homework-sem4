
let factorial number =
    let rec factorialHelper acc i number =
        if i >= number then
            acc * i
        else
            factorialHelper (acc * i) (i + 1) number
    factorialHelper 1 1 number

let fibonacci number =
    let rec fibonacciHelper number acc1 acc2 i =
        if i >= number then
            acc1
        else
            fibonacciHelper number acc2 (acc1 + acc2) (i + 1)
    fibonacciHelper number 0 1 1
    
let reverse list =
    let rec reverseHelper list reverseList =
        if list = [] then
            reverseList
        else
            reverseHelper (List.tail list) ((List.head list)::reverseList)
            
    reverseHelper list []
let x = reverse [1]
printfn "%A" x      