﻿open System
open CalcLogic


[<EntryPoint>]
let main argv = 
    printfn "Logic types:"
    printfn "Type '1' for: Tail recursion"
    printfn "Type '2' for: Optimized recursion"
    printfn "Type '3' for: Loop"
    printfn "Else Simple recursion"
    printfn ""
    while true do 
        printfn "Enter a number to calculate sum of squares"
        let number = Console.ReadLine() |> int
        printfn "Enter how many times to run it"
        let times = Console.ReadLine() |> int
        printfn "Enter logic type"
        let recursion = Console.ReadLine() |> int
        let finalValue = startCalculation(number, times, recursion)
        printfn "Value: %O" finalValue 
        averageTime() |> ignore

    0 // return an integer exit code
