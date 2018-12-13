open System
open CalcLogic


[<EntryPoint>]
let main argv = 
    while true do 
        printfn "Enter a number to calculate sum of squares"
        let number = Console.ReadLine() |> int64
        printfn "Enter how many times to run it"
        let times = Console.ReadLine() |> int
        printfn "To use tail recursion type 1, to use optimized recursion type 2"
        let recursion = Console.ReadLine() |> int
        let finalValue = startCalculation(number, times, recursion)
        printfn "Value: %O" finalValue 
        let time = averageTime(-1)
        if (time = -1)then
            printf"Something went wrong calculating average time"

    0 // return an integer exit code
