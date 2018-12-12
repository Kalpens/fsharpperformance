module CalcLogic
open System
open System.Diagnostics

let mutable size = 0UL :UInt64
let mutable msList = []

//Stopwatches
let stopWatch = new Stopwatch() 
let ResetStopWatch() = stopWatch.Reset(); stopWatch.Start()

// define the square function
let square x :int64 = x * x

//Sums squares in recursion
let rec sumOfSquares(n :int64) =
    if not (n = 0L) then
        size <- (size + uint64(square n))
        sumOfSquares (n - 1L)

//Runs logic x times in recursion
let rec startCalculation(value, times) =
    if not (times = 0)then  
        size <- 0UL
        ResetStopWatch()
        sumOfSquares(value)
        let ms = int(stopWatch.ElapsedMilliseconds)
        msList <- List.append msList [ms]
        startCalculation(value, (times - 1))

//Calculates average time
let averageTime(z) = 
    let mutable averageMs = 0 :int
    List.iter( fun ms -> averageMs <- (averageMs + ms / msList.Length) )msList
    printfn "Average elapsed time in ms: %i" averageMs
    averageMs

