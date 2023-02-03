namespace Fable.CloudFlare.Workers

open Fable.Core

module Request =
    [<AllowNullLiteral>]
    type Options() =
        [<DefaultValue>]
        val mutable method: string

        [<DefaultValue>]
        val mutable url: string

        [<DefaultValue>]
        val mutable headers: Headers

[<Global>]
[<AllowNullLiteral>]
type Request() =
    new(request: Request) = Request()
    new(request: Request, options: Request.Options) = Request()

    member _.method: string = jsNative
    member _.url: string = jsNative
    member _.headers: Headers = jsNative

    member _.json<'a>() : JS.Promise<'a> = jsNative
    member _.text() : JS.Promise<string> = jsNative
