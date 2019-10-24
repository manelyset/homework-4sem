module Rounding

open System

/// <summary>
/// The workflow builder to calculate the expression result with the given accuracy
/// </summary>
type RoundingBuilder (accuracy:int) =
    member this.Bind(x:float,f) =
        let xr = Math.Round(x, accuracy)
        f xr
    member this.Return(x:float) = Math.Round(x, accuracy)     

