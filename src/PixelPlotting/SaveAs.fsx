#load "PixelPlotter.fs"

// First
#load "PixelPlotter.fs"

// Second
open PixelPlotting.Plotter // Open the module
open System.Drawing // open so we can access the colors easily


// Third
// Manual Line draw
bitmap.SetPixel(5,7, Color.Black)
bitmap.SetPixel(6,7, Color.Black)
bitmap.SetPixel(7,7, Color.Black)
bitmap.SetPixel(8,7, Color.Black)
bitmap.SetPixel(9,7, Color.Black)

// Forth
bitmap |> saveAs "simpleLine.png" // call our saver function passing in the bitmap we have manipulated
