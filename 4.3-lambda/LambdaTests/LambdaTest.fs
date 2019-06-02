module Tests

open NUnit.Framework
open FsUnit
open Lambda

[<Test>]
let ``beta reduction without substitutions``() =
    betaReduce (Variable 'x') |> should equal (Variable 'x')
    betaReduce (Application(Variable 'a', Variable 'b')) |> should equal (Application(Variable 'a', Variable 'b'))

//λx.x (a b) = a b
[<Test>]
let ``a simple reduction test``() =
    betaReduce (Application(Abstraction('x', Variable 'x'), Application(Variable 'a', Variable 'b'))) |> should equal (Application(Variable 'a', Variable 'b'))

//λx.(λy.(x y)) y = λa.(y a)
[<Test>]
let ``a simple reduction with alpha conversion``() =
    betaReduce (Application(Abstraction('x', Abstraction('y', Application(Variable('x'), Variable('y')))), Variable('y'))) |> should equal (Abstraction('a', Application(Variable('y'), Variable ('a'))))

//(λa.(a b)) (λc.c d) = (λc.c d) b = d b
[<Test>]
let ``multiple substitiutions``() =
    betaReduce (Application(Abstraction('a', Application(Variable 'a', Variable 'b')),
                            Application(Abstraction('c', Variable 'c'), Variable 'd'))) |>
                            should equal (Application(Variable 'd', Variable 'b'))