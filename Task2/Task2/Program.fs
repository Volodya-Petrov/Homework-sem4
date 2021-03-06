module Program

/// Считает количество четных числе в списке
let countEvenNumbers1 ls = ls |> List.fold (fun acc elem -> acc + abs((elem + 1) % 2)) 0

/// Считает количество четных числе в списке
let countEvenNumbers2 ls = ls |> List.filter (fun x -> x % 2 = 0) |> List.length

/// Считает количество четных числе в списке
let countEvenNumbers3 ls = ls |> List.map (fun x -> abs((x + 1) % 2)) |> List.sum 



type Tree<'a> =
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Empty

/// Применяет полученные функцию ко всем элементам дерева и возвращает новое дерево
let rec mapTree func tree =
    match tree with
    | Tree(value, left, right) -> Tree(func value, mapTree func left, mapTree func right)
    | Empty -> Empty

type BinOperation<'a> = 'a -> 'a -> 'a
    
type ParseTree<'a> =
    | Value of 'a
    | ParseTree of ParseTree<'a> * ParseTree<'a> * BinOperation<'a>
    
/// Считает результат выражения записанного с помощью дерева разбора
let rec calculateParseTree tree =
    match tree with
    | Value(value) -> value
    | ParseTree(left, right, operator) -> operator (calculateParseTree left) (calculateParseTree right)

/// Генерирует бесконечную последовательность простых чисел
let generatePrimeNums () =
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