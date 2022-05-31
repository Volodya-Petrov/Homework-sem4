namespace LocalNetwork

type public Computer(os:OS) =
    let os = os
    let mutable infected = false
    member public this.OS = os
    member public this.Infected
        with get () = infected
        and set (value) = infected <- value 