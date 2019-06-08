module Phones

open System
open System.IO
open System.Runtime.Serialization.Formatters.Binary
open System

/// <summary>
/// Adds a new recording to the list
/// </summary>
/// <param name="newName">The new person's name</param>
/// <param name="newNumber">The new person's number</param>
/// <param name="phonebook">The list of phones</param>
let addNumber newName newNumber phonebook = 
    (newName, newNumber) :: phonebook

/// <summary>
/// Finds a number of person with a given name
/// </summary>
/// <param name="name">The name of person</param>
/// <param name="phonebook">The list of phones</param>
/// <returns>The number if there is a person with the given name, the string "There is no person having this name!" otherwise</returns>
let rec findNumber name phonebook =
    match phonebook with
    | (name1, number1) :: t ->
        if name1 = name then number1
        else findNumber name t
    | [] -> "There is no person having this name!"

/// <summary>
/// Finds a name of person with a given number
/// </summary>
/// <param name="number">The number of person</param>
/// <param name="phonebook">The list of phones</param>
/// <returns>The name if there is a person with the given number, the string "There is no person having this number!" otherwise</returns>
let rec findName number phonebook =
    match phonebook with
    | (name1, number1) :: t ->
        if number1 = number then name1
        else findName number t
    | [] -> "There is no person having this number!"

/// <summary>
/// Prints a phonebook to the console
/// </summary>
/// <param name="phonebook">A list of phones to print</param>
let rec printBook phonebook =
    if phonebook <> [] then
        printfn "%s\t%s" (fst (List.head phonebook)) (snd (List.head phonebook))
        printBook (List.tail phonebook)

/// <summary>
/// Writes a phonebook to the binary file with a given name
/// </summary>
/// <param name="fileName">The name of binary file</param>
/// <param name="phonebook">The list of phones</param>
let writeToFile fileName phonebook = 
    let writeValue outputStream x =
        let formatter = new BinaryFormatter()
        formatter.Serialize(outputStream, box x)
    use fsOut = new FileStream(fileName, FileMode.Create)
    writeValue fsOut phonebook
/// <summary>
/// Reads a phonebook from the binary file
/// </summary>
/// <param name="fileName">The name of file</param>
/// <returns>The new list of phones read from file</returns>
let readFromFile fileName = 
    let readValue inputStream =
        let formatter = new BinaryFormatter()
        let res = formatter.Deserialize(inputStream)
        unbox res
    let fsIn = new FileStream(fileName, FileMode.Open)
    let res : (string * string) list = readValue fsIn
    fsIn.Close()
    res

/// <summary>
/// The interactive loop to execute at the console
/// </summary>
[<EntryPoint>]
let main args =
    let rec mainLoop phonebook =
        printfn <| "
        1 - Exit
        2 - Add new recording
        3 - Find a number by name
        4 - Find a name by number
        5 - Print a phonebook
        6 - Write a phonebook to file
        7 - Read a new phonebook from file"
        let command = Console.ReadLine()
        match command with
        | "1" -> printfn "Exit success!"
        | "2" ->
            printfn "Enter name: "
            let newName = Console.ReadLine()
            printfn "Enter number: "
            let newNumber = Console.ReadLine()
            mainLoop (addNumber newName newNumber phonebook)
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
