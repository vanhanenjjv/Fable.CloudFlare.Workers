namespace Fable.CloudFlare.Workers

open Fable.Core

module Request =
    type Options =
        { method: string option
          url: string option
          headers: Headers option }

    module Options =
        let make () =
            { method = None
              url = None
              headers = None }

type Request =
    abstract method : string
    abstract url : string
    abstract headers : Headers
    abstract json<'a> : unit -> JS.Promise<'a>
    abstract text : unit -> JS.Promise<string>

type RequestStatic =
    [<Emit "new $0($1)">]
    abstract make : Request -> Request
    [<Emit "new $0($1, $2)">]
    abstract make : Request * Request.Options -> Request

[<AutoOpen>]
module Globals =
    [<Global>]
    let Request: RequestStatic = jsNative
