/// Считает факториал числа
let factorial number =
    let rec factorialHelper acc i number =
        if i >= number then
            acc * i
        else
            factorialHelper (acc * i) (i + 1) number
    factorialHelper 1 1 number

/// Выдает число фибоначчи с номером "number"
let fibonacci number =
    let rec fibonacciHelper number acc1 acc2 i =
        if i >= number then
            acc1
        else
            fibonacciHelper number acc2 (acc1 + acc2) (i + 1)
    fibonacciHelper number 0 1 1
    
/// возвращает перевернутый список
let reverse list =
    let rec reverseHelper list reverseList =
        if list = [] then
            reverseList
        else
            reverseHelper (List.tail list) ((List.head list)::reverseList)
            
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
let generateList n m =
    let rec pow element degree =
        if degree <= 0 then
            element
        else
            pow (element * 2.0) (degree - 1)
    let firstElement = pow 1.0 (abs n)
    let rec generateListHelper i list =
        if i = 0 then
            list
        else
            generateListHelper (i - 1) (((List.head list) * 2.0)::list)
    if n >= 0 then
        List.rev (generateListHelper (m - n) [firstElement])
    else
        List.rev (generateListHelper (m - n) [1.0 / firstElement])
    
let x = generateList -2 0
printfn "%A" x    