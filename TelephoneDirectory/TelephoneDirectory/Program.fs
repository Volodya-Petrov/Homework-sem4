open System
open PhoneDirectory


let rec program data =
    printfn
        "
        Список команд:\n
        0) Выйти
        1) Добавить запись
        2) Найти телефон по имени
        3) Найти имя по телефону
        4) Вывести содержимое всей базы
        5) Сохранить текущие данные в файл
        6) Считать данные из файла
        "
    let command = Console.ReadLine()
    match command with
    | "0" -> printf "Выход"
    | "1" ->
        printfn "Введите имя:"
        let name = Console.ReadLine()
        printfn "Введите номер:"
        let number = Console.ReadLine()
        let newData = addRecord data name number
        program newData
    | "2" ->
        printfn "Введите имя:"
        let name = Console.ReadLine()
        let numbers = findPhone data name
        if Seq.length numbers = 0 then
            printfn "Не существует номера по такому имени"
        else
            numbers |> Seq.iter (printfn "%s")
        program data
    | "3" ->
        printfn "Введите номер:"
        let number = Console.ReadLine()
        match findName data number with
        | None -> printfn "Нет записи"
        | Some(name) -> printfn $"{name}"
        program data
    | "4" ->
        PrintData data
        program data
    | "5" ->
        printfn "Введите путь к файлу"
        let path = Console.ReadLine()
        writeDataInFile data path
        program data
    | "6" ->
        printfn "Введите путь к файлу"
        let path = Console.ReadLine()
        let newData = readDataFromFile path
        program newData
    | _ -> program data
program Seq.empty

// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"