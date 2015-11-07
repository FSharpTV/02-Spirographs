open System.Drawing
open System.IO

let pathAndFileName =
    Path.Combine(__SOURCE_DIRECTORY__, "naive.png")

let bitmap = new Bitmap(32, 32)

bitmap.Save(pathAndFileName)
