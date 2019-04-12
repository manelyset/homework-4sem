module MergeSortTests

open NUnit.Framework
open FsUnit
open MergeSort

[<Test>]
let ``[5; 3; 1] and [6; 4; 2] should be merged into [1; 2; 3; 4; 5; 6]`` () =
    merge [5; 3; 1] [6; 4; 2] |> should equal [1; 2; 3; 4; 5; 6]

[<Test>]
let ``[3; 2; 1] and [6; 5; 4] should be merged into [1; 2; 3; 4; 5; 6]`` () =
    merge [3; 2; 1] [6; 5; 4] |> should equal [1; 2; 3; 4; 5; 6]

[<Test>]
let ``[10; 7; 1] and [25; 20; 15; 10] should be merged into [1; 7; 10; 10; 15; 20; 25]`` () =
    merge [10; 7; 1] [25; 20; 15; 10] |> should equal [1; 7; 10; 10; 15; 20; 25]

[<Test>]
let ``[1; 2; 3; 4] should be splitted into [2; 1] and [3; 4]`` () =
    split [1; 2; 3; 4] |> should equal ([2; 1], [3; 4])

[<Test>]
let ``[1; 2; 3] should be splitted into [1] and [2; 3]`` () =
    split [1; 2; 3] |> should equal ([1], [2; 3])

[<Test>]
let ``sorting [14; 7; 8; 28; 9; 15; 29; 12; 6; 26]`` () =
    mergeSort [14; 7; 8; 28; 9; 15; 29; 12; 6; 26] |> should be ascending

[<Test>]
let ``sorting [10; 30; 13; 26; 16; 17; 4]`` () =
    mergeSort [10; 30; 13; 26; 16; 17; 4] |> should be ascending

[<Test>]
let ``sorting []`` () =
    mergeSort [] |> should equal []

[<Test>]
let ``sorting [1; 2; 3; 4; 5; 6]`` () =
    mergeSort [1; 2; 3; 4; 5; 6] |> should be ascending

[<Test>]
let ``sorting [81; 77; 64; 59; 42; 33]`` () =
    mergeSort [81; 77; 64; 59; 42; 33] |> should be ascending
