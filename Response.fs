namespace Fable.CloudFlare.Workers

open Fable.Core
open Browser.Types

module Response =
    type Options =
        { status: int option
          statusText: string option
          headers: Headers option }

type Response = interface end

type ResponseStatic =
    [<Emit "new $0($1)">]
    abstract make : string -> Response
    [<Emit "new $0($1)">]
    abstract make : Blob -> Response
    [<Emit "new $0($1)">]
    abstract make : JS.ArrayBuffer -> Response
    [<Emit "new $0($1, $2)">]
    abstract make : string * Response.Options -> Response
    [<Emit "new $0($1, $2)">]
    abstract make : Blob * Response.Options -> Response
    [<Emit "new $0($1, $2)">]
    abstract make : JS.ArrayBuffer * Response.Options -> Response
    [<Emit "new $0($1, $2)">]
    
    abstract member redirect: string -> Response
    abstract member redirect: string * int -> Response

[<AutoOpen>]
module Globals =
    [<Global>]
    let Response: ResponseStatic = jsNative
