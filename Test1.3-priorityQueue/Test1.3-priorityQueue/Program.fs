open System.Collections

// Learn more about F# at http://fsharp.org

open System

Type PQueue (queue:Array)=
    member this.insert x priority =
        queue.insert 0 (x, priority)

    