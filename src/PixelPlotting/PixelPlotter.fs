// first
module PixelPlotting.Plotter // Namespace and module

// second
open System.IO // open System.IO for Path
open System.Drawing // open System.Drawing so we can use the Bitmap type

// third
let bitmap = new Bitmap(16,16) // standard icon size

// fourth
let withFilePath f = Path.Combine(__SOURCE_DIRECTORY__, f) // will save in the project directory

// Fifth
let saver (bm:Bitmap) = // Type annotation so that the compiler knows what 'bm' is
    bm.Save(withFilePath "plot.png", Imaging.ImageFormat.Png) // PNG file output

// Sixth - Limitations Video
let saveAs fileName (bm:Bitmap) = // Ensure 'bm' is the second parameter, then it can be 'piped'
    bm.Save(withFilePath fileName, Imaging.ImageFormat.Png)

// Seventh - Limitations Video
let newBitmap x (y:int) = // Currying, type annotation
    new Bitmap(x, y)