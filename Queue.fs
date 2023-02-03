namespace Fable.CloudFlare.Workers

open Fable.Core

[<Global>]
type MessageSendRequest<'body> =
    { body: 'body }

[<Global>]
type Queue<'body> =
    member _.send(body: 'body): JS.Promise<unit> = jsNative
    member _.sendBatch(messages: MessageSendRequest<'body>): JS.Promise<unit> = jsNative

[<Global>]
type Message<'body> =
    { id: string
      timestamp: string 
      body: 'body }

[<Global>]
type MessageBatch<'body> () =
    member _.queue: string = jsNative
    member _.messages: Message<'body> seq = jsNative
    member _.retryAll(): unit = jsNative

