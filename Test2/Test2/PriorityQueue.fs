namespace Test2

open System.Collections.Generic

type private QueueElement(value:int, priority:int) =
    let value = value
    let priority = priority
    
    member public this.Value with get () = value
    
    member public this.Priority with get () = priority

type public PriorityQueue () =
    let mutable queue = List<QueueElement>()
    
    member public this.Count with get () = queue.Count
    
    member public this.Enqueue (value, priority) =
        let mutable i = 0
        while queue.Count > 0 && queue[i].Priority > priority do
            i <- i + 1
        queue.Insert(i, QueueElement(value, priority))
        
    member public this.Dequeue () =
        if queue.Count = 0 then
            raise (System.InvalidOperationException("Очередь пуста"))
        else
            let value = queue[0].Value
            queue.RemoveAt(0)
            value