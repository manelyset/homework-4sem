module Tests

open NUnit.Framework
open FsUnit
open Downloader

[<Test>]
let ``spbu.ru contains 217 links`` () =
    let pagelist = pagesDownloader "spbu.ru"
    pagelist |> List.length |> should equal 217

[<Test>]
let ``trying to download from a nonexistent url`` () =
    let pagelist = pagesDownloader "http://nonexistent111.ru/"
    pagelist |> List.length |> should equal 1
    pagelist |> List.head |> should equal None