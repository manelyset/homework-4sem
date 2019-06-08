module Lambda

type LambdaTerm = 
    | Variable of char
    | Application of LambdaTerm * LambdaTerm
    | Abstraction of char * LambdaTerm

/// <summary>
/// Finds all free variables in a lambda-term
/// </summary>
/// <param name="l1">The lambda-term</param>\
/// <returns>A set of free variables names</returns>
let rec getVars (l:LambdaTerm)=
    match l with
    | Variable(x) -> Set.add x Set.empty
    | Application(t1, t2) -> Set.union (getVars t1) (getVars t2)
    | Abstraction(x, t) -> Set.difference (getVars t) (Set.add x Set.empty)

/// <summary>
/// Replaces all the entries of the given variable with the given term, performing alpha-conversion when necessary
/// </summary>
/// <param name="l1">The initial lambda term</param>
/// <param name="x">The variable to be replaced</param>
/// <param name="T">The term to replace with</param>
/// <returns>The lambda-term with replaced variables</returns>
let rec replace (l1:LambdaTerm) (x:char) (T:LambdaTerm) =
    let alpha (l:LambdaTerm) (availableNames:Set<char>) =
        if Set.isEmpty availableNames then failwith "No variables names available!"
        let varName = Set.minElement availableNames
        match l with
        | Abstraction(z, t) -> Abstraction(varName, (replace t z (Variable(varName))))
        | _ -> failwith "No alpha reduction available: this term is not a lambda-abstraction"
    match l1 with
    | Variable(z) when (z = x) -> T
    | Application(t1, t2) -> Application(replace t1 x T, replace t2 x T)
    | Abstraction(z, t) when T <> Variable(x) -> 
        if (not (Set.contains z (getVars T)) || not (Set.contains x (getVars l1))) then
            Abstraction(z, replace t x T)
        else
            let alphaReduced = alpha l1 (Set.difference (Set.ofSeq ['a'..'z']) (Set.union (getVars t) (getVars T)))
            replace alphaReduced x T            
            
    | _ -> l1

/// <summary>
/// Performs the beta-reduction of a lambda-term by normal strategy
/// </summary>
/// <param name="l">The lambda-term to reduce</param>
/// <returns>The reduced lambda-term</returns>
let rec betaReduce (l:LambdaTerm) =
    match l with
    | Variable(z) -> Variable(z)
    | Application(t1, t2) ->
        match t1 with
        | Abstraction(z, _) -> 
            let newTerm = 
                let replaced = replace t1 z t2 
                match replaced with
                | Abstraction(_, t) -> t
                | _ -> failwith "something went wrong in the substitution"
            betaReduce newTerm
        | _ -> Application(betaReduce t1, betaReduce t2)
    | Abstraction(z, t) -> Abstraction(z, betaReduce t)

let res = betaReduce (Application(Abstraction('x', Abstraction('y', Application(Variable('x'), Variable('y')))), Variable('y')))