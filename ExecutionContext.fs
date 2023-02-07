namespace Fable.CloudFlare.Workers

open Fable.Core

type ExecutionContext =
    abstract waitUntil : JS.Promise<_> -> unit
    abstract passThroughOnException: unit -> unit
