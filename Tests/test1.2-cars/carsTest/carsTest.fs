module Tests

open NUnit.Framework
open FsUnit
open Auto

let list1 : Auto list = [Car(200, "Mercedes", "mod1", "black", true); Car(500, "BMW", "mod2", "white", true); Truck(1000, "Ford", 2000, true)]
let list2 : Auto list = [Car(200, "Mercedes", "mod1", "black", true); Car(500, "BMW", "mod2", "white", true); Truck(1000, "Ford", 2000, false)]
let list3 : Auto list = [Car(200, "Mercedes", "mod1", "black", true); Car(500, "BMW", "mod2", "white", true); Truck(1000, "Mercedes", 2000, true)]

[<Test>]
let ``sum of list1 prices is 1700``() =
    sumPrices list1 |> should equal 1700

[<Test>]
let ``sum of list2 prices is 700``() =
    sumPrices list2 |> should equal 700

[<Test>]
let ``marks in list1``() =
    marksList list1 |> should equal ["BMW"; "Ford"; "Mercedes"]

[<Test>]
let ``marks in list2 - not all cars are for sale``()=
    marksList list2 |> should equal ["BMW"; "Mercedes"]

[<Test>]
let ``repetitions in the marks list``() =
    marksList list3 |> should equal ["BMW"; "Mercedes"]

[<Test>]
let ``sumPrices for an empty list``() =
    sumPrices [] |> should equal 0

[<Test>]
let ``marksList for an empty list``() =
    marksList [] |> should equal []