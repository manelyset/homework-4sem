module Tests

open NUnit.Framework
open FsUnit
open Palindrome

[<Test>]
let ``reverse an empty list`` () =
    reverse [] |> should equal []

[<Test>]
let ``reverse a list [1; 2; 3; 4]`` () =
    reverse [1; 2; 3; 4] |> should equal [4; 3; 2; 1]

[<Test>]
let ``[1; 2; 3] = [1; 2; 3]`` () =
    compareLists [1; 2; 3] [1; 2; 3] |> should equal true

[<Test>]
let ``[1; 2; 3] != [1; 2; 3; 5]`` () =
    compareLists [1; 2; 3] [1; 2; 3; 5] |> should equal false

[<Test>]
let ``[1; 2; 3] != []`` () =
    compareLists [1; 2; 3] [] |> should equal false

[<Test>]
let ``"asdfdsa" is a palindrome`` () =
    isPalindrome "asdfdsa" |> should equal true

[<Test>]
let ``"asdffdsa" is a palindrome`` () =
    isPalindrome "asdffdsa" |> should equal true

[<Test>]
let ``an empty string is a palindrome`` () =
    isPalindrome "" |> should equal true

[<Test>]
let ``"asdcfdsa" is not a palindrome`` () =
    isPalindrome "asdcfdsa" |> should equal false

