module Rhomb

open System

/// <summary>
/// Creates a line of a given length with a given number of stars in the middle
/// </summary>
/// <param name="nbStars">The number of stars</param>
/// <param name="length">The length</param>
/// <returns>The sequence of characters</returns>
let createLine nbStars length =
    let putStar i nbStars1 length1 =
        if (i > nbStars1 || i < (length1 - nbStars1) / 2) then ' '
        else '*'
    Seq.init length (fun i -> putStar i nbStars length)

/// <summary>
/// Creates a rhomb of stars of the given size
/// </summary>
/// <param name="n">The size of the rhomb</param>
/// <returns>The list of character sequences</returns>
let createRhomb n = 
    let rec createRhombAcc n1 stars i acc =
        match i with
        | n1 -> acc
        | j when (j < (n1 / 2)) -> createRhombAcc n1 (stars + 2) (i + 1) ((createLine stars n1)::acc)
        | j when (j >= (n1 / 2)) -> createRhombAcc n1 (stars - 2) (i + 1) ((createLine stars n1)::acc)
    createRhombAcc (2 * n - 1) 1 0 []

/// <summary>
/// Prints the rhomb of stars
/// </summary>
/// <param name="n">The rhomb size</param>
let printRhomb n =
    let rec printList (ls : seq<char> list) =
        match ls with
        | [] -> printfn ("")
        | h :: t -> printfn "%s" <| (string h)
                    printList t
    printList (createRhomb n)