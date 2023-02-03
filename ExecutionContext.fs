namespace Fable.CloudFlare.Workers

open Fable.Core

[<Global>]
type ExecutionContext =
    member _.waitUntil(promise: JS.Promise<'a>) : unit = jsNative
    member _.passThroughOnException() : unit = jsNative
