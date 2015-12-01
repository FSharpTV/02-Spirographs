#load "Plotting.fsx"
open Plotting
open System.Drawing
open System.IO

let initialPlotter = 
    { position  = 1000,1000
      color     = Color.Orange
      direction = 0.0
      bitmap    = new Bitmap(2000,2000) 
    }

let cmdsStripe = 
    [ changeColor Color.DarkGoldenrod
      move 45
      turn 45.4
      move 100
      fifthCirc 45 45
      changeColor Color.Red
      turn 90.0
      move 45
      fifthteenth 45 45
      turn 45.0
      move 145
      turn 180.4
      move 50
      changeColor Color.Blue
      fifthCirc 50 50
      moveTo (1000,1000)
    ]


generate cmdsStripe 50 initialPlotter |> saveAs "Experiment.png"