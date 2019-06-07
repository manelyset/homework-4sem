module Tests

open NUnit.Framework
open FsUnit
open Expression

[<Test>]
let ``5 + 6 = 11`` () =
    result (Sum(Number(5), Number(6))) |> should equal (Some(11))

[<Test>]
let ``division by zero`` () =
    result (Quotient(Number(2), Number(0))) |> should equal None

[<Test>]
let ``((10 - 6) * (1 + 2)) / 2 = 6`` () =
    result (Quotient(Product(Difference(Number(10), Number (6)), Sum(Number(1), Number(2))), Number(2)))
    |> should equal (Some(6))

[<Test>]
let ``(5 * 7) - (3 / 0) contains division by zero`` () =
    result (Difference(Product(Number(5), Number(7)), Quotient(Number(3), Number(0))))
    |> should equal None