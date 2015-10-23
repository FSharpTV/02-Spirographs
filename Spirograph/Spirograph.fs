module FSharp.TV.Spirograph

open System.Drawing
open System
open System.IO

type Turtle = {
    position : float * float
    color : Color
    direction : float
    bitmap : Bitmap }

let bresenham (x1, y1) turtle = 
  let x0, y0 = turtle.position
  let newTurtle = { turtle with position = x1, y1 }
  let steep = abs (y1 - y0) > abs (x1 - x0)
  
  let x0, y0, x1, y1 = 
    if steep then y0, x0, y1, x1
    else x0, y0, x1, y1
  
  let x0, y0, x1, y1 = 
    if x0 > x1 then x1, y1, x0, y0
    else x0, y0, x1, y1
  
  let x', y' = (x1 - x0), (abs (y1 - y0))
  
  let step = 
    if y0 < y1 then 1
    else -1
  
  let rec draw e x y = 
    if x <= int x1 then 
      if steep then turtle.bitmap.SetPixel(y, x, turtle.color)
      else turtle.bitmap.SetPixel(x, y, turtle.color)
      if e < y' then draw (e - y' + x') (x + 1) (y + step)
      else draw (e - y') (x + 1) y
  
  draw (x' / 2.0) (int x0) (int y0)
  newTurtle

let withFilePath f = Path.Combine(__SOURCE_DIRECTORY__, f)

let saveAs name turtle = 
    turtle.bitmap.Save(withFilePath (name + ".png"), Imaging.ImageFormat.Png)
    turtle

let newCanvas (x : float) y = new Bitmap(int x, int y)

let width = 1000.0
let height = 1000.0
let image = newCanvas width height

let defaultTurtle = 
  { position = 0.0, 0.0
    color = Color.Red
    direction = 0.0
    bitmap = newCanvas width height }

let newTurtle() = defaultTurtle

let logPosition turtle = 
    printfn "Position is: %A" turtle.position
    turtle

let penColor color turtle = { turtle with color = color } |> logPosition
let moveTo position turtle = { turtle with position = position } |> logPosition
let drawline dest turtle = bresenham dest turtle |> logPosition

let drawSquare w turtle = 
  let x, y = turtle.position
  if x + w > width || y + w > height then turtle
  else 
    let draw = 
      drawline (x + w, y)
      >> drawline (x + w, y + w)
      >> drawline (x, y + w)
      >> drawline (x, y)
    draw turtle

let turn d turtle = 
    let dir = turtle.direction + d
    let t = { turtle with direction = dir }
    printfn "%A" t.direction
    t

let move d turtle = 
    let angle = float turtle.direction
    let x, y = turtle.position
    let r = (angle - 90.0) * Math.PI / 180.0
    let x' = (float x) + (float d) * cos r
    let y' = (float y) + (float d) * sin r
    printfn "x=%f" x'
    printfn "y=%f" y'
    drawline (x', y') turtle

let drawCircle (x:float32) turtle = 
    let x', y' = turtle.position
    use gfx = Graphics.FromImage turtle.bitmap
    let p = new Pen(turtle.color)
    gfx.DrawEllipse(p, float32 x', float32 y', x, x)
    turtle

let hex w turtle = 
    turtle
    |> move w         
    |> turn 45.0
    |> move w
    |> turn 45.0
    |> move w
    |> turn 45.0
    |> move w
    |> turn 45.0
    |> move w
    |> turn 45.0
    |> move w
    |> turn 45.0
    |> move w
    |> turn 45.0
    |> move w

let turnLeft90 turtle = { turtle with direction = turtle.direction - 90.0 }

let sq w turtle = 
    turtle
    |> move w
    |> turnLeft90
    |> move w
    |> turnLeft90
    |> move w
    |> turnLeft90
    |> move w

let polygon sides length (turtle:Turtle) = 
    let angle = 360.0/float sides
    Seq.fold (fun s i -> turn angle (move length s)) turtle [1.0..sides]
