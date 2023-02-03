namespace Fable.CloudFlare.Workers

open Fable.Core
open Browser.Types

module Response =
    [<AllowNullLiteral>]
    type Options() =
        [<DefaultValue>]
        val mutable status: int

        [<DefaultValue>]
        val mutable statusText: string

        [<DefaultValue>]
        val mutable headers: Headers

[<Global>]
type Response() =
    new(body: string) = Response()
    new(body: Blob) = Response()
    new(body: JS.ArrayBuffer) = Response()
    new(body: string, options: Response.Options) = Response() 
    new(body: Blob, options: Response.Options) = Response()
    new(body: JS.ArrayBuffer, options: Response.Options) = Response()

    static member redirect(url: string) : Response = jsNative
    static member redirect(url: string, status: int) : Response = jsNative
