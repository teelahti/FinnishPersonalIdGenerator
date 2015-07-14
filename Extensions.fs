module Extensions

open System

type Random with
    member this.NextLong (min : int64, max : int64) =
        let buf : byte [] = Array.zeroCreate 8
        this.NextBytes buf
        let longRand = BitConverter.ToInt64(buf, 0)
        Math.Abs(longRand % (max - min)) + min
