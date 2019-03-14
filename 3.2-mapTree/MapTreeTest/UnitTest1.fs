module Tests

open NUnit.Framework
open FsUnit
open MapTree

[<Test>]
let ``increment all elements``() =
    mapTree (fun x -> x + 1) (Tree(1, Tree(2, Tip, Tip), Tree(3, Tip, Tip))) |> 
    should equal (Tree(2, Tree(3, Tip, Tip), Tree(4, Tip, Tip)))

[<Test>]
let ``square all elements``() =
    mapTree (fun x -> x * x) (Tree(1.0, Tree(-2.0, Tree(4.5, Tip, Tip), Tip), Tree(-3.0, Tree(5.1, Tip, Tip), Tree(6.0, Tip, Tip)))) |> 
    should equal (Tree(1.0, Tree(4.0, Tree(20.25, Tip, Tip), Tip), Tree(9.0, Tree(26.01, Tip, Tip), Tree(36.0, Tip, Tip))))

[<Test>]
let ``convert to strings``() =
    mapTree string (Tree(15, Tree(23656, Tip, Tip), Tree(3, Tip, Tip))) |> 
    should equal (Tree("15", Tree("23656", Tip, Tip), Tree("3", Tip, Tip)))

[<Test>]
let ``apply Seq.fold``() =
    mapTree (Seq.fold (+) 0) (Tree([1; 3; 7], Tree([], Tip, Tip), Tree([2; 5], Tip, Tip))) |> 
    should equal (Tree(11, Tree(0, Tip, Tip), Tree(7, Tip, Tip)))