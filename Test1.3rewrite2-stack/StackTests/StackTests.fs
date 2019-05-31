module Tests

open NUnit.Framework
open FsUnit
open MyStack

let testStack1 = new Stack<char> ()
let testStack2 = new Stack<int> ()

[<Test>]
let ``stack 1 is empty`` () =
    testStack1.isEmpty () |> should equal true

[<Test>]
let ``getting value from an empty stack`` () =
    testStack1.value () |> ignore |> should throw typeof<System.Exception>
    testStack1.pop () |> ignore |> should throw typeof<System.Exception>

[<Test>]
let ``testing stack 2`` () =
    testStack2.push 3
    testStack2.push 2
    testStack2.push 1
    testStack2.isEmpty () |> should equal false
    testStack2.value () |> should equal 1
    testStack2.pop ()
    testStack2.value () |> should equal 2
