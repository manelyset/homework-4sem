﻿module Brackets

type Stack<'a> =
   | Node of 'a * Stack<'a>
   | Null

/// <summary>Tests whether the bracket sequence is balanced. 
/// The brackets are of three types: (), {} or {}.</summary>
/// <param name = "brackets"> A string to test.</param>
/// <returns>True if a given sequence is balanced, false otherwise.</returns>
let checkSequence brackets =
    let rec stackCheck brackets stack =
        match brackets, stack with 
        | [], Null -> true
        | h :: t, _ when h = '(' || h = '{' || h = '[' -> stackCheck t (Node(h, stack))
        | h::t, Node (x, next) when h = ')' ->
            if x <> '(' then false
            else stackCheck t next
        | h :: t, Node (x, next) when h = '}' || h = '[' ->
            if x <> (h - 2) then false
            else stackCheck t next
        | _, _ -> false
    stackCheck (Seq.toList brackets) Null
