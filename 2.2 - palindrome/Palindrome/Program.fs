module Palindrome

let reverse lst =
    let rec accReverse  ls acc =
        if List.length ls = 0 then acc
        else if List.length ls = 1 then List.head ls::acc
        else 
            accReverse (List.tail ls) (List.head ls::acc)
    accReverse lst []

let rec compareLists ls1 ls2 = 
    match ls1, ls2 with
    | [], [] -> true
    | ls1, [] when List.isEmpty ls1 = false -> false
    | [], ls2 when List.isEmpty ls2 = false -> false
    | h1::t1, h2::t2 when h1<>h2 -> false
    | h1::t1, h2::t2 when h1=h2 -> compareLists t1 t2

let isPalindrome str =
    let strList = Seq.toList str
    let strListRev = reverse strList
    compareLists strList strListRev
    