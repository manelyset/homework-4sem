module Rhomb

open System

let createLine nbStars length =
    let putStar i nbStars1 length1 =
        if (i > nbStars1 || i < (length1 - nbStars1) / 2) then ' '
        else '*'
    Seq.init length (fun i -> putStar i nbStars length)

let createRhomb n = 
    let rec createRhombAcc n1 stars i acc =
        match i with
        | n1 -> acc
        | j when (j < (n1 / 2)) -> createRhombAcc n1 (stars + 2) (i + 1) ((createLine stars n1)::acc)
        | j when (j >= (n1 / 2)) -> createRhombAcc n1 (stars - 2) (i + 1) ((createLine stars n1)::acc)
    createRhombAcc (2 * n - 1) 1 0 []

let printRhomb n =
    let rec printList (ls : seq<char> list) =
        match ls with
        | [] -> printfn ("")
        | h :: t -> printfn "%s" <| (string h)
                    printList t
    printList (createRhomb n)