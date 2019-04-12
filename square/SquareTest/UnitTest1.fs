module Tests

open NUnit.Framework
open FsUnit
open Square

[<Test>]
let ``-2 is an invalid size``() =
    makeSquare -2 |> should equal ["Size should be positive!"]
[<Test>]
let ``make a square with side 1``() =
    makeSquare 1 |> should equal ["*"]


[<Test>]
let ``make a square with side 4``() =
    makeSquare 4 |> should equal ["****"; "*  *"; "*  *"; "****"]