let location = (77.51,166.40,21)

let longAlt location =
    let long,_,alt = location
    (alt, long)

printfn "%A" (snd (longAlt location))

let birthday = 21,1,1970

let reverse birth =
    let dd,mm,yy = birth
    yy,mm,dd

printfn "%A" (reverse birthday)