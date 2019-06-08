module StringOps

open System

/// <summary>
/// Converts a string to the integer if possible
/// </summary>
/// <param name="s">The string to convert</param>
/// <returns>Some(x) where x is a converted string in case of success; None otherwise</returns>
let stringToInt (s:string) = 
    match Int32.TryParse s with
    | false, _ -> None
    | true, x -> Some x

/// <summary>
/// The workflow builder to perform operations with strings as numbers
/// </summary>
type StringOperations() =
    member this.Bind (x,f) =
        let n = stringToInt x
        match n with
        | None -> None
        | Some a -> f a
    member this.Return(x) = Some x