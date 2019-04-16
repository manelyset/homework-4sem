module Network

open System

type Computer (OSType:string, infected:bool, r:Random) =
    let mutable mInfected = infected
    let mutable mFlag = 1
    member this.Flag
        with get () = mFlag
        and set newFlag = mFlag <- newFlag
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
            otherComputer.Infected <- (r.NextDouble() < otherComputer.infProbability)
  

let infect (network:int[][]) (computersList:Computer[]) =
    for i in 0..((Array.length computersList) - 1) do
        for j in 0..((Array.length computersList) - 1) do
            if (network.[i].[j] = 1) && (computersList.[i].Flag = 2) then
                computersList.[i].infect(computersList.[j])
    for c in computersList do
        if c.Infected then c.Flag <- 2

let networkState (computersList:Computer[]) =
    Array.init (Array.length computersList) (fun i -> computersList.[i].Infected)
            
let printNetworkState (computersList:Computer[]) =
    for i in 0..((Array.length computersList) - 1) do
        match computersList.[i].Infected with
        | true -> printfn ("Computer %i: infected") i
        | false -> printfn ("Computer %i: not infected") i
    
let printStepByStep steps (network:int[][]) (computersList:Computer[])= 
    let rec iterateStepByStep steps (network:int[][]) (computersList:Computer[]) i =
        match i with
        | a when a = steps -> 
            printfn "STEP %i" i
            printNetworkState computersList
        | _ ->
            printfn "STEP %i" i
            printNetworkState computersList
            infect network computersList
            iterateStepByStep steps network computersList (i+1)
    iterateStepByStep steps network computersList 0
    
