namespace Fable.CloudFlare.Workers

open Fable.Core

[<Global "Headers">]
type Headers() =
    new(headers: Headers) = Headers()
    new(headers: (string * string) seq) = Headers()

    member _.get(name: string) : string option = jsNative
    member _.getAll(name: string) : string seq = jsNative
    member _.has(name: string) : bool = jsNative
    member _.set(name: string, value: string) : unit = jsNative
    member _.append(name: string, value: string) : unit = jsNative
    member _.delete(name: string) : unit = jsNative
    member _.forEach(callback: (JS.Object * string * string * Headers) -> unit) = jsNative
    member _.forEach(callback: ('this * string * string * Headers) -> unit, thisArg: 'this) = jsNative
    member _.values() : string seq = jsNative
    member _.entries() : (string * string) seq = jsNative
    member _.keys() : string seq = jsNative
