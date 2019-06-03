module Lazy

open System
open System.Threading

type ILazy<'a> =
    abstract member Get: unit -> 'a

type SingleThread<'a> (supplier : unit -> 'a) =
    let mutable result = None
    interface ILazy<'a> with
        member this.Get() =
            match result with
            | Some x -> x
            | None ->                
                result <- Some(supplier())
                supplier()

type MultiThread<'a> (supplier : unit -> 'a) =
    let mutable result = None
    let lockobj = new Object()
    interface ILazy<'a> with
        member this.Get() =
            Monitor.Enter lockobj
            try
                match result with
                | Some x -> x
                | None ->                
                    result <- Some(supplier())
                    supplier()
            finally
                Monitor.Exit lockobj

type LockFree<'a> (supplier : unit -> 'a) =

type LazyFactory<'a> (supplier : unit -> 'a) =
    static member CreateSingleThreadedLazy supplier = new SingleThread<'a>(supplier)
    static member CreateMultiThreadedLazy supplier = new MultiThread<'a>(supplier)
    static member CreateLockFreeLazy supplier = new LockFree<'a>(supplier)
