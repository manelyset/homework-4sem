open System

let rec accFact x acc =
    if x=0 then acc
    else accFact (x-1) (x*acc)
let factorial n =
    if n<0 then 
       printfn "Wrong argument: n should be positive"
       -1
    else accFact n 1

printfn "%i" (factorial(5))
