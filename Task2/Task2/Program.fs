module Program

let countEvenNumbers1 ls = ls |> List.fold (fun acc elem -> acc + abs((elem + 1) % 2)) 0

let countEvenNumbers2 ls = ls |> List.filter (fun x -> x % 2 = 0) |> List.length

let countEvenNumbers3 ls = ls |> List.map (fun x -> abs((x + 1) % 2)) |> List.sum 



type Tree<'a> =
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Tip of 'a

let rec createNewTree func tree =
    match tree with
    | Tree(value, left, right) -> Tree(func value, createNewTree func left, createNewTree func right)
    | Tip(value) -> Tip(func value)

type BinOperation<'a> = 'a -> 'a -> 'a
    
type ParseTree<'a> =
    | Value of 'a
    | ParseTree of ParseTree<'a> * ParseTree<'a> * BinOperation<'a>
    
let rec calculateParseTree tree =
    match tree with
    | Value(value) -> value
    | ParseTree(left, right, operator) -> operator (calculateParseTree left) (calculateParseTree right)

let generatePrimeNums =
    let rec isPrime n acc =
        if acc = (int (sqrt (float n)) + 1) then
            true
        else
            if  n % acc = 0 then
                false
            else
                isPrime n (acc + 1)
    let rec primeNumbers currentNumber =
        seq {
            if isPrime currentNumber 2 then
                yield currentNumber
            yield! primeNumbers (currentNumber + 1)
        }
    primeNumbers 2
            

let a = countEvenNumbers1 [-2]
printfn "%A"