module PhonesTests

open NUnit.Framework
open FsUnit
open FsCheck
open Phones

let testbook = 
    [] |> 
    addNumber "alice" "1234567" |> 
    addNumber "ivan" "89110000000" |> 
    addNumber "anna" "7777777"

[<Test>]
let ``anna's number is 7777777`` () =
    findNumber "anna" testbook |> should equal "7777777"

[<Test>]
let ``there is no name jack`` () =
    findNumber "jack" testbook |> should equal "There is no person having this name!"

[<Test>]
let ``alice's number is 1234567`` () =
    findName "1234567" testbook |> should equal "alice"

[<Test>]
let ``there is no number 12345678`` () =
    findName "12345678" testbook |> should equal "There is no person having this number!"

let WriteRead randombook =
    writeToFile "data.dat" randombook
    readFromFile "data.dat"

[<Test>]
let ``a combination of writeToFile and readFromFile gives the same result``() =
    Check.Quick (fun randombook -> WriteRead randombook = randombook)