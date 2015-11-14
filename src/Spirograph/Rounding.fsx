open System.Drawing
open System.IO
open System

let naiveLineCeiling (x0,y0) (x1,y1) color (bitmap:Bitmap) =
    let xLen = float (x1-x0)
    let yLen = float (y1-y0)

    for x in x0..x1 do
        let proportion = float (x-x0) / xLen
        let y = int (Math.Ceiling(proportion * yLen)) + y0
        printfn "%i" y
        bitmap.SetPixel(x,y, color)

    for y in y0..y1 do
        let proportion = float (y-y0) / yLen
        let x = int (Math.Ceiling(proportion * xLen)) + x0
        printfn "%i" x
        bitmap.SetPixel(x,y, color)

let naiveLine (x0,y0) (x1,y1) color (bitmap:Bitmap) =
    let xLen = float (x1-x0)
    let yLen = float (y1-y0)

    for x in x0..x1 do
        let proportion = float (x-x0) / xLen
        let y = int (Math.Round(proportion * yLen)) + y0
        printfn "%i" y
        bitmap.SetPixel(x,y, color)

    for y in y0..y1 do
        let proportion = float (y-y0) / yLen
        let x = int (Math.Round(proportion * xLen)) + x0
        printfn "%i" x
        bitmap.SetPixel(x,y, color)

let naiveLineFloor (x0,y0) (x1,y1) color (bitmap:Bitmap) =
    let xLen = float (x1-x0)
    let yLen = float (y1-y0)

    for x in x0..x1 do
        let proportion = float (x-x0) / xLen
        let y = int (Math.Floor(proportion * yLen)) + y0
        printfn "%i" y
        bitmap.SetPixel(x,y, color)

    for y in y0..y1 do
        let proportion = float (y-y0) / yLen
        let x = int (Math.Floor(proportion * xLen)) + x0
        printfn "%i" x
        bitmap.SetPixel(x,y, color)

let pathAndFileName =
    Path.Combine(__SOURCE_DIRECTORY__, "naive.png")

let bitmap = new Bitmap(32, 32)

naiveLineFloor      (3,7)   (4,27)  Color.Red bitmap
naiveLine           (8,7)   (9,27)  Color.Red bitmap
naiveLineCeiling    (13,7)  (14,27) Color.Red bitmap

bitmap.Save(pathAndFileName)

