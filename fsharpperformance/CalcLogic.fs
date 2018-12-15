module CalcLogic
open System
open System.Diagnostics

let mutable msList = [] :List<int>

//Stopwatches
let stopWatch = new Stopwatch() 
let ResetStopWatch() = stopWatch.Reset(); stopWatch.Start()
        
//Sums squares in recursion
let rec sumOfSquares(n :int) =
    if (n = 0) then
        0UL
    else
        uint64(n * n) + sumOfSquares (n - 1)
        
//Sums squares in tail recursion
let sumOfSquaresTailRecursive(n) =
    let rec calcSum(n ,sum :UInt64) =
        if not (n = 0) then
            calcSum(n - 1, sum + uint64(n * n))
        else
            sum
    calcSum(n, 0UL)

 //Sums squares in recursion by storing values in mutable variable
let sumOfSquares2(n) =
    let mutable size = 0UL :UInt64
    let rec sumSquaresOptimized(n) =
        if not (n = 0) then
            size <- (size + uint64(n * n))
            sumSquaresOptimized (n - 1)
    sumSquaresOptimized n
    size

//Sums squares using for loop
let sumOfSquaresLoop(n) =
    let mutable x = 0
    let mutable sum = 0UL
    for x=1 to n do
        sum <- sum + uint64(x * x)
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
           calculation(value, (times - 1), recursion, result)
        else
            finalValue
    calculation(value, times, recursion, 0UL)

//Calculates average time
let averageTime() = 
    let mutable averageMs = 0.0 :float
    List.iter( fun ms -> averageMs <- (averageMs + float(ms) / float(msList.Length)) )msList
    printfn "Average elapsed time in ms: %f" averageMs
    averageMs

