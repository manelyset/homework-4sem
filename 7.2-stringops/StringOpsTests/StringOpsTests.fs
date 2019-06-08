module StringOpsTests

open NUnit.Framework
open FsUnit
open StringOps

let calculate = new StringOperations()
[<Test>]
let ``1 + 2 = 3``() =
    let result = calculate {
        let! x = "1"
        let! y = "2"
        let z = x + y
        return z
    }
    result |> should equal (Some 3)

[<Test>]
let ``longer expression``() =
    let result = calculate {
        let! x = "323"
        let! y = "123"
        let! z = string (x - y)
        let! a = string (z / 40)
        let b = 2 * a 
        return b
    }
    result |> should equal (Some 10)

[<Test>]
let ``strings don't represent numbers``() =
    let result = calculate {
        let! x = "323"
        let! y = "12y3"
        let! z = string (x - y)
        let a = 2 * z
        return a
    }
    result |> should equal None

[<Test>]
let ``doesn't work with floating-point numbers``() =
    let result = calculate {
        let! x = "1"
        let! y = "2.0"
        let z = x + y
        return z
    }
    result |> should equal None