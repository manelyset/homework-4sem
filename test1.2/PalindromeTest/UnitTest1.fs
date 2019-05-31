module PalindromeTests

open NUnit.Framework
open FsUnit
open Palindrome

[<Test>]
let ``the answer is 888888``() =
    searchPalindrome() |> should equal 888888
