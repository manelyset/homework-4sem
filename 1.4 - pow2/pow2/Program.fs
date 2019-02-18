open System

let rec binpow a n acc =
   if (n=1) then a*acc
   else if (n%2=1) then 
      binpow
         a
         (n-1)
         (acc*a)
   else 
      binpow
         (a*a)
         (n/2)
         acc

let rec fillList ls x n i =
   if i=n then ls
   else 
      fillList
         (x::ls)
         (x/2)
         n
         (i+1)

let f1 ls m n =
   fillList
      ls
      (binpow 2 (m+n) 1)
      (m+1)
      0

printfn "%A" (f1 [] 4 3)