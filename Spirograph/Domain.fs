namespace FSharp.TV.Spirograph

[<AutoOpen>]
module Domain =
    open System.Drawing
    open System
    open System.IO

    type Turtle = 
      { Position : int * int
        Color : Color
        Direction : float
        Bitmap : Bitmap }

    let bresenham (x1, y1) turtle = 
      let x0, y0 = turtle.Position
      let newTurtle = { turtle with Position = x1, y1 }
      let steep = abs (y1 - y0) > abs (x1 - x0)
      
      let x0, y0, x1, y1 = 
        if steep then y0, x0, y1, x1
        else x0, y0, x1, y1
      
      let x0, y0, x1, y1 = 
        if x0 > x1 then x1, y1, x0, y0
        else x0, y0, x1, y1
      
      let x', y' = float (x1 - x0), float (abs (y1 - y0))
      
      let step = 
        if y0 < y1 then 1
        else -1
      
      let rec draw e x y = 
        if x <= int x1 then 
          if steep then turtle.Bitmap.SetPixel(y, x, turtle.Color)
          else turtle.Bitmap.SetPixel(x, y, turtle.Color)
          if e < y' then draw (e - y' + x') (x + 1) (y + step)
          else draw (e - y') (x + 1) y
      
      draw (x' / 2.0) (int x0) (int y0)
      newTurtle

    let filename = sprintf "Logo.png"
    let filePath = Path.Combine(__SOURCE_DIRECTORY__, filename)
    let withFilePath f = Path.Combine(__SOURCE_DIRECTORY__, f)
    let saveAs name turtle = turtle.Bitmap.Save(withFilePath (name + ".png"), Imaging.ImageFormat.Png)
    let newCanvas (x : int) y = new Bitmap(x, y)
    let width = 1000
    let height = 1000
    let image = newCanvas width height

    let defaultTurtle = 
      { Position = 0, 0
        Color = Color.Red
        Direction = 0.0
        Bitmap = newCanvas width height }

    let newTurtle() = defaultTurtle

    let logPosition turtle = 
      printfn "Position is: %A" turtle.Position
      turtle

    let penColor color turtle = { turtle with Color = color } |> logPosition
    let moveTo position turtle = { turtle with Position = position } |> logPosition
    let drawline dest turtle = bresenham dest turtle |> logPosition

    let drawSquare w turtle = 
      let x, y = turtle.Position
      if x + w > width || y + w > height then turtle
      else 
        let draw = 
          drawline (x + w, y)
          >> drawline (x + w, y + w)
          >> drawline (x, y + w)
          >> drawline (x, y)
        draw turtle

    let turn d turtle = 
      let dir = turtle.Direction + d
      let t = { turtle with Direction = dir }
      printfn "%A" t.Direction
      t

    let move d turtle = 
      let angle = float turtle.Direction
      let x, y = turtle.Position
      let r = (angle - 90.0) * Math.PI / 180.0
      let x' = (float x) + (float d) * cos r
      let y' = (float y) + (float d) * sin r
      printfn "x=%f" x'
      printfn "y=%f" y'
      drawline (int x', int y') turtle

    let drawCircle x turtle = 
      let x', y' = turtle.Position
      use gfx = Graphics.FromImage turtle.Bitmap
      let p = new Pen(turtle.Color)
      gfx.DrawEllipse(p, x', y', x, x)
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

    let turnLeft90 turtle = { turtle with Direction = turtle.Direction - 90.0 }

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
        Seq.fold (fun s i -> turn angle (move length s)) turtle [1..sides]
