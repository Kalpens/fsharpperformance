open System
open CalcLogic


[<EntryPoint>]
let main argv = 
    while true do 
        printfn "Enter a number to calculate sum of squares"
        let number = Console.ReadLine() |> int64
        printfn "Enter how many times to run it"
        let times = Console.ReadLine() |> int
        msList <- []
        startCalculation(number, times)
        printfn "Value: %O" size 
        let time = averageTime(-1)
        if (time = -1)then
            printf"Something went wrong calculating average time"

    0 // return an integer exit code
