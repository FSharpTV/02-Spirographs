#load "Domain.fs"
open System.Drawing
open FSharp.TV.Spirograph

let plotted =
    newTurtle()
    |> moveTo (500,500)
    |> penColor Color.Red
    |> drawline (130,130)
    |> drawCircle 75
    |> saveAs "_Brice"

//let turtle = defaultTurtle |> moveTo (500, 100)   
//let move turtle =
//    let turtle = drawCircle 100 turtle
//    let dl turtle x y =
//        let cx,cy = turtle.Position
//        drawline(cx + x, cy + y) turtle
//    match turtle.Position with
//    | x, y when x < 800 && y < 800 -> dl turtle 100 100
//    | _, y when y >= 800 -> dl turtle -100 -100
//    | _ -> turtle
//
//move >> move >> move >> saveAs "foo" <| turtle