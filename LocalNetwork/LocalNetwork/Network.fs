namespace LocalNetwork

type public Network(matrix: bool[,], computers:Computer[], random:unit -> float32) =
    let matrix = matrix
    let random = random
    let computers = computers
    let visited = Array.create computers.Length false
    let mutable result : seq<string> = Seq.empty
    let mutable counted = false          
   
    let rec runDfs prev current =
        seq { 
        visited[current] <- true
        if computers[current].OS.ProbabilityInfection <> 0f then
            if computers[current].Infected = false then
                while (random () > computers[current].OS.ProbabilityInfection) do
                    yield ("Компьютеру " + prev.ToString() + " не удалось заразить компьютер " + current.ToString())
                computers[current].Infected <- true
                yield  ("Компьютер " + prev.ToString() + " заразил компьютер " + current.ToString())
                
            for i in 0 .. visited.Length - 1 do
                if i <> current && not visited[i] && matrix[current, i] then
                    for report in  (runDfs current i) -> report
        }
    
    new (matrix: bool[,], computers:Computer[]) = Network(matrix, computers, System.Random().NextSingle)
    
    member public this.Computers = computers
        
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
        Seq.head result
        