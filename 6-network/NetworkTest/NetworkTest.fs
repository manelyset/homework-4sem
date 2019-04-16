module NetworkTests

open System
open NUnit.Framework
open FsUnit
open Network

type neverInfect() =
    inherit Random()
    override this.NextDouble() = 1.0

type alwaysInfect() =
    inherit Random()
    override this.NextDouble() = 0.0

let neverInfect = neverInfect()
let alwaysInfect = alwaysInfect()
let r = Random()

let computersList1 = Array.init 4 (fun i -> Computer("Windows",false,neverInfect))
let network1 = Array.init 4 (fun i -> Array.init 4 (fun j -> 0))
network1.[0].[1] <- 1
network1.[1].[2] <- 1
network1.[2].[3] <- 1
network1.[3].[0] <- 1
computersList1.[2].Infected <- true
computersList1.[2].Flag <- 2

[<Test>]
let ``computer #2 should not infect others``() =
    infect network1 computersList1
    networkState computersList1 |> should equal [|false; false; true; false|]

let computersList2 = Array.init 6 (fun i -> Computer("Windows",false,alwaysInfect))
let network2 = Array.init 6 (fun i -> Array.init 6 (fun j -> 0))
network2.[0].[1] <- 1
network2.[0].[2] <- 1
network2.[2].[3] <- 1
network2.[2].[4] <- 1
network2.[4].[5] <- 1
computersList2.[0].Infected <- true
computersList2.[0].Flag <- 2

[<Test>]
let ``network #2 - infection`` () =
    infect network2 computersList2
    networkState computersList2 |> should equal [|true; true; true; false; false; false|]
    infect network2 computersList2
    networkState computersList2 |> should equal [|true; true; true; true; true; false|]
    infect network2 computersList2
    networkState computersList2 |> should equal [|true; true; true; true; true; true|]

let computersList3 = Array.init 6 (fun i -> Computer("otherOS",false,r))
computersList3.[0].Infected <- true
computersList3.[0].Flag <- 2

[<Test>]
let ``network #3 - infection`` () =
    infect network2 computersList3
    networkState computersList3 |> should equal [|true; true; true; false; false; false|]
    infect network2 computersList3
    networkState computersList3 |> should equal [|true; true; true; true; true; false|]
    infect network2 computersList3
    networkState computersList3 |> should equal [|true; true; true; true; true; true|]