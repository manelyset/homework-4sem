
let rec binPow a n acc =
   if n = 1 then a * acc
   else if n % 2 = 1 then 
      binPow a (n - 1) (acc * a)
   else 
      binPow (a * a) (n / 2) acc

let rec fillListDividingBy2 ls x length i =
   if i = length then ls
   else 
      fillListDividingBy2 (x::ls) (x / 2) length (i + 1)

let fillListWithDegreesOf2 ls m n =
   fillListDividingBy2 ls (binPow 2 (m + n) 1) (m + 1) 0

printfn "%A" (fillListWithDegreesOf2 [] 4 3)