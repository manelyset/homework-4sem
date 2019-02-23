module FindFirst

open System.Runtime.InteropServices

let findFirst ls value =
    let rec findIndex ls1 value1 i =
        match ls1 with
        | [] -> None
        | h :: t when h = value1 -> Some (i)
        | h :: t when h <> value1 -> findIndex t value1 (i + 1)
    findIndex ls value 0



