module Tests

open NUnit.Framework
open FsUnit
open Brackets

[<Test>]
let ``Empty sequence is balanced`` () =
    checkSequence "" |> should be True

[<Test>]
let ``"()[]" is balanced`` () =
    checkSequence "()[]" |> should be True

[<Test>]
let ``"{[()]()}" is balanced`` () =
    checkSequence "{[()]()}" |> should be True

[<Test>]
let ``"{[()]()" is not balanced`` () =
    checkSequence "{[()]()" |> should be False

[<Test>]
let ``"{[(])()}" is not balanced`` () =
    checkSequence "{[(])()}" |> should be False