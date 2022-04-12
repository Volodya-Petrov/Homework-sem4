namespace LocalNetwork

type public Network(matrix: bool[,], computers:Computer[]) =
    let matrix = matrix
    let computers = computers
    let visited = Array.create computers.Length false
    
    let rec runDfs prev current =
        seq { 
        visited[current] <- true
        if computers[current].OS.ProbabilityInfection <> 0f then
            let random = System.Random()
            if computers[current].Infected = false then
                while (random.NextSingle() > computers[current].OS.ProbabilityInfection) do
                    yield ("Компьютеру " + prev.ToString() + " не удалось заразить компьютер " + current.ToString())
                yield  ("Компьютеру " + prev.ToString() + " заразил компьютер " + current.ToString())
            computers[current].Infected <- true
            for i in 0 .. visited.Length - 1 do
                if i <> current && visited[i] = false && matrix[current, i] = true then
                    yield! (runDfs current i)
        }         
    member public this.Computers with get() = computers
        
    member public this.RunInfection () =
        seq {
            let mutable startIndex = -1 
            for i in 0 .. visited.Length - 1 do
                if computers[i].Infected then
                    startIndex <- i
            if startIndex <> -1 then
                yield! (runDfs startIndex startIndex)    
        }
        