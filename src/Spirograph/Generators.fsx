// 1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz

let fizzy =
    seq {
        for x in 1..100 do
            yield if x % 3 = 0 && x % 5 = 0 
                  then "FizzBuzz"
                  elif x % 3 = 0 then "Fizz"
                  elif x % 5 = 0 then "Buzz"
                  else x.ToString() }

let threesAndFives =
    seq {
        for x in 1..999 do
            if x % 3 = 0 || x % 5 = 0
            then yield x }

let folded = threesAndFives |> Seq.fold (fun x num -> x + num) 0

let reduced = threesAndFives |> Seq.reduce (fun x num -> x + num)