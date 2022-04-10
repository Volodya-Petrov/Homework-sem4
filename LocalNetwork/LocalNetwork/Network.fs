namespace LocalNetwork

type public Network(matrix: bool[,], computers:Computer[]) =
    let matrix = matrix
    let computers = computers
    let visited = Array.create computers.Length false
    
    let rec runDfs prev current =
        visited[current] <- true
        let random = System.Random()
        if computers[current].Infected = false then
            while (random.NextSingle() > computers[current].OS.ProbabilityInfection) do
                printfn "Компьютеру %i не удалось заразить компьютер %i" prev current
                printfn "Компьютеру %i заразил компьютер %i" prev current
        computers[current].Infected <- true
        for i in 0 .. visited.Length - 1 do
            if visited[i] = false && matrix[current, i] = true then
                runDfs current i
    member public this.Computers with get() = computers
        
    member public this.RunInfection () =
        let mutable startIndex = -1 
        for i in 0 .. visited.Length - 1 do
            if computers[i].Infected then
                startIndex <- i
        if startIndex <> -1 then
            runDfs startIndex startIndex