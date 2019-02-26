module Palindrome

let reverse lst =
    let rec accReverse  ls acc =
        if List.length ls = 0 then acc
        else if List.length ls = 1 then List.head ls::acc
        else 
            accReverse (List.tail ls) (List.head ls::acc)
    accReverse lst []

let compareLists ls1 ls2 = 
    List.zip ls1 ls2 |> List.map (fun (a,b) -> a = b) |> List.fold (&&) true

let isPalindrome str =
    let strList = Seq.toList str
    let strListRev = reverse strList
    compareLists strList strListRev
    