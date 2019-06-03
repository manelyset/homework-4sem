module Tests

open NUnit.Framework
open FsUnit
open Downloader

[<Test>]
let ``spbu.ru contains 217 links`` () =
    let pages = pagesDownloader "spbu.ru"
    pages.Length |> should equal 217