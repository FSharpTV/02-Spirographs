open System.Drawing
open System.IO
open System


type Plotter = {
    position: int*int
    color: Color
    direction: float
    bitmap: Bitmap
    }

let naiveLine (x1,y1) plotter =
    let updatedPlotter = { plotter with position=(x1,y1) }
    let (x0,y0) = plotter.position
    let xLen = float (x1-x0)
    let yLen = float (y1-y0)

    let x0,y0,x1,y1 = if x0 > x1 then x1,y1,x0,y0 else x0,y0,x1,y1
    if xLen <> 0.0 then
        for x in x0..x1 do
            let proportion = float (x-x0) / xLen
            let y = int (Math.Round(proportion * yLen)) + y0
            printfn "%i" y
            plotter.bitmap.SetPixel(x,y, plotter.color)

    let x0,y0,x1,y1 = if y0 > y1 then x1,y1,x0,y0 else x0,y0,x1,y1
    if yLen <> 0.0 then
        for y in y0..y1 do
            let proportion = float (y-y0) / yLen
            let x = int (Math.Round(proportion * xLen)) + x0
            printfn "%i" x
            plotter.bitmap.SetPixel(x,y, plotter.color)

    updatedPlotter

let turn amt plotter =
    plotter

let move dist plotter =
    plotter

let pathAndFileName =
    Path.Combine(__SOURCE_DIRECTORY__, "refactor.png")

let bitmap = new Bitmap(64, 64)

let initialPlotter = { 
    position    = (32,32)
    color       = Color.Goldenrod
    direction   = 90.0
    bitmap      = bitmap }

let drawn = naiveLine (44, 44) initialPlotter

drawn.bitmap.Save(pathAndFileName)

