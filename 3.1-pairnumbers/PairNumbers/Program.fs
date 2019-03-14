module PairNumbers

/// <summary>Counts the pair numbers in the list using List.filter, List.map and List.fold .</summary>
/// <param name="ls">The input list.</param>
/// <returns>The number of pair numbers in the list.</returns>
let pairNumbers1 ls =
    ls |> List.filter (fun x -> x % 2 = 0) |> List.map (fun x -> 1) |> List.fold (+) 0

/// <summary>Counts the pair numbers in the list using List.filter and List.fold .</summary>
/// <param name="ls">The input list.</param>
/// <returns>The number of pair numbers in the list.</returns>
let pairNumbers2 ls =
    ls |> List.filter (fun x -> x % 2 = 0) |> List.fold (fun acc x -> acc + 1) 0

/// <summary>Counts the pair numbers in the list using Seq.choose and Seq.fold .</summary>
/// <param name="ls">The input list.</param>
/// <returns>The number of pair numbers in the list.</returns>
let pairNumbers3 ls =
    ls |> Seq.choose (fun x ->   
                          match x with
                              | x when x%2=0 -> Some(1)
                              | _ -> None) 
                              |> Seq.fold (+) 0 
