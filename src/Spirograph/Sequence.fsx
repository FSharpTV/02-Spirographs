#load "Plotting.fsx"
open Plotting
open System.Drawing
open System.IO

let saveAs name plotter =
    let sequencePath = Path.Combine(__SOURCE_DIRECTORY__, name)
    plotter.bitmap.Save(sequencePath)

let cmdsStripe =
    [ turn 75.0
      move 100
    ]

let generate cmdStripe times =
    let cmdsGen = 
        seq { 
            while true do 
                yield! cmdsStripe }

    let cmds = cmdsGen |> Seq.take times

    let initialPlotter = 
        { position  = 200,150
          color     = Color.Orange
          direction = 180.0
          bitmap    = new Bitmap(400,400) 
        }

    cmds |> Seq.fold (fun plot cmd -> cmd plot) initialPlotter 



generate cmdsStripe 48 |> saveAs "sequence.png"