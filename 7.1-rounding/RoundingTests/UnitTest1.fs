module Tests

open NUnit.Framework
open FsUnit
open Rounding

let rounding a = new RoundingBuilder(a)

[<Test>]
let ``simple calculations``() =
    let res = rounding 3 {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    }
    res |> should (equalWithin 0.0005) 0.048

[<Test>]
let ``calcultions with zero-rounding``() =
    let res = rounding 0 {
        let! a = 3.6 + 2.1
        let! b = a / 4.0
        return b + 1.3
    }
    res |> should (equalWithin 0.05) 3.0

[<Test>]
let ``calculations with division by zero``() =
    let res = rounding 2 {
        let! a = 0.003
        let! b = 7.1 / a
        return b + 1.33
    }
    res |> should equal infinity
