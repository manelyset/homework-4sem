module Square

open System

/// <summary>
/// Makes a list of n symbols '*'
/// </summary>
/// <param name="n">A list length</param>
let squareSide n =
    let rec squareSideAcc n acc =
        match n with
        | 0 -> acc
        | _ -> squareSideAcc (n - 1) ('*'::acc)
    squareSideAcc n []

/// <summary>
/// Makes a list of n symbols: the 1st and the last are '*', others are spaces
/// </summary>
/// <param name="n">A list length</param>
let squareMiddle n = 
    let rec squareMiddleAcc n acc i =
        match i with
        | 0 -> squareMiddleAcc n ('*'::acc) (i + 1)
        | a when a = n -> ('*'::acc)
        | _ -> squareMiddleAcc n (' '::acc) (i + 1)
    squareMiddleAcc (n - 1) [] 0

/// <summary>
/// Makes a square of size n and returns a list of strings
/// </summary>
/// <param name="n">A square size</param>
let makeSquare n = 
    let rec makeStringsList n acc i =
        match i with
        | 0 -> makeStringsList n (((squareSide n) |> string)::acc) (i+1)
        | a when a = (n-1) -> ((squareSide n) |> string)::acc
        | _ -> makeStringsList n (((squareMiddle n) |> string)::acc) (i + 1)
    
    match n with
    | a when a <= 0 -> ["Size should be positive!"]
    | _ -> makeStringsList n [] 0
/// <summary>
/// Prints a square of size n
/// </summary>
/// <param name="n">A square size</param>
let printSquare n = 
    let rec printStringsList ls = 
        match ls with
        | [] -> printfn("")
        | h::t ->
            printfn ("%s") h
            printStringsList t

    printStringsList <| makeSquare n



printfn "Enter size:"
let size = Console.ReadLine()
printSquare (int size)
