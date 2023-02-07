namespace Fable.CloudFlare.Workers

open Fable.Core

type MessageSendRequest<'body> =
    { body: 'body }

type Queue<'body> =
    abstract send: 'body -> JS.Promise<unit>
    abstract sendBatch: MessageSendRequest<'body> -> JS.Promise<unit>

type Message<'body> =
    { id: string
      timestamp: string 
      body: 'body }

type MessageBatch<'body> =
    abstract queue : string
    abstract messages : Message<'body> seq
    abstract retryAll : unit -> unit
