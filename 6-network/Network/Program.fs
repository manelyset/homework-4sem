module Network

open FsRandom

let state = createState xorshift (123456789u, 362436069u, 521288629u, 88675123u)

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
            otherComputer.Infected <- (Random.get ``[0, 1)`` state < otherComputer.infProbability)
            
    
