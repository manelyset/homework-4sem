module Tests

open System.Threading
open NUnit.Framework
open FsUnit
open Lazy

[<Test>]
let ``simple tests for each type of lazy``() =
    let STCalculator = LazyFactory.CreateSingleThreadedLazy(fun () -> 10)
    let MTCalculator = LazyFactory.CreateMultiThreadedLazy(fun () -> 11)
    let LFCalculator = LazyFactory.CreateLockFreeLazy(fun () -> 12)
    STCalculator.Get() |> should equal 10
    MTCalculator.Get() |> should equal 11
    LFCalculator.Get() |> should equal 12

[<Test>]
let ``supplier should be called only once``() =
    let mutable counterSingle = 0
    let mutable counterMulti = 0
    let mutable counterLF = 0
    let STCalculator = LazyFactory.CreateSingleThreadedLazy(fun () -> Interlocked.Increment(ref counterSingle))
    let MTCalculator = LazyFactory.CreateMultiThreadedLazy(fun () -> Interlocked.Increment(ref counterMulti))
    let LFCalculator = LazyFactory.CreateLockFreeLazy(fun () -> Interlocked.Increment (ref counterLF))
    for i in 1..1000 do
        STCalculator.Get()  |> should be (lessThanOrEqualTo 1)
        MTCalculator.Get() |> should be (lessThanOrEqualTo 1)
        LFCalculator.Get() |> should be (lessThanOrEqualTo 1)

[<Test>]
let ``check race for multi-threaded calculator``() =
    let MTCalculator = LazyFactory.CreateMultiThreadedLazy(fun () -> new System.Object())
    let sample = MTCalculator.Get ()
    for i in 1..1000 do
        ThreadPool.QueueUserWorkItem (fun obj -> (MTCalculator.Get ()).Equals sample |> should be True) |> ignore

[<Test>]
let ``check race for lock-free calculator``() =
    let LFCalculator = LazyFactory.CreateLockFreeLazy(fun () -> new System.Object())
    let sample = LFCalculator.Get ()
    for i in 1..1000 do
        ThreadPool.QueueUserWorkItem (fun obj -> (LFCalculator.Get ()).Equals sample |> should be True) |> ignore



