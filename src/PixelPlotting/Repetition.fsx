#load "PixelPlotter.fs"

// First
#load "PixelPlotter.fs"

// Second
open PixelPlotting.Plotter // Open the module
open System.Drawing // open so we can access the colors easily


// Third
// But what if there are more pixels? Could be tedious!
for i in [1..12] do // simple iteration with the range operator '..'
    bitmap.SetPixel(i, 5, Color.Black)


// Add a longer line to the image
bitmap |> saveAs "repetition.png"