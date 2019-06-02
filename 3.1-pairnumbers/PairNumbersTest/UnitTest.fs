module Tests

open NUnit.Framework
open FsUnit
open FsCheck
open PairNumbers

[<Test>]
let ``f1: There are 5 pair numbers in [9; 28; 18; 26; 3; 26; 25; 10; 5; 15]`` () =
    pairNumbers1 [9; 28; 18; 26; 3; 26; 25; 10; 5; 15] |> should equal 5

[<Test>]
let ``f1: There is no pair numbers in an empty list`` () =
    pairNumbers1 [] |> should equal 0

[<Test>]
let ``f1: There are 4 pair numbers in [4; 40; 22; 16]`` () =
    pairNumbers1 [4; 40; 22; 16] |> should equal 4

[<Test>]
let ``f1: There is no pair numbers in [7; 3; 11; 1]`` () =
    pairNumbers1 [7; 3; 11; 1] |> should equal 0

[<Test>]
let ``f2: There are 5 pair numbers in [9; 28; 18; 26; 3; 26; 25; 10; 5; 15]`` () =
    pairNumbers2 [9; 28; 18; 26; 3; 26; 25; 10; 5; 15] |> should equal 5

[<Test>]
let ``f2: There is no pair numbers in an empty list`` () =
    pairNumbers2 [] |> should equal 0

[<Test>]
let ``f2: There are 4 pair numbers in [4; 40; 22; 16]`` () =
    pairNumbers2 [4; 40; 22; 16] |> should equal 4

[<Test>]
let ``f2: There is no pair numbers in [7; 3; 11; 1]`` () =
    pairNumbers2 [7; 3; 11; 1] |> should equal 0

[<Test>]
let ``f3: There are 5 pair numbers in [9; 28; 18; 26; 3; 26; 25; 10; 5; 15]`` () =
    pairNumbers3 [9; 28; 18; 26; 3; 26; 25; 10; 5; 15] |> should equal 5

[<Test>]
let ``f3: There is no pair numbers in an empty list`` () =
    pairNumbers3 [] |> should equal 0

[<Test>]
let ``f3: There are 4 pair numbers in [4; 40; 22; 16]`` () =
    pairNumbers3 [4; 40; 22; 16] |> should equal 4

[<Test>]
let ``f3: There is no pair numbers in [7; 3; 11; 1]`` () =
    pairNumbers3 [7; 3; 11; 1] |> should equal 0

[<Test>]
let ``all functions return the same result`` () =
    Check.Quick (fun ls -> (pairNumbers1 ls) = (pairNumbers2 ls))
    Check.Quick (fun ls -> (pairNumbers1 ls) = (pairNumbers3 ls))
    Check.Quick (fun ls -> (pairNumbers3 ls) = (pairNumbers2 ls))