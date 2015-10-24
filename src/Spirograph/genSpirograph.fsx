#load "Spirograph.fs"
open System.Drawing
open FSharp.TV.Spirograph


let cmdsStripe = 
    [ 
      curve5th 100.0 10
      penColor Color.DarkMagenta 
      turn 10.0 
      curve15th 50.0 80
      penColor Color.Goldenrod 
      turn 70.0 
      curve5th 80.0 30
      penColor Color.DarkMagenta 
      turn 10.0 
      curve3rd 55.0 15
      penColor Color.LightSeaGreen 
      turn 315.0 ]


let cmdsGen = 
    [] 
    |> Seq.unfold (fun save -> Some(save, cmdsStripe)) 
    |> Seq.collect id

let innerCmds =
    cmdsGen 
    |> Seq.take 3500
    |> Seq.toList

let appendSave sCmd iCmd =
    let revd = sCmd :: (iCmd |> List.rev)
    revd |> List.rev

let cmds = 
    moveTo (500.0,500.0) 
    :: (appendSave (saveAs "rotund") innerCmds)


let draw =
    Seq.fold 
        (fun s f -> f s) 
        (newTurtle())
        cmds

