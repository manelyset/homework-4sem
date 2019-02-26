module Tests

open NUnit.Framework
open FsUnit
open MergeSort

[<Test>]
let ``[1; 2; 3] should be splitted into [1] and [2; 3]`` = 
    split [1; 2; 3] |> should equal ([1], [2; 3])
