open System

/// Считает факториал числа
let factorial number =
    if number < 0 then failwith "Число должно быть не меньше нуля" 
    let rec factorialHelper acc i number =
        if i >= number then
            acc * i
        else
            factorialHelper (acc * i) (i + 1) number
    factorialHelper 1 1 number

/// Выдает число фибоначчи с номером "number"
let fibonacci number =
    if number < 0 then failwith "Число должно быть не меньше нуля" 
    let rec fibonacciHelper acc1 acc2 i =
        if i >= number then
            acc1
        else
            fibonacciHelper acc2 (acc1 + acc2) (i + 1)
    fibonacciHelper 0 1 1
    
/// возвращает перевернутый список
let reverse list =
    let rec reverseHelper list reverseList =
        match list with
        | [] -> reverseList
        | h :: t -> reverseHelper t (h :: reverseList)
    reverseHelper list []
    
/// выдает индекс элемента в списке
let findElement list element =
    let rec findHelper list element i =
        match list with
        | [] -> None
        | h::t when h = element -> Some(i)
        | _ -> findHelper (List.tail list) element (i + 1)
    findHelper list element 0

/// генерирует список степеней двойки от 2^n до 2^m
let rec generateList n m =
    if m - n < 0 then failwith "m должно быть больше n"
    let rec generateListHelper i list =
        if i = 0 then list else
        generateListHelper (i - 1) (((List.head list) * 2.0)::list)
    List.rev (generateListHelper (m - n) [pown 2.0 n])
    
let x = generateList 4 2
printfn "%A" x    