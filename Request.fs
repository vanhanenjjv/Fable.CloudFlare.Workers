namespace Fable.CloudFlare.Workers

open Fable.Core

[<AutoOpen>]
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

    type Request = interface end

    type RequestStatic =
        [<Emit "new $0($1)">]
        abstract make : Request -> Request
        [<Emit "new $0($1, $2)">]
        abstract make : Request * Options -> Request

    [<Global>]
    let Request: RequestStatic = jsNative
