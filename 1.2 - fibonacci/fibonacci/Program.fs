
let rec accFibo n a b i =
    if (i=n) then b
    else accFibo n b (a+b) (i+1)
let fibonacci n =
   if (n<0) then
      printfn "Wrong argument: n should be positive"
      -1
   else if (n<2) then n
   else accFibo n 0 1 1
printfn "%i" (fibonacci(2))


