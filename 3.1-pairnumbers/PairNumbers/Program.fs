module PairNumbers

/// <summary>Counts the pair numbers in the list using List.map and List.sum .</summary>
/// <param name="ls">The input list.</param>
/// <returns>The number of pair numbers in the list.</returns>
let pairNumbers1 ls =
    ls |> List.map (fun x -> x % 2 = 0) |> List.map (fun x -> match x with
                                                              | true -> 1
                                                              | false -> 0) |> List.sum

/// <summary>Counts the pair numbers in the list using List.filter and List.length .</summary>
/// <param name="ls">The input list.</param>
/// <returns>The number of pair numbers in the list.</returns>
let pairNumbers2 ls =
    ls |> List.filter (fun x -> x % 2 = 0) |> List.length

/// <summary>Counts the pair numbers in the list using Seq.choose and Seq.fold .</summary>
/// <param name="ls">The input list.</param>
/// <returns>The number of pair numbers in the list.</returns>
let pairNumbers3 ls =
    ls |> Seq.choose (fun x ->   
                          match x with
                              | x when x % 2 = 0 -> Some(1)
                              | _ -> None) 
                              |> Seq.fold (+) 0 
