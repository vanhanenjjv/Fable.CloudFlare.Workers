namespace Fable.CloudFlare.Workers

open Fable.Core

module KVNamespace =
    type ListOptions =
        { limit: int option
          prefix: string option
          cursor: string option }

    module ListOptions =
        let make () =
            { limit = None
              prefix = None
              cursor = None }

    type GetWithMetadataResult<'value, 'metadata> =
        { value: 'value
          metadata: 'metadata }

type KVNamespace =
    [<Emit "$0.get($1)">]
    abstract get : string -> JS.Promise<string option>
    [<Emit "$0.get($1, 'json')">]
    abstract getJSON<'a> : string -> JS.Promise<'a option>
    [<Emit "$0.get($1, 'arrayBuffer')">]
    abstract getArrayBuffer : string -> JS.Promise<JS.ArrayBuffer option>
    abstract list : unit -> JS.Promise<unit>
    abstract list : KVNamespace.ListOptions -> JS.Promise<unit>
    abstract put : string * string -> JS.Promise<unit>
    abstract put : string * JS.ArrayBuffer -> JS.Promise<unit>
    abstract put : string * JS.ArrayBufferView -> JS.Promise<unit>
    abstract getWithMetadata<'metadata> : string -> KVNamespace.GetWithMetadataResult<string, 'metadata>
