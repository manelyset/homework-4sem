module MergeSort

let merge (list1, list2) = 
    let rec mergeAcc (ls1, ls2) acc =
       match (ls1, ls2) with
       | (ls1, []) -> acc@ls1
       | ([], ls2) -> acc@ls2
       | (h1::t1, h2::t2) when h1 < h2 -> mergeAcc (ls1, t2) (h2::acc)
       | (h1::t1, h2::t2) when h1 >= h2 -> mergeAcc (t1, ls2) (h1::acc)
    mergeAcc (list1, list2) []

let split ls =
    let splitSize = ((List.length ls) / 2)
    let rec splitAcc ls1 acc i =
        if i = splitSize then (ls1, acc)
        else splitAcc (List.tail ls1) ((List.head ls1)::acc) (i+1)
    splitAcc ls [] 0


       