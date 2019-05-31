module Auto

/// <summary>
/// The class representing an automobile in the car showroom
/// </summary>
type Auto (price:int, mark:string, forSale:bool) =
    /// <summary>
    /// The automobile price (thousands of roubles)
    /// </summary>
    member this.Price = price
    /// <summary>
    /// The automobile mark
    /// </summary>
    member this.Mark = mark
    /// <summary>
    /// Tells whether an automobile is for sale or not
    /// </summary>
    member this.ForSale = forSale

/// <summary>
/// The class representing a car, inherits Auto
/// </summary>
type Car (price:int, mark:string, model:string, color:string, forSale:bool) =
    inherit Auto(price, mark, forSale)
    /// <summary>
    /// The car model
    /// </summary>
    member this.Model = model
    /// <summary>
    /// The car color
    /// </summary>
    member this.Color = color

/// <summary>
/// The class representing a truck, inherits Auto
/// </summary>
type Truck (price:int, mark:string, weight:int, forSale:bool) =
    inherit Auto(price, mark, forSale)
    /// <summary>
    /// The truck weight (in Kgs)
    /// </summary>
    member this.Weight = weight

/// <summary>
/// Calculates the sum of auto prices for the autos which are for sale
/// </summary>
/// <param name="autos">The list of autos</param>
/// <returns>The sum of prices</returns>
let sumPrices (autos:(Auto list)) = 
    List.filter (fun (a:Auto) -> a.ForSale) autos |> List.fold (fun acc (a:Auto) -> acc + a.Price) 0

/// <summary>
/// Creates a list of all marks of autos which are for sale
/// </summary>
/// <param name="autos">The list of autos</param>
/// <returns>The list of marks without repetitions</returns>
let marksList(autos:(Auto list)) =
    let rec marksListAcc (autos:(Auto list)) (marks:Set<string>) =
        match autos with
        | [] -> marks
        | h :: t -> marksListAcc t (Set.add h.Mark marks)
    let set = marksListAcc (List.filter (fun (a:Auto) -> a.ForSale) autos) (Set.empty)
    Set.fold (fun acc a -> a :: acc) [] set |> List.rev

