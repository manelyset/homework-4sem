module Network

open FsRandom

type Computer (OSType:string, infected:bool) =
    let mutable mInfected = infected
    member this.Infected
        with get () = mInfected
        and set infection = mInfected <- infection
    member this.infProbability =
        match OSType with
        | "Windows" -> 0.4
        | "MacOs" -> 0.5
        | "Linux" -> 0.6
        | _ -> 1.0
    member this.infect (otherComputer:Computer) =
        if infected then
            let r = ``[0, 1)``
            otherComputer.Infected <- (r < otherComputer.infProbability)
            
    
