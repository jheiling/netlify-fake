#nowarn "0213"
#r "paket: 
nuget Fake.Core.Target
nuget Fake.IO.FileSystem //"
#load "./.fake/fake.fsx/intellisense.fsx"

open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO

//
// Config
//

let srcDir = "src"
let buildDir = "build"

//
// Targets
//

let cleanTarget = "Clean"
let buildTarget = "Build"

Target.create cleanTarget (fun _ ->
    Shell.cleanDir buildDir
)

Target.create buildTarget (fun _ ->
    Shell.copyFile buildDir (srcDir + "/index.html")
)

//
// Dependencies
//

cleanTarget
    ==> buildTarget

//
// Start
//

Target.runOrDefault buildTarget