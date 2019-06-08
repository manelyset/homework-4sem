module Brackets

type Stack<'a> =
   | Node of 'a * Stack<'a>
   | Null

/// <summary>
/// Matches the closing bracket with its pair
/// </summary>
/// <param name="bracket">The closing bracket: ), ] or }</param>
/// <returns>The opening bracket for it</returns>
let openingBracketFor bracket = 
    match bracket with
    | ')' -> '('
    | ']' -> '['
    | '}' -> '{'
    | _ -> failwith "the parameter is not a closing bracket!"

/// <summary>Tests whether the bracket sequence is balanced. 
/// The brackets are of three types: (), {} or {}.</summary>
/// <param name = "brackets"> A string to test.</param>
/// <returns>True if a given sequence is balanced, false otherwise.</returns>
let checkSequence brackets =
    let rec stackCheck brackets stack =
        match brackets, stack with 
        | [], Null -> true
        | h :: t, _ when h = '(' || h = '{' || h = '[' -> stackCheck t (Node(h, stack))
        | h :: t, Node (x, next) when h = ')' || h = ']' || h = '}' ->
            if x <> (openingBracketFor h) then false
            else stackCheck t next
        | _, _ -> false
    stackCheck (Seq.toList brackets) Null
