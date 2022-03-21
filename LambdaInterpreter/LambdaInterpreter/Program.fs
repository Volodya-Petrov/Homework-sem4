type VariableType = int
type Term =
    | Variable of VariableType
    | Application of Term * Term
    | LambdaAbstraction of VariableType * Term
    
    
let rec getFreeVariables term (free:Set<'T>) =
    match term with
    | Variable(var) -> free.Add(var)
    | LambdaAbstraction(var, termInLambda) -> (getFreeVariables termInLambda free).Remove(var) 
    | Application (term1, term2) -> (getFreeVariables term1 free) + (getFreeVariables term2 free)
    
let rec substitution term1 term2 variable =
    match term1 with
    | Variable (var) -> if var = variable then term2 else Variable (var)
    | Application (termInApp1, termInApp2) -> Application (substitution termInApp1 term2 variable, substitution termInApp2 term2 variable)
    | LambdaAbstraction (var, term) ->
        match var with
        | v when v = variable -> LambdaAbstraction(var, term)
        | v when (getFreeVariables term2 Set.empty).Contains(var) = false || (getFreeVariables term Set.empty).Contains(variable) = false ->
            LambdaAbstraction(var, substitution term term2 variable)
        | _ ->
           let newVar = ((getFreeVariables term2 Set.empty) + (getFreeVariables term Set.empty)).MaximumElement + 1
           let newTerm = Variable(newVar)
           let termWithNewVar = substitution term newTerm var
           LambdaAbstraction(newVar, substitution termWithNewVar term2 variable)
  
let rec betaReduction term =
    match term with
    | Variable (var) -> Variable(var)
    | LambdaAbstraction(var, termInLambda) -> LambdaAbstraction(var, betaReduction termInLambda)
    | Application (LambdaAbstraction (var, termInLambda), termForSubstitution) ->
        let newTerm = substitution termInLambda termForSubstitution var
        betaReduction newTerm
    | Application (term1, term2) -> Application(betaReduction term1, betaReduction term2)