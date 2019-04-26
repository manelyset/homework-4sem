module Palindrome

/// <summary>
/// Reverses an integer.
/// </summary>
/// <param name="n">A number to reverse.</param>
/// <returns>A reversed number.</returns>
let reverseNum n =
    let rec reverseNumAcc n reversed = 
        match n with
        | 0 -> reversed
        | _ -> reverseNumAcc (n / 10) ((reversed * 10) + (n % 10))
    reverseNumAcc n 0

/// <summary>
/// Checks whether the given integer is a palindrome.
/// </summary>
/// <param name="n">A number to check.</param>
/// <retruns>True if n is palindrome, 0 otherwise</returns>
let checkPalindrome n  = (n = reverseNum n)

/// <summary>
/// Searches a maximal palindrome between products of three-digit numbers
/// </summary>
/// <returns>A maximal palindrome or 0 if no palindromes were found</returns>
let searchPalindrome() =
    let rec search i j max=
        match i, j with
        | 999, 999 -> max
        | i, 999 -> 
            if (checkPalindrome (i * 999)) then search (i+1) (i+1) (i * 999)
            else search (i+1) (i+1) max
        | i, j ->
            if (checkPalindrome (i * j)) then search i (j + 1) (i * j)
            else search i (j + 1) max
    search 100 100 0

    
    
