#r "paket:
nuget Fake.DotNet.Cli
nuget Fake.Core.Target //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.DotNet

// Restore
Target.create "Restore" (fun _ ->
        DotNet.restore id "./LambdaInterpreter.sln"
    )
    
// Build application
Target.create "BuildApp" (fun _ ->
    DotNet.build id "./LambdaInterpreter/LambdaInterpreter.fsproj"
  )
  
// Build tests

Target.create "BuildTests" (fun _ ->
        DotNet.build id "./TestForLambdaInterpreter/TestForLambdaInterpreter.fsproj"
    )

// Run tests
Target.create "RunTests" (fun _ ->
        DotNet.test id "TestForLambdaInterpreter/TestForLambdaInterpreter.fsproj"
    )

// Dependencies
open Fake.Core.TargetOperators
"Restore" ==>
    "BuildApp" ==>
    "BuildTests" ==>
    "RunTests"

// start build​
Target.runOrDefault "RunTests"