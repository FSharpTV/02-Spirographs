open System.Drawing
open System.IO
open System


type Plotter = {
    position    : int*int
    color       : Color
    direction   : float
    bitmap      : Bitmap
    }

let bLine (x1, y1) plotter = 
    let x0, y0      = plotter.position
    let newPlotter   = { plotter with position = x1, y1 }
    let steep       = abs (y1 - y0) > abs (x1 - x0)
  
    let x0, y0, x1, y1 = 
        if steep 
        then y0, x0, y1, x1
        else x0, y0, x1, y1
  
    let x0, y0, x1, y1 = 
        if x0 > x1 
        then x1, y1, x0, y0
        else x0, y0, x1, y1
  
    let x', y' = float (x1 - x0), float (abs (y1 - y0))
  
    let step = if y0 < y1 then 1 else -1
  
    let rec draw (e:float) x y = 
        if x <= int x1 
        then 
            if steep 
            then plotter.bitmap.SetPixel(y, x, plotter.color)
            else plotter.bitmap.SetPixel(x, y, plotter.color)

            if e < y' 
            then draw (e - y' + x') (x + 1) (y + step)
            else draw (e - y') (x + 1) y
  
    draw (x' / 2.0) (int x0) (int y0)
    newPlotter


let nLine (x1,y1) plotter =
    let updatedPlotter = { plotter with position=(x1,y1) }
    let (x0,y0) = plotter.position
    let xLen = float (x1-x0)
    let yLen = float (y1-y0)

    let x0,y0,x1,y1 = if x0 > x1 then x1,y1,x0,y0 else x0,y0,x1,y1
    if xLen <> 0.0 then
        for x in x0..x1 do
            let proportion = float (x-x0) / xLen
            let y = int (Math.Round(proportion * yLen)) + y0
            plotter.bitmap.SetPixel(x,y, plotter.color)

    let x0,y0,x1,y1 = if y0 > y1 then x1,y1,x0,y0 else x0,y0,x1,y1
    if yLen <> 0.0 then
        for y in y0..y1 do
            let proportion = float (y-y0) / yLen
            let x = int (Math.Round(proportion * xLen)) + x0
            plotter.bitmap.SetPixel(x,y, plotter.color)

    updatedPlotter

let turn amt plotter =
    let newDir = plotter.direction + amt
    let angled = { plotter with direction=newDir }
    angled

let move dist plotter =
    let currPos = plotter.position
    let angle   = plotter.direction
    let startX  = fst currPos
    let startY  = snd currPos
    let rads    = (angle - 90.0) * Math.PI/180.0
    let roundX  = (float startX) + (float dist) * cos rads
    let roundY  = (float startY) + (float dist) * sin rads
    let endX    = int (Math.Round(roundX))
    let endY    = int (Math.Round(roundY))
    let plotted = bLine (endX, endY) plotter
    plotted

let polygon (sides:int) length plotter =
    let angle = Math.Round(360.0/float sides)
    Seq.fold (fun s i -> turn angle (move length s)) plotter [1.0..(float sides)]

let semiCircle (sides:int) length plotter =
    let angle = Math.Round(360.0/float sides)
    Seq.fold (fun s i -> turn angle (move length s)) plotter [1.0..(float sides/2.0)]

let thirdCirc (sides:int) length plotter =
    let angle = Math.Round(360.0/float sides)
    Seq.fold (fun s i -> turn angle (move length s)) plotter [1.0..(float sides/3.0)]

let fifthCirc (sides:int) length plotter =
    let angle = Math.Round(360.0/float sides)
    Seq.fold (fun s i -> turn angle (move length s)) plotter [1.0..(float sides/5.0)]

let fifthteenth (sides:int) length plotter =
    let angle = Math.Round(360.0/float sides)
    Seq.fold (fun s i -> turn angle (move length s)) plotter [1.0..(float sides/15.0)]

let moveTo (x1,y1) plotter =
    { plotter with position=(x1,y1) }

let changeColor color plotter =
    { plotter with color=color }

let saveAs name plotter =
    let path = Path.Combine(__SOURCE_DIRECTORY__, name)
    plotter.bitmap.Save(path)

let generate cmdStripe times fromPlotter =
    let cmdsGen = 
        seq { 
            while true do 
                yield! cmdStripe }

    let cmds = cmdsGen |> Seq.take (times*(List.length cmdStripe))

    cmds |> Seq.fold (fun plot cmd -> cmd plot) fromPlotter 
