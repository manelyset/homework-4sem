open System

let rec accFactorial x acc =
    if x = 0 then acc
    else accFactorial (x - 1) (x * acc)
let factorial n =
    if n < 0 then 
       printfn "Wrong argument: n should be positive"
       -1
    else accFactorial n 1

printfn "%i" (factorial(5))
