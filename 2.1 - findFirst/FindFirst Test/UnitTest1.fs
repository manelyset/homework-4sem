module Tests

open NUnit.Framework
open FsUnit
open FindFirst

[<Test>]
let ``First index of 4 in [1; 2; 3; 4; 5] should be 3`` () =
    findFirst [1; 2; 3; 4; 5] 4 |> should equal (Some (3))

[<Test>]
let ``First index of 5 in [1; 2; 3; 4; 5] should be 4`` () =
    findFirst [1; 2; 3; 4; 5] 5 |> should equal (Some (4))

[<Test>]
let ``First index of 3 in [3; 3; 3; 3] should be 0`` () =
    findFirst [3; 3; 3; 3] 3 |> should equal (Some (0))

[<Test>]
let ``There is no 5 in [3; 3; 3; 3]`` () =
    findFirst [3; 3; 3; 3] 5 |> should equal (None)

[<Test>]
let ``The list is empty`` () =
    findFirst [] 10 |> should equal (None)


