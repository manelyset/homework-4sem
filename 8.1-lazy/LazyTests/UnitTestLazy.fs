module Tests

open System.Threading
open NUnit.Framework
open FsUnit
open Lazy

[<Test>]
let ``simple tests for each type of lazy``() =
    let singleThreadedCalculator = LazyFactory.CreateSingleThreadedLazy(fun () -> 10)
    let multiThreadedCalculator = LazyFactory.CreateMultiThreadedLazy(fun () -> 11)
    let lockFreeCalculator = LazyFactory.CreateLockFreeLazy(fun () -> 12)
    singleThreadedCalculator.Get() |> should equal 10
    multiThreadedCalculator.Get() |> should equal 11
    lockFreeCalculator.Get() |> should equal 12

[<Test>]
let ``supplier should be called only once``() =
    let mutable counterSingle = 0
    let mutable counterMulti = 0
    let mutable counterLF = 0
    let singleThreadedCalculator = LazyFactory.CreateSingleThreadedLazy(fun () -> Interlocked.Increment(ref counterSingle))
    let multiThreadedCalculator = LazyFactory.CreateMultiThreadedLazy(fun () -> Interlocked.Increment(ref counterMulti))
    let lockFreeCalculator = LazyFactory.CreateLockFreeLazy(fun () -> Interlocked.Increment (ref counterLF))
    for i in 1..1000 do
        singleThreadedCalculator.Get()  |> should be (lessThanOrEqualTo 1)
        multiThreadedCalculator.Get() |> should be (lessThanOrEqualTo 1)
        lockFreeCalculator.Get() |> should be (lessThanOrEqualTo 1)

[<Test>]
let ``check race for multi-threaded calculator``() =
    let multiThreadedCalculator = LazyFactory.CreateMultiThreadedLazy(fun () -> new System.Object())
    let sample = multiThreadedCalculator.Get ()
    for i in 1..1000 do
        ThreadPool.QueueUserWorkItem (fun obj -> (multiThreadedCalculator.Get ()).Equals sample |> should be True) |> ignore

[<Test>]
let ``check race for lock-free calculator``() =
    let lockFreeCalculator = LazyFactory.CreateLockFreeLazy(fun () -> new System.Object())
    let sample = lockFreeCalculator.Get ()
    for i in 1..1000 do
        ThreadPool.QueueUserWorkItem (fun obj -> (lockFreeCalculator.Get ()).Equals sample |> should be True) |> ignore



