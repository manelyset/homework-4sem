module Tests

open NUnit.Framework
open FsUnit
open Downloader

[<Test>]
let ``hwproj.me contains 18 links`` () =
    let pages = pagesDownloader "hwproj.me"
    pages.Length |> should equal 18