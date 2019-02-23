
let rec accFibonacci n previous1 previous2 i =
    if (i = n) then previous2
    else accFibonacci n previous2 (previous1 + previous2) (i + 1)
let fibonacci n =
   if (n < 0) then
      printfn "Wrong argument: n should be positive"
      -1
   else if (n < 2) then n
   else accFibonacci n 0 1 1
printfn "%i" (fibonacci(2))


