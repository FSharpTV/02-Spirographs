#load "Plotting.fsx"
open Plotting
open System.Drawing
open System.IO
    
        
let pathAndFileName =
    Path.Combine(__SOURCE_DIRECTORY__, "longGen.png")

let bitmap = new Bitmap(400, 400)

let initialPlotter = { 
    position    = (200,200)
    color       = Color.DarkGreen
    direction   = 90.0
    bitmap      = bitmap }


let cmdsStripe =
    [ move 15
      turn 15.0
      polygon 3 10
    ]

let cmdsGen = seq { while true do yield! cmdsStripe }

let imageCommands = cmdsGen |> Seq.take 75

let image =
    imageCommands
    |> Seq.fold (fun plot cmds -> plot |> cmds) initialPlotter

image.bitmap.Save(pathAndFileName)
