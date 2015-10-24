#load "Spirograph.fs"
open System.Drawing
open FSharp.TV.Spirograph

let clippingExample =
    newTurtle()
    |> moveTo (-50.0,50.0)
    |> drawCircle (float32 565.0)
    |> saveAs "ClippedCircle"
