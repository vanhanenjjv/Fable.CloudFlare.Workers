namespace Fable.CloudFlare.Workers

open Fable.Core

[<AutoOpen>]
module Headers =
    type Headers =
        abstract get: string -> string seq
        abstract getAll: string -> string seq
        abstract has: string -> bool
        [<Emit "$0($1, $2)">]
        abstract set: string -> string -> unit
        [<Emit "$0($1, $2)">]
        abstract append: string -> string -> unit
        abstract delete: string -> unit
        abstract forEach: (JS.Object -> string -> string -> Headers) -> unit
        abstract forEach: ('this -> string -> string -> Headers -> unit) -> 'this
        abstract values: unit -> string seq
        abstract entries: unit -> (string * string) seq
        abstract keys: unit -> string seq

    type HeadersStatic =
        [<Emit "new $0()">]
        abstract make : unit -> Headers
        [<Emit "new $0($1)">]
        abstract make : (string * string) seq -> Headers

    [<Global>]
    let Headers: HeadersStatic = jsNative
