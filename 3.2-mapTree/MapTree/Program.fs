module MapTree

type Tree<'a> = 
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Tip

/// <summary>Applies a given function to each element of a tree.</summary>
/// <param name="mapping">The function to apply to each element.</param>
/// <param name="str">The input tree.</param>
/// <returns>The result tree.</returns>
let rec mapTree f tree =
    match tree with
    | Tip -> Tip
    | Tree(x, left, right) -> Tree(f(x), mapTree f left, mapTree f right)

