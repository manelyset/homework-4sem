module Tests

open NUnit.Framework
open FsCheck
open PointFree

[<Test>]
let ``the first and the last functions return the same result`` () =
    Check.Quick (fun x l -> (func'0 x l) = (func'4 x l))