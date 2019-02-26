module Tests

open NUnit.Framework
open FsUnit
open Palindrome

[<Test>]
let ``reverse a list [1; 2; 3; 4]`` () =
    compareLists (reverse [1; 2; 3; 4]) [4; 3; 2; 1] |> should equal true

[<Test>]
let ``reverse an empty list`` () =
    reverse [] |> should equal []
