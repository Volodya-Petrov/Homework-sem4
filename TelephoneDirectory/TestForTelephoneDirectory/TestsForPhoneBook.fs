module TestForTelephoneDirectory

open Microsoft.FSharp.Core
open NUnit.Framework
open FsUnit
open PhoneDirectory

[<Test>]
let testAddRecord () =
    let data = seq {("mike", "99999"); ("leva", "1337")}
    addRecord data "lol" "555" |> should equal (seq {("mike", "99999"); ("leva", "1337"); ("lol","555")})

[<Test>]
let testAddRecordWithExistingNumber () =
    addRecord (seq {("lol", "123")}) "kek" "123" |> should equal (seq {("lol", "123")})

[<Test>]
let testFindName () =
    let data = seq {("mike", "99999"); ("leva", "1337")}
    findName data "99999" |> should equal (Some("mike"))
    findName data "4" |> should equal None
    
[<Test>]
let testFindNumber () =
    let data = seq {("mike", "99999"); ("leva", "1337")}
    findPhone data "mike" |> should equal (seq{"99999"})
    
[<Test>]
let testReadFile () =
    readDataFromFile "../../../read.txt" |> should equal (seq{("lol", "444"); ("kek", "333")})
    
[<Test>]
let testWriteFile () =
    let data = seq {("mike", "99999"); ("leva", "1337")}
    writeDataInFile data "../../../write.txt"
    readDataFromFile "../../../write.txt" |> should equal (seq {("mike", "99999"); ("leva", "1337")})