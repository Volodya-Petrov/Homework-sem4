namespace LocalNetwork

type public OS(name:string,  probabilityOfInfection) =
    let name = name
    let probabilityInfection = probabilityOfInfection
    do
        if probabilityInfection < 0f || probabilityInfection > 1f then failwith("Вероятность меньше 0 или больше 1")
    member public this.Name with get () = name
    member public this.ProbabilityInfection with get () = probabilityInfection