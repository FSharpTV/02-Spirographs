let square num = num * num
let divide num = num / 3
let adder  x y = x + y

let brackets =
    (adder 6
        (square 
            (divide 
                (square 6))))

let piped =
    6 
    |> square 
    |> divide 
    |> square
    |> adder 6
