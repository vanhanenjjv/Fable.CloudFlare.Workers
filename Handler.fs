namespace Fable.CloudFlare.Workers

open Fable.Core

[<AutoOpen>]
module Handler =
    type FetchHandler<'environment> = Request -> 'environment -> ExecutionContext -> JS.Promise<Response>
    type QueueHandler<'environment, 'message> = MessageBatch<'message> -> 'environment -> ExecutionContext -> JS.Promise<unit>
    type ScheduledHandler<'environment> = ScheduledController -> 'environment -> ExecutionContext -> JS.Promise<unit>

    type Handler<'environment, 'message> =
        { fetch: FetchHandler<'environment> option
          scheduled: ScheduledHandler<'environment> option
          queue: QueueHandler<'environment, 'message> option }

    [<RequireQualifiedAccess>]
    module Handler =
        let make<'environment, 'message> (): Handler<'environment, 'message> =
            { fetch = None
              scheduled = None
              queue = None }
        let withFetch (fetch: FetchHandler<_>) (handler: Handler<_, _>) =
            { handler with fetch = Some fetch }
        let withQueue (queue: QueueHandler<_, _>) (handler: Handler<_, _>) =
            { handler with queue = Some queue }
        let withScheduled (scheduled: ScheduledHandler<_>) (handler: Handler<_, _>) =
            { handler with scheduled = Some scheduled }
