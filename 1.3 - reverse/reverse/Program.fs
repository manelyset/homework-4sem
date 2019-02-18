// Learn more about F# at http://fsharp.org

open System

let rec accReverse  ls acc =
   if(List.length ls=0) then acc
   else if (List.length ls=1) then List.head ls::acc
   else 
      accReverse
         (List.tail ls)
         (List.head ls::acc)
let reverse ls = accReverse ls []
let list1 = [1;2;3;4]
printfn "%A" (reverse(list1))
