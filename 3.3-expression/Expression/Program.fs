module Expression

type Expression =
    | Number of int
    | Sum of Expression * Expression
    | Difference of Expression * Expression
    | Product of Expression * Expression
    | Quotient of Expression * Expression

/// <summary>Applies a given operation or function to two arguments of "option" type.</summary>
/// <param name="op">The function to apply.</param>
/// <param name="a">The 1st parameter.</param>
/// <param name="b">The 2nd parameter.</param>
/// <returns>The result of operation, if both arguments are Some, None otherwise.</returns>
let operation op a b =
    match a, b with
    | Some (a), Some (b) -> Some (op a b)
    | _, _ -> None
    
/// <summary>Estimates the value of the expression.</summary>
/// <param name="e">The expression to estimate.</param>
/// <returns>The result of expression if there is no arithmetical errors, None if there is a division by zero.</returns>
let rec result (e: Expression) =
    match e with
    | Number (x) -> Some (x)
    | Sum (e1, e2) -> operation (+) (result e1) (result e2)
    | Difference (e1, e2) -> operation (-) (result e1) (result e2)
    | Product (e1, e2) -> operation (*) (result e1) (result e2)
    | Quotient (e1, e2) when result e2 <> Some (0) -> operation (/) (result e1) (result e2)
    | Quotient (e1, e2) when result e2 = Some (0) -> None