module Palindrome

let reverse lst =
    let rec accReverse  ls acc =
        match ls with
        | [] -> acc
        | h::t -> accReverse t (h::acc)
    accReverse lst []

let rec compareLists ls1 ls2 = 
    match ls1, ls2 with
    | [], [] -> true
    | _, [] -> false
    | [], _ -> false
    | h1::t1, h2::t2 when h1<>h2 -> false
    | h1::t1, h2::t2 when h1=h2 -> compareLists t1 t2

let isPalindrome str =
    let strList = Seq.toList str
    let strListRev = reverse strList
    compareLists strList strListRev
    
