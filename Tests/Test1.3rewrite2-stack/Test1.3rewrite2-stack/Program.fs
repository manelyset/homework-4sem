// Learn more about F# at http://fsharp.org
module MyStack

open System

type Stack<'a> () = 
    let mutable mStack = []
    member this.StackList
        with get () = mStack
        and set newStack = mStack <- newStack
    /// <summary>
    /// Pushes an element at the top of stack
    /// </summary>
    /// <param name="x">The element to push</param>
    member this.push (x : 'a) =
        this.StackList <- x :: (this.StackList)
    /// <summary>
    /// Removes an element at the top of stack
    /// </summary>
    member this.pop () =
        if (List.isEmpty this.StackList) then failwith "This stack is empty!"
        this.StackList <- List.tail (this.StackList)
    /// <summary>
    /// Gets a value at the top of stack
    /// </summary>
    /// <returns>The value of type 'a</returns>
    member this.value () =
        match this.StackList with
        | [] -> failwith "This stack is empty!"
        | h :: t -> h
    /// <summary>
    /// Tests whether the stack is empty
    /// </summary>
    /// <returns>True if the stack is empty, false otherwise</returns>
    member this.isEmpty () =
        match this.StackList with
        | [] -> true
        | _ -> false