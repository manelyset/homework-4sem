module Tests

open NUnit.Framework
open FsUnit
open Downloader

[<Test>]
let ``trying to download from a nonexistent url`` () =
    let pagelist = pagesDownloader "http://nonexistent111.ru/"
    pagelist |> List.length |> should equal 1
    pagelist |> List.head |> should equal None

[<Test>]
let ``downloading from an existing url`` () =
        let res = pagesDownloader "https://spbu.ru"
        res.Length |> should equal 28