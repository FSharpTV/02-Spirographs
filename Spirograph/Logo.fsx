#load "Spirograph.fs"
open System.Drawing
open FSharp.TV.Spirograph


let plotted =
    newTurtle()
    |> moveTo (500.0,500.0)
    |> polygon 90.0 10
    |> saveAs "_Brice"


let plotty =
    Seq.fold 
        (fun s f -> f s) 
        (newTurtle())
        [ moveTo (500.0,500.0); polygon 90.0 10; saveAs "folded2" ]


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