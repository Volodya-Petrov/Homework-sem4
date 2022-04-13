namespace LocalNetwork

type public Network(matrix: bool[,], computers:Computer[]) =
    let matrix = matrix
    let computers = computers
    let visited = Array.create computers.Length false
    
    let mutable result : seq<string> = Seq.empty
    let mutable counted = false
    
    let printState () =
        seq {
            for i in 0 .. computers.Length - 1 do
                yield "Компьютер " + i.ToString() + (if computers[i].Infected then " заражен" else " не заражен")
        }
    
    let rec runDfs prev current =
        seq { 
        visited[current] <- true
        if computers[current].OS.ProbabilityInfection <> 0f then
            let random = System.Random()
            if computers[current].Infected = false then
                while (random.NextSingle() > computers[current].OS.ProbabilityInfection) do
                    yield ("Компьютеру " + prev.ToString() + " не удалось заразить компьютер " + current.ToString())
                computers[current].Infected <- true
                yield  ("Компьютер " + prev.ToString() + " заразил компьютер " + current.ToString())
                
            for i in 0 .. visited.Length - 1 do
                if i <> current && visited[i] = false && matrix[current, i] = true then
                    for report in  (runDfs current i) -> report
        }         
    member public this.Computers with get() = computers
        
    member public this.RunInfection () =
         seq {
            let mutable startIndex = -1 
            for i in 0 .. visited.Length - 1 do
                if computers[i].Infected then
                    startIndex <- i
            if startIndex <> -1 then
                for report in (runDfs startIndex startIndex) -> report   
        }
        
    member public this.RunInfectionOneStep () =
        if counted = false then
            result <- this.RunInfection()
            counted <- true
        if Seq.isEmpty result  then
            "Network cant change state"
        else
            let message = Seq.head result
            result <- Seq.tail result
            message