module Lazy

open System

type ILazy<'a> =
    abstract member Get: unit -> 'a

type SingleThread<'a> (supplier : unit -> 'a) =
    let mutable result = None
    let mutable calculated = false
    interface ILazy<'a> with
        member this.Get () =
            match result with
            | Some x -> x
            | None ->
                calculated <- true
                result <- Some(supplier())
                supplier()

type MultiThread<'a> (supplier : unit -> 'a) =

type LockFree<'a> (supplier : unit -> 'a) =

type LazyFactory<'a> (supplier : unit -> 'a) =
    static member CreateSingleThreadedLazy supplier = new SingleThread<'a>(supplier)
    static member CreateMultiThreadedLazy supplier = new MultiThread<'a>(supplier)
    static member CreateLockFreeLazy supplier = new LockFree<'a>(supplier)
