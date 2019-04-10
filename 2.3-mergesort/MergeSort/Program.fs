module MergeSort

let merge list1 list2 = 
    let rec mergeAcc ls1 ls2 acc =
        match ls1 ls2 with
        | ls1, [] -> (List.rev ls1) @ acc
        | [], ls2 -> (List.rev ls2) @ acc
        | h1::t1, h2::t2 when h1 < h2 -> mergeAcc ls1 t2 (h2::acc)
        | h1::t1, h2::t2 when h1 >= h2 -> mergeAcc t1 ls2 (h1::acc)
    mergeAcc list1 list2 []

let split ls =
    let splitSize = ((List.length ls) / 2)
    let rec splitAcc ls1 acc i =
        if i = splitSize then (acc, ls1)
        else splitAcc (List.tail ls1) ((List.head ls1)::acc) (i + 1)
    splitAcc ls [] 0

let rec mergeSort ls =
    if (List.length ls < 2) then ls
    else
        let (ls1, ls2) = split ls
        let sorted1 = mergeSort ls1
        let sorted2 = mergeSort ls2
        merge List.rev sorted1 List.rev sorted2
       
