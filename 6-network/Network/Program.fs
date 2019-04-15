module Network

open System

type Computer (OSType:string, infected:bool, r:Random) =
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
            otherComputer.Infected <- (r.NextDouble() < otherComputer.infProbability)
  

let infect (network:Array) (computersList:Array) =
    for i in 0..(network.GetLength 1) do
        for j in 0..(network.GetLength 2) do
            if (network.[i].[j]) = 1 then
                computersList.[i].infect(computersList.[j])

let networkState (computersList:Array) =
    Array.init (computersList.GetLength 1) (fun i -> computersList.[i].Infected)
            
let printNetworkState (computersList:Array) =
    for i in 0..(computersList.GetLength 1) do
        match computersList.[i].Infected with
        | true -> printfn ("Computer %i: infected") i
        | false -> printfn ("Computer %i: not infected") i
    
let printStepByStep steps (network:Array) (computersList:Array)= 
    let rec iterateStepByStep steps (network:Array) (computersList:Array) i =
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
    
