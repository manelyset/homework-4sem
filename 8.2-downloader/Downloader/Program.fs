module Downloader

open System
open System.Text.RegularExpressions
open System.Net


let pagesDownloader url = 
    let downloadAndPrintAsync (url1 : string) =
        async {
            try
                let request = WebRequest.Create(url1) 
                use! response = request.AsyncGetResponse()
                use stream = response.GetResponseStream() 
                use reader = new IO.StreamReader(stream) 
                let html = reader.ReadToEnd() 
                do printfn "Read %d characters for %s..." html.Length url1
                return Some html
            with
                | _ -> printfn "A requested url is not available!"
                       return None
        }
    let downloadSubpages (page : string) =
        let pattern = new Regex("<a href\s*=\s*\"?(https?://[^\"]+)\"?\s*>")
        let sites = pattern.Matches page
        sites
        |> Seq.map (fun x -> x.Groups.[1].Value)
        |> Seq.map downloadAndPrintAsync  
        |> Async.Parallel          
        |> Async.RunSynchronously
        |> Array.toList
    let checkInitialPage = url |> downloadAndPrintAsync |> Async.RunSynchronously
    match checkInitialPage with
    | None -> [None]
    | Some page -> checkInitialPage :: (downloadSubpages page)


[<EntryPoint>]
let main (args) =
    pagesDownloader "https://www.macalester.edu/~abeverid/thrones.html" |> ignore
    0