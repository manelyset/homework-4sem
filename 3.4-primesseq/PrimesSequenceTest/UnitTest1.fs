module Tests

open NUnit.Framework
open FsUnit
open PrimesSequence

[<Test>]
let ``1 is not prime``() =
    isPrime 1 2 |> should be False

[<Test>] 
let ``16 is not prime``() =
    isPrime 16 2 |> should be False

[<Test>] 
let ``121 is not prime``() =
    isPrime 121 2 |> should be False

[<Test>]
let ``641 is prime``() =
    isPrime 641 2 |> should be True

[<Test>]
let ``The 4th prime is 7``() =
    generateSequence() |> Seq.item 3 |> should equal 7

[<Test>]
let ``The 20th prime is 71``() =
    generateSequence() |> Seq.item 19 |> should equal 71

