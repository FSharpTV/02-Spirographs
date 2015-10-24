#load "Spirograph.fs"
open System.Drawing
open FSharp.TV.Spirograph

let manualPlotting =
    Seq.fold 
        (fun s f -> f s) 
        (newTurtle())
        [ 
        moveTo (500.0,500.0)
        polygon 8.0 175
        turn 45.0
        moveTo (500.0,500.0)
        polygon 8.0 175
        turn 45.0
        moveTo (500.0,500.0)
        polygon 8.0 175
        turn 45.0
        moveTo (500.0,500.0)
        polygon 8.0 175
        turn 45.0
        moveTo (500.0,500.0)
        polygon 8.0 175
        turn 45.0
        moveTo (500.0,500.0)
        polygon 8.0 175
        turn 45.0
        moveTo (500.0,500.0)
        polygon 8.0 175
        turn 45.0
        moveTo (500.0,500.0)
        polygon 8.0 175
        turn 45.0
        saveAs "iflower" ]