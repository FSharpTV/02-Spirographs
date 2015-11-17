open System.Drawing
open System.IO
open System

let naiveLine (x0:int,y0:int) (x1:int,y1:int) color (bitmap:Bitmap) =
    let xLen:float = float (x1 - x0)
    let yLen:float = float (y1 - y0)

     
    let x0,y0,x1,y1 = if x0 > x1 then x1,y1,x0,y0 else x0,y0,x1,y1
    if xLen <> 0.0 then
        for x in x0..x1 do 
            let proportion:float =  float (x-x0) / xLen
            let y:int = (int (Math.Round(proportion * yLen))) + y0
            printfn "%i" y
            bitmap.SetPixel(x, y, color)

    let x0,y0,x1,y1 = if y0 > y1 then x1,y1,x0,y0 else x0,y0,x1,y1
    if yLen <> 0.0 then
        for y in y0..y1 do 
            let proportion  = float (y-y0)/ yLen
            let x :int = (int (Math.Round(proportion * xLen))) + x0
            bitmap.SetPixel(x, y, color)

let pathAndFileName =
    Path.Combine(__SOURCE_DIRECTORY__, "naive.png")

let bitmap = new Bitmap(32, 32)

naiveLine (0,0) (30,0) Color.Black bitmap
naiveLine (0,0) (15,30) Color.Black bitmap
naiveLine (0,0) (0,30) Color.Black bitmap

naiveLine (30,30) (30,0) Color.Black bitmap
naiveLine (30,30) (0,15) Color.Black bitmap
naiveLine (30,30) (0,30) Color.Black bitmap

//naiveLine (5,20) (4,20) Color.Black bitmap
//naiveLine (24.0,14.0) (4.0,4.0) Color.Black bitmap

(*
naiveLine (3,7) (4,27) Color.Red bitmap
naiveLine (6,7) (10,27) Color.Blue bitmap
naiveLine (10,7) (13,20) Color.Green bitmap
naiveLine (13,7) (17,17) Color.Orange bitmap
naiveLine (16,7) (22,17) Color.Black bitmap 
*)

bitmap.Save(pathAndFileName)