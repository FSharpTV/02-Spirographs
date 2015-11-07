#load "PixelPlotter.fs"

// First
#load "PixelPlotter.fs"

// Second
open PixelPlotting.Plotter // Open the module
open System.Drawing // open so we can access the colors easily


// Third
let bm = newBitmap 32 32 // Now we can set the image size ourselves


// Fourth
// But what if there are more pixels? Could be tedious!
for i in [1..22] do // simple iteration with the range operator '..'
    bm.SetPixel(i, 5, Color.Black)


// Fifth - Add an even longer line to the image
bm |> saveAs "longerLine.png"