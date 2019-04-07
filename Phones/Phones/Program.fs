module Phones

open System
open System.IO
open System.Runtime.Serialization.Formatters.Binary
open System

let addNumber phonebook = 
    printfn "Enter name: "
    let newName = Console.ReadLine()
    printfn "Enter number: "
    let newNumber = Console.ReadLine()
    (newName, newNumber)::phonebook

let rec findNumber name phonebook =
    match phonebook with
    | (name1, number1)::t ->
        if name1 = name then number1
        else findNumber name t
    | [] -> "There is no person having this name!"

let rec findName number phonebook =
    match phonebook with
    | (name1, number1)::t ->
        if number1 = number then name1
        else findNumber number t
    | [] -> "There is no person having this number!"

let rec printBook phonebook =
    if phonebook<>[] then
        printfn "%s\t%s" (fst (List.head phonebook)) (snd (List.head phonebook))
        printBook (List.tail phonebook)

let writeToFile fileName phonebook = 
    let writeValue outputStream x =
        let formatter = new BinaryFormatter()
        formatter.Serialize(outputStream, box x)
    let fsOut = new FileStream(fileName, FileMode.Create)
    writeValue fsOut phonebook
    fsOut.Close()

let readFromFile fileName = 
    let readValue inputStream =
        let formatter = new BinaryFormatter()
        let res = formatter.Deserialize(inputStream)
        unbox res
    let fsIn = new FileStream(fileName, FileMode.Open)
    let res : (string*string) list = readValue fsIn
    fsIn.Close()
    res

[<EntryPoint>]
let main args =
    let rec mainLoop phonebook =
        printfn <|
        "1 - Exit
        2 - Add new recording
        3 - Find a number by name
        4 - Find a name by number
        5 - Print a phonebook
        6 - Write a phonebook to file
        7 - Read a new phonebook from file"
        let command = Console.ReadLine()
        match command with
        | "1" -> printfn "Exit success!"
        | "2" -> mainLoop (addNumber phonebook)
        | "3" -> 
            printfn "Enter name: "
            let name = Console.ReadLine()
            printfn "%s" (findNumber name phonebook)
            mainLoop phonebook
        | "4" -> 
            printfn "Enter number: "
            let number = Console.ReadLine()
            printfn "%s" (findName number phonebook)
            mainLoop phonebook
        | "5" -> 
            printBook phonebook
            mainLoop phonebook
        | "6" ->
            writeToFile "phonebook.dat" phonebook
            mainLoop phonebook
        | "7" -> mainLoop (readFromFile "phonebook.dat")
        | _ -> 
            printfn "Please enter a command from the list!"
            mainLoop phonebook
    mainLoop []
    0  