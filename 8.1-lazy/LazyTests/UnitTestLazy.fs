module Tests

open System.Threading
open NUnit.Framework
open FsUnit
open Lazy

[<Test>]
let ``simple tests for each type of lazy``() =
    let lSingle = LazyFactory.CreateSingleThreadedLazy(fun () -> 10)
    let lMulti = LazyFactory.CreateMultiThreadedLazy(fun () -> 11)
    let lLF = LazyFactory.CreateLockFreeLazy(fun () -> 12)
    lSingle.Get() |> should equal 10
    lMulti.Get() |> should equal 11
    lLF.Get() |> should equal 12

[<Test>]
let ``supplier should be called only once``() =
    let mutable counterSingle = 0
    let mutable counterMulti = 0
    let mutable counterLF = 0
    let lSingle = LazyFactory.CreateSingleThreadedLazy(fun () -> Interlocked.Increment(ref counterSingle))
    let lMulti = LazyFactory.CreateMultiThreadedLazy(fun () -> Interlocked.Increment(ref counterMulti))
    let lLF = LazyFactory.CreateLockFreeLazy(fun () -> Interlocked.Increment (ref counterLF))
    for i in 1..1000 do
        lSingle.Get()  |> should be (lessThanOrEqualTo 1)
        lMulti.Get() |> should be (lessThanOrEqualTo 1)
        lLF.Get() |> should be (lessThanOrEqualTo 1)


