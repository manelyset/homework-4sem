﻿module Lazy

open System
open System.Threading

/// <summary>
/// An interface for lazy calculator
/// </summary>
type ILazy<'a> =
    /// Calculates a result when called for the first time, returns already calculated result if called again
    abstract member Get: unit -> 'a

/// <summary>
/// A single-threaded lasy calculator
/// </summary>
type SingleThread<'a> (supplier : unit -> 'a) =
    let mutable result = None
    interface ILazy<'a> with
        /// <summary>Performs lazy calculations with one thread</summary>
        /// <returns>A result of calculations of type 'a</returns>
        member this.Get() =
            match result with
            | Some x -> x
            | None ->                
                result <- Some(supplier())           
                result.Value


/// <summary>
/// A multi-threaded lasy calculator
/// </summary>
type MultiThread<'a> (supplier : unit -> 'a) =
    let mutable result = None
    let lockobj = new Object()
    let called = ref false
    /// <summary>Performs lazy calculations with multiple threads</summary>
    /// <returns>A result of calculations of type 'a</returns>
    interface ILazy<'a> with
        member this.Get() =
            if (not (Volatile.Read (called))) then
                lock lockobj (fun() -> 
                    if (not (Volatile.Read (called))) then
                        result <- Some(supplier())
                        Volatile.Write (called, true)  )
            result.Value

/// <summary>
/// A multi-threaded lasy calculator with no lock guarantee
/// </summary>
type LockFree<'a> (supplier : unit -> 'a) =
    let mutable result = None
    let mutable called = false
    /// <summary>Performs lazy calculations with multiple threads and without locking</summary>
    /// <returns>A result of calculations of type 'a</returns>
    interface ILazy<'a> with
        member this.Get() = 
            if not called then
                let answer = supplier()
                Interlocked.CompareExchange(&result, Some answer, result) |> ignore
                called <- true
            result.Value

/// <summary>
/// Creates calculators of one of three types
/// </summary>
type LazyFactory<'a> (supplier : unit -> 'a) =
    static member CreateSingleThreadedLazy supplier = new SingleThread<'a>(supplier) :> ILazy<'a>
    static member CreateMultiThreadedLazy supplier = new MultiThread<'a>(supplier) :> ILazy<'a>
    static member CreateLockFreeLazy supplier = new LockFree<'a>(supplier) :> ILazy<'a>
