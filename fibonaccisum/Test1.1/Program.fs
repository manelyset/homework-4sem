let rec fibonacciList prev1 prev2 max acc =
    if prev2 >= max then acc
    else 
    fibonacciList prev2 (prev1 + prev2) max (prev1::acc)

let fibonacciSum = (fibonacciList 1 1 1000000 []) |> List.filter (fun x -> x % 2 = 0) |> List.fold (+) 0