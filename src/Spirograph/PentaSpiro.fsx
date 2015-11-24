#load "Plotting.fsx"
open Plotting
open System.Drawing
open System.IO

let initialPlotter = { 
    position    = (200,200)
    color       = Color.DarkGreen
    direction   = 90.0
    bitmap      = new Bitmap(400,400) }

let pathAndFileName =
    Path.Combine(__SOURCE_DIRECTORY__, "pentaSpiro.png")   
 
let repeat =
    [ move 15
      turn 15.0
      polygon 5 55 ]

let cmdsGen = seq { while true do yield! repeat }
let innerCmds = cmdsGen |> Seq.take 75

let cmds =
    seq {
        yield! innerCmds 
    }

let instructions = Seq.fold (fun s f -> f s) initialPlotter cmds

instructions.bitmap.Save(pathAndFileName)
