///<summary> Makes a list of fibonacci numbers less than max</summary>
///<param name=max>Maximal fibonacci number</param>
let fibonacciList max=
    let rec fibonacciListRec prev1 prev2 max acc =
        if prev2 > max then acc
        else 
        fibonacciList prev2 (prev1 + prev2) max (prev1::acc)
    fibonacciListRec 1 1 max []
   
///<summary>Counts a sum of even fibonacci numbers less than 1000000</summary>
let fibonacciSum = (fibonacciList 1000000) |> List.filter (fun x -> x % 2 = 0) |> List.fold (+) 0
