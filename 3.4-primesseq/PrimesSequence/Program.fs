module PrimesSequence

/// <summary>Tests if the number is prime.</summary>
/// <param name="x">A number to test.</param>
/// <param name="i">An iterator.</param>
/// <returns>True if x is positive and prime, false otherwise.</returns>
let rec isPrime x i =
    if x <= 1 then false
    else if (i * i) > x then true
    else
        if (x % i = 0) then false
        else isPrime x (i + 1)

/// <summary>Generates an infinite prime numbers sequence.</summary>
/// <returns>A generated sequence.</returns>
let generateSequence() = 
    Seq.initInfinite (fun index -> index + 2) |> Seq.filter (fun x -> isPrime x 2)

