module TestForPriorityQueue

open NUnit.Framework
open FsUnit
open Test2

[<Test>]
let TestForEnqueueAndDequeue () =
    let queue = PriorityQueue()
    queue.Enqueue(2, 2)
    queue.Enqueue(5, 4)
    queue.Enqueue(1, 3)
    queue.Count |> should equal 3
    queue.Dequeue() |> should equal 5
    queue.Dequeue() |> should equal 1
    queue. Dequeue() |> should equal 2
    queue.Count |> should equal 0
    
[<Test>]
let TestWithEmptyQueue () =
    let queue = PriorityQueue()
    (fun () -> queue.Dequeue() |> ignore) |> should throw typeof<System.InvalidOperationException>