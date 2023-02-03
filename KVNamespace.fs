namespace Fable.CloudFlare.Workers

open Fable.Core

module KVNamespace =
    [<AllowNullLiteral>]
    type ListOptions() =
        [<DefaultValue>]
        val mutable limit: int
        [<DefaultValue>]
        val mutable prefix: string
        [<DefaultValue>]
        val mutable cursor: string

    [<AllowNullLiteral>]
    type GetWithMetadataResult<'value, 'metadata>() =
        [<DefaultValue>]
        val mutable value: 'value
        [<DefaultValue>]
        val mutable metadata: 'metadata

[<Global>]
type KVNamespace =
    [<Emit "$0.get($1)">]
    member _.get<'a>(key: string) : JS.Promise<string option> = jsNative
    [<Emit "$0.get($1, 'json')">]
    member _.getJson<'a>(key: string) : JS.Promise<'a option> = jsNative
    [<Emit "$0.get($1, 'arrayBuffer')">]
    member _.getArrayBuffer<'a>(key: string) : JS.Promise<JS.ArrayBuffer option> = jsNative
    member _.list() : JS.Promise<unit> = jsNative
    member _.list(options: KVNamespace.ListOptions) : JS.Promise<unit> = jsNative
    member _.put(key: string, value: string) : JS.Promise<unit> = jsNative
    member _.put(key: string, value: JS.ArrayBuffer) : JS.Promise<unit> = jsNative
    member _.put(key: string, value: JS.ArrayBufferView) : JS.Promise<unit> = jsNative
    member _.getWithMetadata(key: string): KVNamespace.GetWithMetadataResult<string, obj> = jsNative
    member _.getWithMetadata<'metadata>(key: string): KVNamespace.GetWithMetadataResult<string, 'metadata> = jsNative
