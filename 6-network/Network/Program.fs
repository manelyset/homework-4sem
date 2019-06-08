module Network

open System

type InfectionFlag = 
    | CanInfect
    | CanNotInfect

type Computer (OSType:string, infected:bool, r:Random) =
    let mutable infected = infected
    let mutable mFlag = CanNotInfect
    member this.Flag
        with get () = mFlag
        and set newFlag = mFlag <- newFlag
    member this.Infected
        with get () = infected
        and set infection = infected <- infection
    /// <summary>
    /// The infection probability of the computer depending on its operational system
    /// </summary>
    /// <returns>The probability from 0 to 1</returns>
    member this.InfProbability =
        match OSType with
        | "Windows" -> 0.4
        | "MacOs" -> 0.5
        | "Linux" -> 0.6
        | _ -> 1.0
    /// <summary>
    /// If the given computer is infected, infects another computer with some probability depending on its operational system
    /// </summary>
    /// <param name="otherComputer">The computer to infect</param>
    member this.Infect (otherComputer:Computer) =
        if this.Infected then
            if (r.NextDouble() < otherComputer.InfProbability) then
                otherComputer.Infected <- true
  
/// <summary>
/// Infects the closest computers to the infected ones depending on their infection probability
/// </summary>
/// <param name="network">The adjacancy matrix</param>
/// <param name="computersList">The list of all computers</param>
let infect (network:int[][]) (computersList:Computer[]) =
    for i in 0..((Array.length computersList) - 1) do
        for j in 0..((Array.length computersList) - 1) do
            if (network.[i].[j] = 1) && (computersList.[i].Flag = CanInfect) then
                computersList.[i].Infect(computersList.[j])
    for c in computersList do
        if c.Infected then c.Flag <- CanInfect
/// <summary>
/// For each computer in the list says whether it is infected or not
/// </summary>
/// <param name="computersList">The list of all computers</param>
/// <returns>The array of boolean values</returns>
let networkState (computersList:Computer[]) =
    Array.init (Array.length computersList) (fun i -> computersList.[i].Infected)
            
/// <summary>
/// Prints a current network state
/// </summary>
/// <param name="computersList">The list of all computers</param>
let printNetworkState (computersList:Computer[]) =
    for i in 0..((Array.length computersList) - 1) do
        match computersList.[i].Infected with
        | true -> printfn ("Computer %i: infected") i
        | false -> printfn ("Computer %i: not infected") i
/// <summary>
/// Prints how the network state changed in some number of steps
/// </summary>
/// <param name="steps">The number of steps</param>
/// <param name="network">The adjacancy matrix</param>
/// <param name="computersList">The list of all ccomputers</param>
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
            iterateStepByStep steps network computersList (i + 1)
    iterateStepByStep steps network computersList 0
    
