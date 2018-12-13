module CalcLogic
open System
open System.Diagnostics

let mutable msList = []

//Stopwatches
let stopWatch = new Stopwatch() 
let ResetStopWatch() = stopWatch.Reset(); stopWatch.Start()

// define the square function
let square x :int64 = x * x
        
//Sums squares in recursion
let rec sumOfSquares(n :int64) =
    if (n = 0L) then
        0UL
    else
        uint64(square n) + sumOfSquares (n - 1L)
        
//Sums squares in tail recursion
let sumOfSquaresTailRecursive(n :int64) =
    let rec calcSum(n :int64 ,sum :UInt64) =
        if not (n = 0L) then
            calcSum(n - 1L, sum + uint64(square(n)))
        else
            sum
    calcSum(n, 0UL)

 //Sums squares in recursion by storing values in mutable variable
let sumOfSquares2(n :int64) =
    let mutable size = 0UL :UInt64
    let rec sumSquaresOptimized(n) =
        if not (n = 0L) then
            size <- (size + uint64(square n))
            sumSquaresOptimized (n - 1L)
    sumSquaresOptimized n
    size

//Sums squares using for loop
let sumOfSquaresLoop(n) =
    let mutable x = 0L
    let mutable sum = 0UL
    for x=1 to n do
        sum <- sum + uint64(square(int64(x)))
    sum

//Runs logic x times
let startCalculation(value, times, recursion) =
    msList <- []
    let rec calculation(value, times, recursion, finalValue) = 
        if not (times = 0)then
           ResetStopWatch()
           let result = 
                if(recursion = 1)then
                    sumOfSquaresTailRecursive(value)
                else if(recursion = 2)then
                    sumOfSquares2(value)
                else if(recursion = 3)then
                    sumOfSquaresLoop(int(value))
                else
                    sumOfSquares(value)
           let ms = int(stopWatch.ElapsedMilliseconds)
           msList <- List.append msList [ms]
           calculation(value, (times - 1), recursion, (finalValue + result))
        else
            finalValue
    calculation(value, times, recursion, 0UL)

//Calculates average time
let averageTime() = 
    let mutable averageMs = 0 :int
    List.iter( fun ms -> averageMs <- (averageMs + ms / msList.Length) )msList
    printfn "Average elapsed time in ms: %i" averageMs
    averageMs

